using System;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using Main_namespace;
using BookStore;
namespace Users
{
    public class Login
    {
        DataBase_Connection con = new DataBase_Connection();
        SqlCommand cmd;
        SqlDataReader dr;

        private string email,  name , password;

       
        public void Start()
        {
            Console.WriteLine("1- Login (already have account)\n2- Sign Up (I don't have an account)");
            Console.Write("Enter Process No (1-2): ");
            int process = int.Parse(Console.ReadLine());
            if (process == 1)
                LoginUser();
            else if (process == 2)
                SignUp();
            else
                Console.WriteLine("Invalid choice.");
        }

        private void SignUp()
        {
            Console.Write("Enter Name: ");
            name = Console.ReadLine();
            Console.Write("Enter Email: ");
            email = Console.ReadLine();
            Console.Write("Enter Password: ");
            password = Console.ReadLine();

            try
            {
                con.Open();
                cmd = new SqlCommand("SignUp_Proc", con.sqlconnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Password", password);


                cmd.ExecuteNonQuery();
                Console.WriteLine("Account created successfully. You can login now.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Sign up failed: " + ex.Message);
            }
            finally
            {
                con.Closed();
            }
        }

        // قائمة العميل (Customer)
        private void CustomerMenu()
        {
            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("\tWelcome, Customer\n * Choose Transaction No *");
                Console.WriteLine("1-Show Books\n2-Rent Book\n3-Back");
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Books b = new Books();
                        b.Show_Books();
                        Console.ReadKey();
                        break;
                    case 2:
                        RentBook();
                        break;
                    case 3:
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid number.");
                        break;
                }
            }
        }

        // استئجار كتاب (تسجيل عملية استئجار في قاعدة البيانات)
        private void RentBook()
        {
            Console.Write("Enter Book Title to Rent: ");
            string bookTitle = Console.ReadLine();
            Console.Write("Enter Your Name: ");
            string customerName = Console.ReadLine();

            if (bookTitle != "" && customerName != "")
            {
                try
                {
                    con.Open();
                    cmd = new SqlCommand("RentBook_Proc", con.sqlconnection); // يجب أن يكون لديك إجراء مخزن بهذا الاسم
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Book_Title", bookTitle);
                    cmd.Parameters.AddWithValue("@Customer_Name", customerName);
                    int rows = cmd.ExecuteNonQuery();
                    if (rows > 0)
                        Console.WriteLine("Book rented successfully! 🎉");
                    else
                        Console.WriteLine("Sorry, this book is not available or not found.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
                finally
                {
                    con.Closed();
                }
            }
            else
            {
                Console.WriteLine("Please fill both fields.");
            }
            Console.ReadKey();
        }

        private void LoginUser()
        {
            Console.Write("Please Enter Your Email:  ");
            email = Console.ReadLine();
            Console.Write("Please Enter Your Password:  ");
            password = Console.ReadLine();

            if (email != "" && password != "")
            {
                try
                {
                    con.Open();
                    cmd = new SqlCommand("Login_Proc", con.sqlconnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Password", password);
                    dr = cmd.ExecuteReader();

                    if (dr.HasRows)
                    {
                        dr.Read();
                        string role = dr["Role_Name"].ToString();
                        dr.Close();
                        con.Closed();

                        // توجيه حسب الدور
                        if (role == "Admin")
                        {
                            Admin admin = new Admin();
                            admin.AdminMenu();
                        }
                        else if (role == "Employee")
                        {
                            Employee emp = new Employee();
                            emp.EmployeeMenu();
                        }
                        else if (role == "Author")
                        {
                            Author aut = new Author();
                            aut.AuthorMenu();
                        }
                        else if (role == "Customer")
                        {
                            CustomerMenu();
                        }
                        else
                        {
                            Console.WriteLine("Unknown role.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("User Name Or Password is invalid");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error, " + ex.Message);
                }
                finally
                {
                    con.Closed();
                }
            }
            else
            {
                Console.WriteLine("Please fill gaps");
            }
        }
    }


}
