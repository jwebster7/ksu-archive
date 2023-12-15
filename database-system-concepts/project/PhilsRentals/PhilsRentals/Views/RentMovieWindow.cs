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
    public partial class RentMovieWindow : UserControl
    {
        /// <summary>
        /// Handle to get the selected account from the MainWindow.
        /// </summary>
        AccountSelector _GetSelectedAccount;

        /// <summary>
        /// Handle to the MainWindowController.
        /// </summary>
        IMainWindowController _mwc;

        public RentMovieWindow(IMainWindowController mwc, AccountSelector GetSelectedAccount)
        {
            InitializeComponent();
            _mwc = mwc;
            _GetSelectedAccount = GetSelectedAccount;
        }

        //not working yet, the information is coming in from the database but not being displayed right within the listbox
        public void InitWindow()
        {
            uxDataGridViewMovies.Rows.Clear();
            List<Movie> movies = new List<Movie>();
            movies = _mwc.initDisp();
            
            foreach (Movie movie in movies)
            {
                uxDataGridViewMovies.Rows.Add(movie.Title, movie.Count);
            }
            uxDataGridViewMovies.ClearSelection();
            uxButtonRentMovie.Enabled = false;
        }

        private void uxDataGridViewMovies_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            uxButtonRentMovie.Enabled = uxDataGridViewMovies.SelectedRows != null;
        }

        private void uxTextBoxMovieTitle_TextChanged(object sender, EventArgs e)
        {
            string search = uxTextBoxMovieTitle.Text.ToLower();
            if (!String.IsNullOrEmpty(search.Trim()))
            {
                for (int i = (uxDataGridViewMovies.Rows.Count - 1); i >= 0; i--)
                {
                    DataGridViewRow row = uxDataGridViewMovies.Rows[i];
                    row.Visible = row.Cells["MovieTitle"].Value.ToString().ToLower().Contains(search);
                    if (row.Visible)
                    {
                        uxDataGridViewMovies.FirstDisplayedScrollingRowIndex = i;
                    }
                }
            }
            else
            {
                foreach (DataGridViewRow row in uxDataGridViewMovies.Rows)
                {
                    row.Visible = true;
                }
                uxDataGridViewMovies.FirstDisplayedScrollingRowIndex = 0;
            }

            uxDataGridViewMovies.ClearSelection();
            uxButtonRentMovie.Enabled = false;
        }

        private void uxButtonRentMovie_Click(object sender, EventArgs e)
        {
            List<Movie> rentedMovies = _mwc.GetRentedMovies(_GetSelectedAccount());
            foreach (Movie movie in rentedMovies)
            {
                if (movie.Title.Equals(uxDataGridViewMovies.SelectedRows[0].Cells["MovieTitle"].Value))
                {
                    MessageBox.Show("You have already rented this movie! Limit 1 per customer.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            if(rentedMovies.Count >= 4)
            {
                MessageBox.Show("Customers may only rent 4 movies at a time.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string returnDate = _mwc.RentMovie(_GetSelectedAccount(), uxDataGridViewMovies.SelectedRows[0].Cells["MovieTitle"].Value.ToString());
            if (returnDate != null)
            {
                MessageBox.Show("Movie Successfully rented. You movie is due: " + returnDate, "Success");
            }
            else
            {
                
                MessageBox.Show("There was a problem renting the movie. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            InitWindow();
        }
    }
}