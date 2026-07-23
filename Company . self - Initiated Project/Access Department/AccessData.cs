using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Access_Department
{
    public class AccessData
    {
        public static DataTable AllDepartment()
        {
            DataTable Data = new DataTable();
            SqlConnection connection = new SqlConnection(ConnectionStr.ConnectionStringClass.ConnectionString);
            string Query = "Select * From Departments";
            SqlCommand command = new SqlCommand(Query, connection);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    Data.Load(reader);
                }
            }
            catch (Exception Ex)
            {
                Console.WriteLine("Error , " + Ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return Data;
        }
    }
}
