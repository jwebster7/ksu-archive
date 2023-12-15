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
    public partial class DeleteAccountWindow : UserControl
    {
        /// <summary>
        /// Handle to get the selected account from the MainWindow.
        /// </summary>
        AccountSelector _GetSelectedAccount;

        /// <summary>
        /// Handle to the MainWindowController.
        /// </summary>
        IMainWindowController _mwc;

        public DeleteAccountWindow(IMainWindowController mwc, AccountSelector GetSelectedAccount)
        {
            InitializeComponent();
            _mwc = mwc;
            _GetSelectedAccount = GetSelectedAccount;
        }

        private void uxTextboxEmail_TextChanged(object sender, EventArgs e)
        {
            uxButtonAccept.Enabled = uxTextboxEmail.TextLength > 0;
        }

        private void uxButtonAccept_Click(object sender, EventArgs e)
        {
            string email = uxTextboxEmail.Text;

            if (uxTextboxEmail.Text.Equals(_GetSelectedAccount()))
            {
                MessageBox.Show("You cannot delete an account that is currently selected.", "Error");
            }
            else
            {

                List<Movie> movies = (_mwc.GetRentedMovies(email));
                if (movies.Count == 0)
                {
                    if (_mwc.DeleteAccount(email))
                    {
                        MessageBox.Show("Account Deleted Successfully.", "Success");
                    }
                    else
                    {
                        MessageBox.Show("There was an error deleting the account.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("You cannot delete an account that has rented movies.");
                }
            }

            uxTextboxEmail.Text = String.Empty;
            uxButtonAccept.Enabled = false;
        }

        private void uxTextboxEmail_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && MainWindowController.RegexEmail.IsMatch(uxTextboxEmail.Text))
            {
                uxButtonAccept_Click(this, new EventArgs());
            }
        }
    }
}
