using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhilsRentals.Views
{
    public partial class CreateAccountWindow : UserControl
    {
        /// <summary>
        /// Handle to the MainWindowController.
        /// </summary>
        IMainWindowController _mwc;

        public CreateAccountWindow(IMainWindowController mwc)
        {
            InitializeComponent();
            _mwc = mwc;
        }

        public void InitWindow()
        {
            uxTextboxEmail.Text = String.Empty;
            uxTextboxFirstName.Text = String.Empty;
            uxTextboxLastName.Text = String.Empty;
            uxTextboxPhoneNumber.Text = String.Empty;
            uxButtonAccept.Enabled = false;
        }

        /// <summary>
        /// Gathers the information from the text boxes and sends it to the controller to add the account to the database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxButtonAccept_Click(object sender, EventArgs e)
        {
            if (MainWindowController.RegexEmail.IsMatch(uxTextboxEmail.Text))
            {
                string firstName = uxTextboxFirstName.Text;
                string lastName = uxTextboxLastName.Text;
                string email = uxTextboxEmail.Text;
                string phoneNumber = String.Format("{0:(###) ###-####}", Convert.ToDouble(uxTextboxPhoneNumber.Text));

                if (_mwc.CreateAccount(firstName, lastName, phoneNumber, email))
                {
                    MessageBox.Show("Account Created Successfully", "Success");
                }
                else
                {
                    MessageBox.Show("There was a problem creating the account. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }    
            }
            else
            {
                MessageBox.Show("You have entered an invalid email format. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            InitWindow();
    }

        private void uxTextboxTextChanged(object sender, EventArgs e)
        {
            uxButtonAccept.Enabled = uxTextboxEmail.TextLength > 0 && uxTextboxFirstName.TextLength > 0 && uxTextboxLastName.TextLength > 0 && uxTextboxPhoneNumber.TextLength == 10;
        }
    }
}
