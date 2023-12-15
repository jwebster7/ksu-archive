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
    public partial class AddMovieWindow : UserControl
    {
        /// <summary>
        /// Handle to the MainWindowController.
        /// </summary>
        IMainWindowController _mwc;

        public AddMovieWindow(IMainWindowController mwc)
        {
            InitializeComponent();
            _mwc = mwc;
        }

        private void uxFieldsChanged(object sender, EventArgs e)
        {
            if (sender is TextBox && ((TextBox)sender).Name.Equals("uxTextBoxDuration"))
            {
                TextBox box = (TextBox)sender;

                if (box.Name.Equals("uxTextBoxDuration"))
                {
                    box.Text = new string(box.Text.Where(char.IsDigit).ToArray());
                }
            }

            uxButtonAddMovie.Enabled = uxTextBoxMovieTitle.TextLength > 0 
                && uxCheckedListBoxMovieGenre.CheckedIndices.Count > 0 
                && uxTextBoxDuration.TextLength > 0 
                && Convert.ToInt32(uxTextBoxDuration.Text) > 0;
        }

        private void uxButtonAddMovie_Click(object sender, EventArgs e)
        {
            string movieTitle = uxTextBoxMovieTitle.Text;
            int movieYear = Convert.ToInt32(uxNumericUpDownYear.Value);
            int movieDuration = Convert.ToInt32(uxTextBoxDuration.Text);
            double movieRating = Convert.ToDouble(uxNumericUpDownRating.Value);

            string movieGenres = "";
            foreach (int indexChecked in uxCheckedListBoxMovieGenre.CheckedIndices)
            {
                movieGenres += (indexChecked + 1).ToString() + ",";
            }
            movieGenres = movieGenres.Remove(movieGenres.Length - 1);
            bool ret = _mwc.checkAddMovie(movieTitle, movieYear);
            if(ret)
            {
                ret = _mwc.AddInventory(movieTitle, movieYear);
            }
            else
            {
                ret = _mwc.AddMovie(movieTitle, movieGenres, movieYear, movieDuration, movieRating);
            }
            if (ret)
                MessageBox.Show("Process Complete.", "Success");
            else
                MessageBox.Show("Process Failed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
