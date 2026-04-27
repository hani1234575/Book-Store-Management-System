# Book-Store-Management-System
                                    🎉 *Library Management System (C# and SQL Server)*🎉

🎯This project is a console-based Library Management System developed using C# by OOP  and SQL Server, and it is designed to manage books,
employees, and authors through a role-based system. 
The application demonstrates how database operations and object-oriented programming can work together to build a functional system.

Features ❓
The system supports multiple roles where the Admin manages employees by hiring, updating, viewing, and removing them,
while the Employee handles books by adding, searching, and viewing them as well as adding authors,
and the Author can view their own books. In addition, 
the system includes a login mechanism that authenticates users and directs them to the appropriate interface based on their role.

OOP Concepts😍

The project applies encapsulation by using private fields with public properties, inheritance through the UserBase class extended by Admin, Employee, and Author, 
polymorphism using virtual methods like Insert, and abstraction by hiding database operations behind simple menus.
Technologies
The system is built using C# as a console application, SQL Server as the database, ADO.NET for database connectivity, and stored procedures for handling operations.

Setup 🤨

To run the project, clone the repository, open it in Visual Studio, create the BookStorDB database with the required tables and stored procedures,
update the connection string, and then run the application.

Notes 📝

The current version stores passwords as plain text, so it is recommended to improve security by implementing hashing and salting,
 So I put it normal for the people who will install it understand passwords.
The system can also be enhanced by adding a borrowing feature, improving the architecture, and developing a graphical user interface.

 Eng.🖥💻     Hani Ahmed Al-Hussami is an Information Technology student who developed this project as part of his learning journey.📣🏆All thanks dear.
 
