# cis-560-group13
This repo is for Group 13's CIS 560/Databases Project.

***Do Not Copy:*** **This is solely for record keeping and presentation of prior experience. If used for personal use, please reference. If used for academic purposes, verify with the primary instructor before use and reference if applicable.** 


## Summary
  This program will simulate a movie rental business interface. Our program will help employees track employee rentals. 
It's primary design aspects will include the following: 
  
  * A working MSSQL Database to house and record rentals and employee accounts.
  * A working user interface written in C# which will implement SQL commands linked to client-called functions.
  * An active inventory of all movies with necessary and supplemental information. 
  
## Relation and Data Interactions
**[Relation (column 1, column 2, ..., column 'n') : Data Interactions]**

  * MovieGenre (MovieGenreID, MovieGenreName) : SELECT
    UniqueKey (MovieGenreName)
  * Movie (MovieID, MovieTitle, MovieGenre, ReleaseDate, Duration, MovieParentalRatings) : SELECT, INSERT, DELETE
  * Inventory (InventoryID, MovieID, RentalID) : INSERT, SELECT, UPDATE, DELETE
    UniqueKey (InventoryID, RentalID)
  * Rental (RentalID, AccountID, InventoryID, DateRented, DueDate) : INSERT, SELECT, DELETE
    UniqueKey (AccountID, InverntoryID)
  * Account (AccountID, FirstName, LastName, Phone, Email) : SELECT, INSERT, UPDATE, DELETE
    UniqueKey (Phone, Email)
