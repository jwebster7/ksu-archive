using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace PhilsRentals.Views
{
    public partial class ModifyAccountWindow : UserControl
    {
        /// <summary>
        /// Handle to get the selected account from the MainWindow.
        /// </summary>
        AccountSelector _GetSelectedAccount;

        /// <summary>
        /// Handle to the MainWindowController.
        /// </summary>
        IMainWindowController _mwc;

        public ModifyAccountWindow(IMainWindowController mwc, AccountSelector GetSelectedAccount)
        {
            InitializeComponent();
            _mwc = mwc;
            _GetSelectedAccount = GetSelectedAccount;
        }

        public void InitWindow()
        {
            uxTextBoxFirstName.Text = String.Empty;
            uxTextBoxLastName.Text = String.Empty;
            uxTextBoxNewEmail.Text = String.Empty;
            uxTextBoxPhoneNumber.Text = String.Empty;
            uxTextBoxSearchEmail.Text = String.Empty;
            uxTextBoxSearchEmail.Enabled = true;
            uxTextBoxPhoneNumber.Enabled = false;
            uxTextBoxNewEmail.Enabled = false;
            uxTextBoxFirstName.Enabled = false;
            uxTextBoxLastName.Enabled = false;
            uxButtonSearchEmail.Enabled = true;
            uxButtonUpdateInfo.Enabled = false;
        }

        private void uxTextBoxTextChanged(object sender, EventArgs e)
        {
            if (((TextBox)sender).Name.Equals(uxTextBoxSearchEmail.Name))
            {
                uxButtonSearchEmail.Enabled = uxTextBoxSearchEmail.TextLength > 0;
            }
            else
            {
                uxButtonUpdateInfo.Enabled = uxTextBoxFirstName.TextLength > 0 || uxTextBoxPhoneNumber.TextLength > 0 || uxTextBoxNewEmail.TextLength > 0 || uxTextBoxLastName.TextLength == 10;
            }
        }


        /// <summary>
        /// Pulls the customer info from the SQL Tables
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxButtonUpdateInfo_Click(object sender, EventArgs e)
        {
            bool ret = _mwc.ModifyAccountInformation(uxTextBoxSearchEmail.Text, uxTextBoxNewEmail.Text, uxTextBoxPhoneNumber.Text, uxTextBoxFirstName.Text, uxTextBoxLastName.Text);
            if(ret)
            {
                MessageBox.Show("Update processed successfully", "Success");
            }
            else
            {
                MessageBox.Show("Error With Update", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            InitWindow();
        }

        /// <summary>
        /// Looks for the email in the Account table
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxButtonSearchEmail_Click(object sender, EventArgs e)
        {
            string email = uxTextBoxSearchEmail.Text;
            
            if (!email.Equals(_GetSelectedAccount()))
            {
                string[] account_info = _mwc.GetAccountInformation(email);
                if (account_info[0].Equals("error"))
                {
                    MessageBox.Show("Account not in system. Please try a different Email address.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    InitWindow();
                }
                else
                {
                    uxTextBoxFirstName.Enabled = true;
                    uxTextBoxPhoneNumber.Enabled = true;
                    uxTextBoxNewEmail.Enabled = true;
                    uxTextBoxNewEmail.Text = uxTextBoxSearchEmail.Text;
                    uxTextBoxLastName.Enabled = true;
                    uxTextBoxSearchEmail.Enabled = false;
                    uxButtonSearchEmail.Enabled = false;
                    uxTextBoxNewEmail.Text = account_info[0];
                    uxTextBoxLastName.Text = account_info[3];
                    uxTextBoxFirstName.Text = account_info[2];
                    uxTextBoxPhoneNumber.Text = account_info[1];
                }
            }
            else
            {
                MessageBox.Show("You cannot modify an account that is currently selected", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                InitWindow();
            }
        }
    }
}
