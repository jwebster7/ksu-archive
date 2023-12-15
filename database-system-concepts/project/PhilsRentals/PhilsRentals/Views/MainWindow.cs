using PhilsRentals.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhilsRentals
{
    public partial class MainWindow : Form
    {
        /// <summary>
        /// MainWindowController handle.
        /// </summary>
        private IMainWindowController _mwc;

        /// <summary>
        /// Dictionary of operation windows.
        /// </summary>
        private Dictionary<string, UserControl> _windows;

        /// <summary>
        /// Dictionary of menu selection panels.
        /// </summary>
        private Dictionary<string, Panel> _menuPanels;

        /// <summary>
        /// Email of the account selected.
        /// </summary>
        private string _account = "Select Account";

        /// <summary>
        /// Constructs the MainWindow view.
        /// </summary>
        /// <param name="operate">Operation handler for MainWindowController</param>
        public MainWindow(IMainWindowController mwc)
        {
            InitializeComponent();
            _mwc = mwc; // Store MainWindowController
            InitializeUx(); // Initialize Ux
        }

        /// <summary>
        /// Initialize user experience components.
        /// </summary>
        private void InitializeUx()
        {
            _windows = new Dictionary<string, UserControl>();
            _windows.Add("Browse Movies", new BrowseMovieWindow(_mwc));
            _windows.Add("Rent Movies", new RentMovieWindow(_mwc, this.GetSelectedAccount));
            _windows.Add("Return Movies", new ReturnMovieWindow(_mwc, this.GetSelectedAccount));
            _windows.Add("Create Account", new CreateAccountWindow(_mwc));
            _windows.Add("Modify Account", new ModifyAccountWindow(_mwc, this.GetSelectedAccount));
            _windows.Add("Delete Account", new DeleteAccountWindow(_mwc, this.GetSelectedAccount));
            _windows.Add("Add Movie", new AddMovieWindow(_mwc));

            /* Add menu selection panels to the dictionary of menu selection panels */
            _menuPanels = new Dictionary<string, Panel>();
            _menuPanels.Add("Browse Movies", uxPanelBrowseMovie);
            _menuPanels.Add("Rent Movies", uxPanelRentMovie);
            _menuPanels.Add("Return Movies", uxPanelReturnMovie);
            _menuPanels.Add("Create Account", uxPanelCreateAccount);
            _menuPanels.Add("Modify Account", uxPanelModifyAccount);
            _menuPanels.Add("Delete Account", uxPanelDeleteAccount);
            _menuPanels.Add("Add Movie", uxPanelAddMovie);

            /* Start program with default menu */
            uxMenuHandler(uxButtonBrowseMovie, new EventArgs()); // Open default menu
        }

        /// <summary>
        /// Get selected account.
        /// </summary>
        public string GetSelectedAccount()
        {
            return _account;
        }

        /// <summary>
        /// Handles the event when the user selects a menu item.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxMenuHandler(object sender, EventArgs e)
        {
            Button selectedButton = (sender as Button); // Get selected button
            string selectedMenu = selectedButton.Text; // Get selected menu text

            /* Display the selection menu indicator on the selected menu and hide the others */
            if (!selectedButton.Name.Equals("uxButtonSelectAccount"))
            {
                foreach (KeyValuePair<string, Panel> kvp in _menuPanels)
                {
                    kvp.Value.Visible = kvp.Key.Equals(selectedMenu);
                }

                if (uxPanelMain.Controls.Count > 0)
                {
                    uxPanelMain.Controls.RemoveAt(0);
                }

                Control window = _windows[selectedMenu];
                if (window != null)
                {
                    window.Dock = DockStyle.Fill;
                    uxPanelMain.Controls.Add(window);

                    if (window is RentMovieWindow)
                    {
                        ((RentMovieWindow)window).InitWindow();
                    }
                    else if(window is ReturnMovieWindow)
                    {
                        ((ReturnMovieWindow)window).InitWindow();
                    }
                }
            }
            else
            {
                if (_account.Equals("Select Account"))
                {
                    string email = ObtainAccount();
                    if (email.Length > 0 && email.Contains("@"))
                    {
                        if (_mwc.checkSelectedAccount(email))
                        {
                            uxPanelSelectAccount.Visible = true;
                            uxButtonSelectAccount.Text = email;
                            _account = email;
                            uxButtonRentMovie.Enabled = true;
                            uxButtonReturnMovie.Enabled = true;
                        }
                        else
                        {
                            MessageBox.Show("Account does not exist in the system. Please try a different Email or create an account.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        if (email.Length != 0)
                        {
                            MessageBox.Show("Invalid Email", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    uxPanelSelectAccount.Visible = false;
                    uxButtonSelectAccount.Text = "Select Account";
                    _account = "Select Account";
                    uxButtonRentMovie.Enabled = false;
                    uxButtonReturnMovie.Enabled = false;
                }
            }
        }

        private string ObtainAccount()
        {
            Form prompt = new Form() {
                BackColor = System.Drawing.Color.White, Width = 350, Height = 150, Text = "Select Account", MaximizeBox = false
            };

            Label textLabel = new Label() { Left = 15, Top = 30, Text = "Email Address:" };
            TextBox inputBox = new TextBox() { Left = 120, Top = 28, Width = 200 };
            Button confirmation = new Button() { Text = "Ok", Left = 222, Width = 100, Top = 70 };
            
            confirmation.Click += (sender, e) => { prompt.Close(); prompt.DialogResult = DialogResult.OK; };
            confirmation.Enabled = false;
            inputBox.TextChanged += (sender, e) => { confirmation.Enabled = inputBox.TextLength > 0; };
            prompt.AcceptButton = confirmation;
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(textLabel);
            prompt.Controls.Add(inputBox);

            DialogResult result = prompt.ShowDialog();
            return (result == DialogResult.Cancel) ? String.Empty : inputBox.Text;
        }
    }
}