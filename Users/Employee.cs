using System;
using System.Data;
using System.Data.SqlClient;
using BookStore;

namespace Users
{
    public class Employee : UserBase
    {
        //Enter new Book
        private void EnterBookDetails()
        {
            Console.Write("Enter Book Title: ");
            Book_Title_pro = Console.ReadLine();
            Console.Write("Enter Book ISBN: ");
            Book_ISBN_pro = Console.ReadLine();
            Console.Write("Enter Copies Available: ");
            Copies_Available_pro = int.Parse(Console.ReadLine());
            Console.Write("Enter Author Name: ");
            Author_Name_pro = Console.ReadLine();
            Console.Write("Enter Publisher Name: ");
            Publisher_Name_pro = Console.ReadLine();
            Console.Write("Enter Category Name: ");
            Category_Name_pro = Console.ReadLine();
        }

     // Fields for insert a book
        private string Book_Title;
        private string Book_ISBN;
        private int Copies_Available;
        private string Author_Name;
        private string Publisher_Name;
        private string Category_Name;

        public string Book_Title_pro { get { return Book_Title; } set { Book_Title = value; } }
        public string Book_ISBN_pro { get { return Book_ISBN; } set { Book_ISBN = value; } }
        public int Copies_Available_pro { get { return Copies_Available; } set { Copies_Available = value; } }
        public string Author_Name_pro { get { return Author_Name; } set { Author_Name = value; } }
        public string Publisher_Name_pro { get { return Publisher_Name; } set { Publisher_Name = value; } }
        public string Category_Name_pro { get { return Category_Name; } set { Category_Name = value; } }

        public void Insert_Books()
        {
            EnterBookDetails();

            if (Book_Title_pro != "" && Book_ISBN_pro != "" && Copies_Available_pro != 0 &&
                Author_Name_pro != "" && Publisher_Name_pro != "" && Category_Name_pro != "")
            {
                try
                {
                    con.Open();
                    cmd = new SqlCommand("Insert_Book_Proc", con.sqlconnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Title_Book", Book_Title_pro);
                    cmd.Parameters.AddWithValue("@Book_ISBN", Book_ISBN_pro);
                    cmd.Parameters.AddWithValue("@CopiesAvailable", Copies_Available_pro);
                    cmd.Parameters.AddWithValue("@Author_Name", Author_Name_pro);
                    cmd.Parameters.AddWithValue("@Publisher_Name", Publisher_Name_pro);
                    cmd.Parameters.AddWithValue("@Category_Name", Category_Name_pro);
                    cmd.ExecuteNonQuery();
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("🎉 Added a new book successfully");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Cannot added: " + ex.Message);
                }
                finally
                {
                    con.Closed();
                }
            }
            else
            {
                Console.WriteLine("Please fill all book data.");
            }
        }

        public void Add_Author()
        {
            Console.Write("Enter Author Name: ");
            User_Name_pro = Console.ReadLine();
            Console.Write("Enter Author Email: ");
            User_Email_pro = Console.ReadLine();
            Console.Write("Enter Author Password: ");
            User_Password_pro = Console.ReadLine();

            if (User_Name_pro != "" && User_Password_pro != "" && User_Email_pro != "")
            {
                try
                {
                    con.Open();
                    cmd = new SqlCommand("InsertAuthor_Proc", con.sqlconnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Author_Name", User_Name_pro);
                    cmd.Parameters.AddWithValue("@Author_Email", User_Email_pro);
                    cmd.Parameters.AddWithValue("@Author_Password", User_Password_pro);
                    cmd.ExecuteNonQuery();
                    Console.WriteLine(" New Author has been added successfully 🎯");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error please check it " + ex.Message);
                }
                finally
                {
                    con.Closed();
                }
            }
            else
            {
                Console.WriteLine("Please fill these gaps 👉🏻 ( Author Name - Author Email - Author Password )");
            }
        }

        public void Search_Books()
        {
            Console.Write("Enter Book Title: ");
            Book_Title_pro = Console.ReadLine();
            if (Book_Title_pro != "")
            {
                try
                {
                    con.Open();
                    cmd = new SqlCommand("Search_Book_Proc", con.sqlconnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Book_Title", Book_Title_pro);
                    dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            Console.WriteLine("Book Title: " + dr["Book_Title"] + "|  " +
                                "Book ISBN: " + dr["Book_ISBN"] + "|  " +
                                "Copies Available: " + dr["CopiesAvailable"] + "|  " +
                                "Author ID: " + dr["Author_ID"] + "|  " +
                                "Publisher ID: " + dr["publisher_ID"] + "|  " +
                                "Category ID: " + dr["Category_ID"]);
                        }
                    }
                    else
                    {
                        Console.WriteLine("The book not found");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    con.Closed();
                }
            }
        }

        // Show Books from Books Class
        public void Show_All_Books()
        {
            Books b = new Books();
            b.Show_Books();
        }

        //Employee permoission
        public void EmployeeMenu()
        {
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("\tWelcome, Employee\n * Chooes Transaction No *");
                Console.WriteLine("1-Show Books\n2-Publish Book\n3-Add Author\n4-Search Books\n5-Back");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1: Show_All_Books(); Console.ReadKey(); break;
                    case 2: Insert_Books(); break;
                    case 3: Add_Author(); break;
                    case 4: Search_Books(); Console.ReadKey(); break;
                    case 5: exit = true; break;
                    default: Console.WriteLine("Invalid number."); break;

                }

            }
        }
    }
}

