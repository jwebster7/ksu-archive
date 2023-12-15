using PhilsRentals.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhilsRentals
{
    public interface IMainWindowController
    {


        /// <summary>
        /// calls the stored procedure to add a movie to the inventory.
        /// </summary>
        /// <param name="title"></param>
        /// <param name="releaseYear"></param>
        /// <returns></returns>
        bool AddInventory(string title, int releaseYear);

        /// <summary>
        /// checks the database when adding a movie to see if the movie already exists in the database
        /// </summary>
        /// <param name="title"></param>
        /// <param name="releaseYear"></param>
        /// <returns></returns>
        bool checkAddMovie(string title, int releaseYear);

        /// <summary>
        /// used to set up the initial display for the rent movie window
        /// </summary>
        /// <returns></returns>
        List<Movie> initDisp();

        /// <summary>
        /// Adds a movie to the database.
        /// </summary>
        /// <param name="title">Title of the movie</param>
        /// <param name="genres">Genres of the movie</param>
        /// <param name="releaseYear">Release year of the movie</param>
        /// <param name="duration">Duration of the movie</param>
        /// <param name="rating">Rating of the movie</param>
        /// <returns>Whether the movie was added successfully or not</returns>
        bool AddMovie(string title, string genres, int releaseYear, int duration, double rating);

        /// <summary>
        /// Gets the movies based on the filter parameters
        /// </summary>
        /// <param name="genre">Movie genre</param>
        /// <param name="ratingOne">Movie rating</param>
        /// <param name="ratingTwo">Movie rating if user selects a range</param>
        /// <param name="yearOne">Movie year of production; min 1888</param>
        /// <param name="yearTwo">Upper limit for year of production; max 2018</param>
        /// <param name="lengthOne">Lower limit for duration in minutes; min is 1 minute and 40 seconds</param>
        /// <param name="lengthTwo">Upper limit for duration in minutes; max is 1440 minutes</param>
        /// <param name="ratingOperator">Operator for rating; may only be the less than symbol or equals</param>
        /// <param name="yearOperator">Operator for year; may only be the less than symbol or equals</param>
        /// <param name="lengthOperator">Operator for length/duration; may only be the less than symbol or equals</param>
        /// <returns></returns>
        List<Movie> GetMovies(string genre, decimal ratingOne, decimal ratingTwo, decimal yearOne, decimal yearTwo, decimal lengthOne, decimal lengthTwo, string ratingOperator, string yearOperator, string lengthOperator);

        /// <summary>
        /// Create an account in the database.
        /// </summary>
        /// <param name="firstName">First name of the account</param>
        /// <param name="lastName">Last name of the account</param>
        /// <param name="phoneNumber">Phone number of the account</param>
        /// <param name="email">Email address of the account</param>
        /// <returns>Whether the account was added successfully or not</returns>
        bool CreateAccount(string firstName, string lastName, string phoneNumber, string email);

        /// <summary>
        /// Delete an account from the database.
        /// </summary>
        /// <param name="email">Email of the account</param>
        /// <returns>Whether the account was deleted successfully or not</returns>
        bool DeleteAccount(string email);

        /// <summary>
        /// Gets account information for a given email address.
        /// </summary>
        /// <param name="email">Email address</param>
        /// <returns>List of account information</returns>
        string[] GetAccountInformation(string email);

        /// <summary>
        /// Modifys the selected account with the information provided.
        /// </summary>
        /// <param name="email">Modified email address</param>
        /// <param name="phoneNumber">Modified phone number</param>
        /// <param name="firstName">Modified first name</param>
        /// <param name="lastName">Modified last name</param>
        /// <returns>Whether the modification was successful or not</returns>
        bool ModifyAccountInformation(string OldEmail, string NewEmail, string phoneNumber, string firstName, string lastName);


        /// <summary>
        /// Rents a movie for a given account.
        /// </summary>
        /// <param name="email">Email of the account</param>
        /// <param name="movieTitle">Title of movie rented</param>
        /// <returns>Whether the rent movie was successful or not</returns>
        string RentMovie(string email, string movieTitle);

        /// <summary>
        /// Gets the rented movies of an account
        /// </summary>
        /// <param name="email">Email account to get rented movies for</param>
        /// <returns>List of rented movies, rented date and return date</returns>
        List<Movie> GetRentedMovies(string email);

        /// <summary>
        /// Returns a movie for a given account.
        /// </summary>
        /// <param name="email">Email of the account</param>
        /// <param name="movieTitle">Title of the movie returned</param>
        bool ReturnMovie(string email, string movieTitle);
        /// <summary>
        /// Checks to make sure the account exists in the database
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        bool checkSelectedAccount(string email);
    }
}
