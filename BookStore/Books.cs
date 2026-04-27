
using System;
using System.Data;
using System.Data.SqlClient;
using Main_namespace;
namespace BookStore
{
    public class Books
    {
        DataBase_Connection con = new DataBase_Connection();
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dr;

        public void Show_Books()
        {
            try
            {
                con.Open();
                cmd = new SqlCommand("Show_Books_Proc", con.sqlconnection);
                cmd.CommandType = CommandType.StoredProcedure;
                dr = cmd.ExecuteReader();

                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("\n\t\t----------------------------------------   Books List  ----------------------------------------\n");
                while (dr.Read())
                {
                    Console.WriteLine(" Book Name: " + dr["Book_Title"] + "| " +
                                      " Book ISBN: " + dr["Book_ISBN"] + "| " +
                                      " Copies Availabe: " + dr["CopiesAvailable"] + "| " +
                                      " Author Name: " + dr["Author_Name"] + "|" +
                                      " Publisher Name: " + dr["Publisher_Name"] + "| " +
                                      " Category Name: " + dr["Category_Name"] + "| ");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error 👉🏻 " + ex.Message);
            }
            finally
            {
                con.Closed();
            }
        }
    }
}