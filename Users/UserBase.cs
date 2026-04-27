using System;
using System.Data;
using System.Data.SqlClient;
using Main_namespace;

namespace Users
{
    public class UserBase
    {
        protected DataBase_Connection con = new DataBase_Connection();
        protected SqlCommand cmd;
        protected SqlDataReader dr;

        // Perliminary Fields
        private int User_Id;
        private string User_Name;
        private string User_Email;
        private string User_Password;
        private string User_Address;
        private int User_Gender;
        private string User_Role;
        private string User_Phone;

        public int User_Id_pro { get => User_Id; set => User_Id = value; }
        public string User_Name_pro { get => User_Name; set => User_Name = value; }
        public string User_Email_pro { get => User_Email; set => User_Email = value; }
        public string User_Password_pro { get => User_Password; set => User_Password = value; }
        public string User_Address_pro { get => User_Address; set => User_Address = value; }
        public int User_Gender_pro { get => User_Gender; set => User_Gender = value; }
        public string User_Role_pro { get => User_Role; set => User_Role = value; }
        public string User_Phone_pro { get => User_Phone; set => User_Phone = value; }

        // An Input Method. ( Reusable )
        public virtual void Insert()
        {
            Console.Write("Enter Name: ");
            User_Name_pro = Console.ReadLine();
            Console.Write("Enter Email: ");
            User_Email_pro = Console.ReadLine();
            Console.Write("Enter Password: ");
            User_Password_pro = Console.ReadLine();
            Console.Write("Enter Address: ");
            User_Address_pro = Console.ReadLine();
            Console.Write("Enter Gender( 1 = Male, 0= Female):  ");
            User_Gender_pro = int.Parse(Console.ReadLine());
            Console.Write("Enter Role: ");
            User_Role_pro = Console.ReadLine();
            Console.Write("Enter Phone: ");
            User_Phone_pro = Console.ReadLine();

            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.DarkBlue;
        }

        public virtual void Print()
        {
            Console.WriteLine("User Name: {0}\nUser Email: {1}\nUser Password: {2}\nUser Address: {3}\nUser Gender: {4}\nUser Role: {5}\nPhone: {6}",
                User_Name_pro, User_Email_pro, User_Password_pro, User_Address_pro, User_Gender_pro, User_Role_pro, User_Phone_pro);
        }
    }
}
