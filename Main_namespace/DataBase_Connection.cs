using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace Main_namespace{
  public class DataBase_Connection
    {
        public SqlConnection sqlconnection;
        public DataBase_Connection()
        {
            sqlconnection = new SqlConnection(@"server = DESKTOP-QSUN0UI; database = BookStorDB; integrated security= true;");

        }
        public void Open()
        {
            if(sqlconnection.State != ConnectionState.Open)
            {
                sqlconnection.Open();
            }
        }
        public void Closed()
        {
            if(sqlconnection.State != ConnectionState.Closed)
            {
                sqlconnection.Close();
            }
        }

    }
}
