using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 1- User enter login and password 
   if he was an author give him publish promission, if he was an Employee give him Books Control. if he was an admin give him Employee control
2- Author can publish books.
3-Employee can add users, delete users, Delete books
4-Admin can add new Employee, delete employee.
5- customers barrow books or buy them.
 */
namespace BookStore
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Books b = new Books();
            b.Show_Books();
            Console.ReadKey();
        }
    }
}
