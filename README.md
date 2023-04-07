# Emergency Services Management System: A C# Command Line Program with SQL Database Integration

This program is designed to get user information, validate it, show reports, and store it in a SQL Server database. The program is focused on emergency services and has several options for users to choose from.
## Validation of User Input
The program checks the following information for validation:
1. Name: Only letters are allowed
2. Gender: Only 0 (male), 1 (female), or 2 (other) are allowed
3. Identity Number: Must be ten numbers
4. Address: Only letters are allowed
## Main Menu Options
The main menu options for the program are:
1. Thief
2. Fire
3. Hard to Breath
4. History
5. Exit


Users can select options 1-3 as many times as they want, and all transactions will be stored in a table called "histories." The program uses the **command design pattern** to contact each department when a user reports an emergency.
## History Reports
When a user selects "History" from the main menu, these reports type pop up:
1. Show all services
2. Show fire stain service
3. Show ambulance service
4. Police service for man
5. Police service for woman 


After choosing any report type, the program will query the database based on what the user wants, then show records on the command line and return to the main menu.
## Implementation
The program is implemented in the command line or CLI. If a user wants to use and run the program, they will need to change the file name from **"app. config"** and modify the **"Server"** and **"Database"** variables accordingly. The program has been tested, and there are no known issues, but if any errors occur, please note them and report them.
## Libraries Used
The following libraries were used in the program:  
- System.Configuration.ConfigurationManager (version 7.0.0)  
- System.Data.SqlClient (version 4.8.5)
## OutPut
![](https://github.com/hoco1/Emergency-Services/blob/master/Media/OutPut.gif)
