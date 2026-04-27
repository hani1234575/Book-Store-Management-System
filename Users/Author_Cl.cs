using System;
using System.Data;
using System.Data.SqlClient;

namespace Users
{
    public class Author : UserBase
    {
        public void ShowAuthor_Books()
        {
            try
            {
                Console.Write("Enter Your Name: ");
                string authorName = Console.ReadLine();
                con.Open();
                cmd = new SqlCommand("ShowAuthors_Book", con.sqlconnection);
                cmd.Parameters.AddWithValue("@Author_Name", authorName);
                cmd.CommandType = CommandType.StoredProcedure;
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\n-------------------- Your Books--------------------------");
                    while (dr.Read())
                    {
                        Console.WriteLine("Book Title: " + dr["Book_Title"] + "|  " +
                            "Book ISBN: " + dr["Book_ISBN"] + "|  " +
                            "Author Name: " + dr["Author_Name"] + "|  " +
                            "Publish Name: " + dr["Publisher_Name"] + "|  " +
                            "Category: " + dr["Category_Name"] + "|  ");
                    }
                }
                else
                {
                    Console.WriteLine("The Author Name Wrong");
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

        // Author Permission
        public void AuthorMenu()
        {
            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("\tWelcome, Author\n * Chooes Transaction No *");
                Console.WriteLine("1-Show Your Books\n2-Back");
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1: ShowAuthor_Books(); Console.ReadKey(); break;
                    case 2: exit = true; break;
                    default: Console.WriteLine("Invalid number."); break;
                }
            }
        }
    }
}
