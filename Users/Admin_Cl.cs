using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading;

namespace Users
{
    public class Admin : UserBase
    {
        // Hire New Employee
        public void Hire_Employee()
        {
            bool hiring = true;
            while (hiring)
            {
                Insert();  // Insert Employee Info
                if (User_Name_pro != "" && User_Email_pro != "" && User_Password_pro != "" && User_Role_pro != "" && User_Phone_pro != "")
                {
                    try
                    {
                        con.Open();
                        cmd = new SqlCommand("HireEmployee_Proc", con.sqlconnection);
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlParameter[] param = new SqlParameter[7];
                        param[0] = new SqlParameter("@Employee_FullName", SqlDbType.NVarChar, 100) { Value = User_Name_pro };
                        param[1] = new SqlParameter("@Employee_Email", SqlDbType.NVarChar, 100) { Value = User_Email_pro };
                        param[2] = new SqlParameter("@Employee_Password", SqlDbType.NVarChar, 50) { Value = User_Password_pro };
                        param[3] = new SqlParameter("@Employee_Address", SqlDbType.NVarChar, 100) { Value = User_Address_pro };
                        param[4] = new SqlParameter("@Employee_Gender", SqlDbType.Bit) { Value = User_Gender_pro };
                        param[5] = new SqlParameter("@Employee_Phone", SqlDbType.NVarChar, 40) { Value = User_Phone_pro };
                        param[6] = new SqlParameter("@Employee_Role", SqlDbType.NVarChar, 20) { Value = User_Role_pro };

                        cmd.Parameters.AddRange(param);
                        cmd.ExecuteNonQuery();
                        Console.Clear();
                        Console.WriteLine("********** 🎉 Congratulations new employee added 😎 *********");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(" Something Wrong happened please check it " + ex.Message);
                    }
                    finally
                    {
                        con.Closed();
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("You Should fill these gaps 👉🏻( Name - Email - Password - Role - Phone No )");
                }

                Console.WriteLine("\n1-Hire another Employee\n2-Back");
                int choice = int.Parse(Console.ReadLine());
                if (choice != 1)
                    hiring = false;
            }
        }

        public void Fire_Employee()
        {
            Show_Employees();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("To Fire the employee please enter his ID exactly:  ");
            User_Id_pro = int.Parse(Console.ReadLine());

            if (User_Id_pro != 0)
            {
                try
                {
                    con.Open();
                    cmd = new SqlCommand("Fire_Employee", con.sqlconnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Employee_Id", User_Id_pro);
                    int rows = cmd.ExecuteNonQuery();
                    if (rows > 0)
                        Console.WriteLine("Employee Deleted Successfully ✔ ");
                    else
                        Console.WriteLine("Employee not found.");
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
        }

        public void Show_Employees()
        {
            try
            {
                con.Open();
                cmd = new SqlCommand("Select_Employees_Proc", con.sqlconnection);
                cmd.CommandType = CommandType.StoredProcedure;
                dr = cmd.ExecuteReader();
                Console.WriteLine("-------------   Employee List  ----------");
                while (dr.Read())
                {
                    Console.WriteLine("ID: " + dr["Employee_ID"] + "|  " +
                    "Employee Name: " + dr["Employee_FullName"] + "|  " +
                    "Employee Email: " + dr["Employee_Email"] + "|  " +
                    "Employee Address: " + dr["Employee_Address"] + "|  " +
                    "Employee Gender: " + dr["Employee_Gender"] + "|  " +
                    "Employee Phone: " + dr["Employee_Phone"] + "|  " +
                    "Employee Join Date: " + dr["Employee_JoinDate"] + "|  " +
                    "Role:   " + dr["Role_Name"]);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("There is something happened! " + ex.Message);
            }
            finally
            {
                con.Closed();
            }
        }

        public void Update_Employee()
        {
            Search_Employee();
            if (User_Name_pro != "")
            {
                try
                {
                    Insert(); // Insert the new Data 
                    con.Open();
                    cmd = new SqlCommand("UpdateEmployee_Proc", con.sqlconnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Employee_FullName", User_Name_pro);
                    cmd.Parameters.AddWithValue("@Employee_Email", User_Email_pro);
                    cmd.Parameters.AddWithValue("@Employee_Password", User_Password_pro);
                    cmd.Parameters.AddWithValue("@Employee_Address", User_Address_pro);
                    cmd.Parameters.AddWithValue("@Employee_Gender", User_Gender_pro);
                    cmd.Parameters.AddWithValue("@Employee_Phone", User_Phone_pro);
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("The Employee Info has been Updated");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Failed " + ex.Message);
                }
                finally
                {
                    con.Closed();
                }
            }
        }

        public void Search_Employee()
        {
            Console.Write("Enter Employee Name to Search: ");
            User_Name_pro = Console.ReadLine();
            if (User_Name_pro != "")
            {
                try
                {
                    con.Open();
                    cmd = new SqlCommand("SearchEmployee_Proc", con.sqlconnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@OldName", User_Name_pro);
                    dr = cmd.ExecuteReader();

                    if (dr.HasRows)
                    {
                        Console.WriteLine("\t\t *****  The Employee has found  *****\n\t Enter the new info for the eployee");
                        while (dr.Read())
                        {
                            Console.WriteLine("Employee Name: " + dr["Employee_FullName"] + "| " +
                                "Employee Email:  " + dr["Employee_Email"] + "| " +
                                "Employee Password:  " + dr["Employee_Password"] + "| " +
                                "Employee Address:  " + dr["Employee_Address"] + "| " +
                                "Employee Gender: " + dr["Employee_Gender"] + "| " +
                                "Employee Phone: " + dr["Employee_Phone"]);
                        }
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine("__________--__---- The employee doesn't exist __________--__----");
                        Console.WriteLine("Closing after 5 seconds...");
                        Thread.Sleep(5000);
                        Environment.Exit(0);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error.  " + ex.Message);
                }
                finally
                {
                    con.Closed();
                }
            }
            else
            {
                Console.WriteLine("Please fill User name gaps");
            }
        }

        // Main admin display
        public void AdminMenu()
        {
            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine("** Welcome Admin\n    Chooes Transaction No **");
                Console.WriteLine("1-Hire Employee\n2-Fire Employee\n3-Show Employees\n4-Update Employee\n5-Back");
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1: Hire_Employee(); break;
                    case 2: Fire_Employee(); break;
                    case 3: Show_Employees(); Console.ReadKey(); break;
                    case 4: Update_Employee(); break;
                    case 5: exit = true; break;
                    default: Console.WriteLine("Invalid choice"); break;
                }
            }
        }
    }
}