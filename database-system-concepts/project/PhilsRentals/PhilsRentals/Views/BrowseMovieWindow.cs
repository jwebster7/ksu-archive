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
    public enum OperatorValue
    {
        Equals = '=',
        LessThan = '<'
    };

    public partial class BrowseMovieWindow : UserControl
    {
        /// <summary>
        /// Handle to the MainWindowController.
        /// </summary>
        IMainWindowController _mwc;

        /// <summary>
        /// The movie genre
        /// </summary>
        private string _genre = "";

        /// <summary>
        /// The (lower) rating of th0e movie
        /// </summary>
        private decimal _rating;
        
        /// <summary>
        /// The (higher) rating of the movie 
        /// </summary>
        private decimal _ratingTwo;

        /// <summary>
        /// The (lower) year the movie came out
        /// </summary>
        private decimal _year;

        /// <summary>
        /// The (higher) value of the year
        /// </summary>
        private decimal _yearTwo;

        /// <summary>
        /// The duration/length of the movie in minutes
        /// </summary>
        private decimal _length;

        /// <summary>
        /// The (higher) duration/length of the movie in minutes
        /// </summary>
        private decimal _lengthTwo;

        /// <summary>
        /// The operator for rating
        /// </summary>
        private string _ratingOperator;

        /// <summary>
        /// The operator for year
        /// </summary>
        private string _yearOperator;

        /// <summary>
        /// The operator for duration/length
        /// </summary>
        private string _lengthOperator;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="mwc">Delegate to handle operations</param>
        public BrowseMovieWindow(IMainWindowController mwc)
        {
            InitializeComponent();
            _mwc = mwc;
            uxButtonGetMovie.Enabled = false;
        }

        /// <summary>
        /// References StoredProcedures -> allFilters
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxButtonGetMovie_Click(object sender, EventArgs e)
        {
            List<Movie> movies = new List<Movie>();
            _genre = uxCheckedListBoxMovieGenre.SelectedItem.ToString();
            _genre = _genre.Substring(_genre.IndexOf("(") +1, _genre.IndexOf(")")-_genre.IndexOf("(") -1);
            _rating = uxNumericUpDownRating.Value;
            _ratingTwo = uxNumericUpDownRatingTwo.Value;
            _year = uxNumericUpDownYear.Value;
            _yearTwo = uxNumericUpDownYearTwo.Value;
            _length = uxNumericUpDownDuration.Value;
            _lengthTwo = uxNumericUpDownDurationTwo.Value;
            _ratingOperator = uxNumericUpDownRatingOperator.Text;
            _yearOperator = uxNumericUpDownYearOperator.Text;
            _lengthOperator = uxNumericUpDownDurationOperator.Text;
            // send the fields to the database to get the movies where the conditions are met.
            movies = _mwc.GetMovies(_genre, _rating, _ratingTwo, _year, _yearTwo, _length, _lengthTwo, _ratingOperator, _yearOperator, _lengthOperator);
            uxDataGridViewMovies.Rows.Clear();
            foreach (Movie movie in movies)
            {
                uxDataGridViewMovies.Rows.Add(movie.Title, movie.rating, movie.genre, movie.releaseYear, movie.length);
            }
            uxDataGridViewMovies.ClearSelection();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxCheckedListBoxMovieGenre_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            for (int i = 0; i < uxCheckedListBoxMovieGenre.Items.Count; ++i)
            {
                if (i != e.Index)
                {
                    uxCheckedListBoxMovieGenre.SetItemChecked(i, false);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxCheckedListBoxMovieGenre_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (uxCheckedListBoxMovieGenre.CheckedItems.Count > 0)
            {
                uxButtonGetMovie.Enabled = true;
            }
            // need to add more cases here 
            else
            {
                uxButtonGetMovie.Enabled = false;
            }
        }

        #region OperatorLogic
        /// <summary>
        /// Sets the value of the "two" numeric updowns.
        /// </summary>
        /// <param name="current_operator"></param>
        private void SetUpperRangeValue(string current_operator, ref NumericUpDown upper, ref NumericUpDown lower)
        {
            if (current_operator.Equals("="))
            {
                upper.Value = lower.Value;
                upper.Enabled = false;
            }
            else
            {
                upper.Enabled = true;
                upper.Value = lower.Value + 1;
            }
        }

        /// <summary>
        /// Takes in the current operator value and sets it to the next possible value.
        /// </summary>
        /// <param name="current_operator"></param>
        /// <returns></returns>
        private string SetOperatorValue(string current_operator)
        {
            if (current_operator.Equals("="))
            {
                return "<";
            }
            else
            {
                return "=";
            }
        }
        #endregion

        #region Rating
        /// <summary>
        /// Handles changing the operator displayed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxNumericUpDownRatingOperator_Click(object sender, EventArgs e)
        {
            string operate = SetOperatorValue(uxNumericUpDownRatingOperator.Text);
            uxNumericUpDownRatingOperator.Text = operate;
            SetUpperRangeValue(operate, ref uxNumericUpDownRatingTwo, ref uxNumericUpDownRating);
        }

        /// <summary>
        /// Tracks the changing value of uxNumericUpDownRating.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxNumericUpDownRating_ValueChanged(object sender, EventArgs e)
        {
            if (uxNumericUpDownRatingOperator.Text.Equals("="))
            {
                uxNumericUpDownRatingTwo.Value = uxNumericUpDownRating.Value;
            }
            else
            {
                uxNumericUpDownRatingTwo.Value = uxNumericUpDownRating.Value + 1;
            }
        }
        #endregion

        #region Year
        /// <summary>
        /// Handles changing the operator displayed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxNumericUpDownYearOperator_Click(object sender, EventArgs e)
        {
            string operate = SetOperatorValue(uxNumericUpDownYearOperator.Text);
            uxNumericUpDownYearOperator.Text = operate;
            SetUpperRangeValue(operate, ref uxNumericUpDownYearTwo, ref uxNumericUpDownYear);
        }

        /// <summary>
        /// Tracks the changing value of uxNumericUpDownYear.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxNumericUpDownYear_ValueChanged(object sender, EventArgs e)
        {
            if (uxNumericUpDownYearOperator.Text.Equals("="))
            {
                uxNumericUpDownYearTwo.Value = uxNumericUpDownYear.Value;
            }
            else
            {
                uxNumericUpDownYearTwo.Value = uxNumericUpDownYear.Value + 1;
            }
        }
        #endregion

        #region Length/Duration
        /// <summary>
        /// Handles changing the operator displayed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxNumericUpDownDurationOperator_Click(object sender, EventArgs e)
        {
            string operate = SetOperatorValue(uxNumericUpDownDurationOperator.Text);
            uxNumericUpDownDurationOperator.Text = operate;
            SetUpperRangeValue(operate, ref uxNumericUpDownDurationTwo, ref uxNumericUpDownDuration);
        }

        private void uxNumericUpDownDuration_ValueChanged(object sender, EventArgs e)
        {
            if (uxNumericUpDownDurationOperator.Text.Equals("="))
            {
                uxNumericUpDownDurationTwo.Value = uxNumericUpDownDuration.Value;
            }
            else
            {
                uxNumericUpDownDurationTwo.Value = uxNumericUpDownDuration.Value + 1;
            }
        }

        #endregion

    }// end class
}
