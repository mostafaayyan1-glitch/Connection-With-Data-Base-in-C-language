using System;
using System.Data;
using System.Data.SqlClient;
namespace AccessEmployees
{
    public class AccessData
    {
        public static bool FindEmployees(int id, ref string FirstName,
            ref string LastName, ref string Email, ref string Phone, ref double Salary,
            ref int DepartId, ref string ImagePath, ref DateTime HireDate)
        {
            bool IsFound = false;
            SqlConnection connection = new SqlConnection(ConnectionStr.ConnectionStringClass.ConnectionString);
            string Query = @"SELECT * FROM Employees WHERE EmployeeId = @ID";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@ID", id);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    FirstName = reader["FirstName"] != DBNull.Value ? (string)reader["FirstName"] : "";
                    LastName = reader["LastName"] != DBNull.Value ? (string)reader["LastName"] : "";
                    Email = reader["Email"] != DBNull.Value ? (string)reader["Email"] : "";
                    Phone = reader["Phone"] != DBNull.Value ? (string)reader["Phone"] : "";
                    ImagePath = reader["ImagePath"] != DBNull.Value ? (string)reader["ImagePath"] : "";
                    Salary = Convert.ToDouble(reader["Salary"]);
                    DepartId = reader["DepartId"] != DBNull.Value ? (int)reader["DepartId"] : 0;
                    HireDate = (DateTime)reader["HireDate"];
                    IsFound = true;
                }
            }
            catch (Exception Ex)
            {
                Console.WriteLine("Error , " + Ex.Message);
                IsFound = false;
            }
            finally
            {
                connection.Close();
            }
            return IsFound;
        }
        public static int AddNewEmployees(string FirstName, string LastName, string Email, string Phone,
     double Salary, int DepartId, string ImagePath, DateTime HireDate)
        {
            SqlConnection connection = new SqlConnection(ConnectionStr.ConnectionStringClass.ConnectionString);
            string Query = @"INSERT INTO Employees (FirstName, LastName, Email, Phone, Salary, DepartId, ImagePath, HireDate) 
                     VALUES (@FirstName, @LastName, @Email, @Phone, @Salary, @DepartId, @ImagePath, @HireDate);
                     SELECT SCOPE_IDENTITY();";

            int EmployeeId = -1;
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@FirstName", FirstName);
            command.Parameters.AddWithValue("@LastName", LastName);
            command.Parameters.AddWithValue("@Email", Email);
            command.Parameters.AddWithValue("@Phone", Phone);
            command.Parameters.AddWithValue("@Salary", Salary);
            command.Parameters.AddWithValue("@DepartId", DepartId);
            command.Parameters.AddWithValue("@HireDate", HireDate);
            if (!string.IsNullOrEmpty(ImagePath))
            {
                command.Parameters.AddWithValue("@ImagePath", ImagePath);
            }
            else
            {
                command.Parameters.AddWithValue("@ImagePath", System.DBNull.Value);
            }
            try
            {
                connection.Open();
                object Result = command.ExecuteScalar();
                if (Result != null && int.TryParse(Result.ToString(), out int Id))
                {
                    EmployeeId = Id;
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
            return EmployeeId;
        }
        public static bool UpdateEmployees(int EmployeeId, string FirstName, string LastName, string Email,
            string Phone, double Salary, int DepartId, DateTime HireDate, string ImagePath)
        {
            SqlConnection connection = new SqlConnection(ConnectionStr.ConnectionStringClass.ConnectionString);
            string Query = @"Update Employees Set 
                             FirstName = @FirstName , LastName = @LastName , 
                             Email = @Email , Phone = @Phone , Salary = @Salary ,
                             ImagePath = @ImagePath,
                             DepartId = @DepartmentId , HireDate = @HireDate where EmployeeId = @EmployeeId";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue(@"EmployeeId", EmployeeId);
            command.Parameters.AddWithValue(@"FirstName", FirstName);
            command.Parameters.AddWithValue(@"LastName", LastName);
            command.Parameters.AddWithValue(@"Email", string.IsNullOrEmpty(Email) ? DBNull.Value : (object)Email);
            command.Parameters.AddWithValue(@"Phone", string.IsNullOrEmpty(Phone) ? DBNull.Value : (object)Phone);
            command.Parameters.AddWithValue(@"ImagePath", string.IsNullOrEmpty(ImagePath) ? DBNull.Value : (object)ImagePath);
            command.Parameters.AddWithValue(@"DepartmentId", DepartId);
            command.Parameters.AddWithValue(@"HireDate", HireDate);
            command.Parameters.AddWithValue("Salary", Salary);
            int Rows = 0;
            try
            {
                connection.Open();
                Rows = command.ExecuteNonQuery();
            }
            catch (Exception EX)
            {
                Console.WriteLine("Error , " + EX.Message);
            }
            finally
            {
                connection.Close();
            }
            return Rows > 0;
        }
        public static bool DeleteEmployees(int Id)
        {
            int Rows = 0;
            SqlConnection connection = new SqlConnection(ConnectionStr.ConnectionStringClass.ConnectionString);
            string Query = @"Delete From Employees Where EmployeeId = @Id ";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue(@"Id", Id);
            try
            {
                connection.Open();
                Rows = command.ExecuteNonQuery();
            }
            catch (Exception EX)
            {
                Console.WriteLine("Error , " + EX.Message);
            }
            finally
            {
                connection.Close();
            }
            return Rows > 0;
        }
        public static DataTable GetAllEmployees()
        {
            DataTable dataTable = new DataTable();
            SqlConnection connection = new SqlConnection(ConnectionStr.ConnectionStringClass.ConnectionString);
            string Query = "Select * From Employees";
            SqlCommand command = new SqlCommand(Query, connection);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    dataTable.Load(reader);
                }
                reader.Close();
            }
            catch (Exception Ex)
            {
                Console.WriteLine("Error , " + Ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return dataTable;
        }
        public static bool IsExist(int Id)
        {
            bool IsFound = false;
            SqlConnection connection = new SqlConnection(ConnectionStr.ConnectionStringClass.ConnectionString);
            string Query = @"Select Found = 1 From Employees Where EmployeeId = @Id";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue(@"Id", Id);
            try
            {
                connection.Open();
                object Result = command.ExecuteScalar();
                IsFound = (Result != null);
            }
            catch (Exception Ex)
            {
                Console.WriteLine("Error ," + Ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return IsFound;
        }
        public static bool IsEmailExist(string  Email , int Id)
        {
            bool IsFound = false;
            SqlConnection connection = new SqlConnection(ConnectionStr.ConnectionStringClass.ConnectionString);
            string Query = @"Select Found = 1 From Employees Where Email = @Email And EmployeeId != @ID";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue(@"Email", Email);
            command.Parameters.AddWithValue(@"ID", Id);
            try
            {
                connection.Open();
                object Result = command.ExecuteScalar();
                IsFound = (Result != null);
            }
            catch (Exception Ex)
            {
                Console.WriteLine("Error , "+ Ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return IsFound;
        }
    }
} 