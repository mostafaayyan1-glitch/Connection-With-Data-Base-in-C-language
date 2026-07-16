using System;
using System.Data.SqlClient;
internal class Program
    {
    static string stringConnection = "Server = . ; DataBase = ContactsDB ; User Id = sa ; Password = 123456;";
    static string GitFirstName (int ContactId)
    {
        string FirstName = "";
        SqlConnection connection = new SqlConnection(stringConnection);
        string Query = "Select FirstName From Contacts Where ContactId = @ContactId";
        SqlCommand command = new SqlCommand(Query, connection);
        command.Parameters.AddWithValue("@ContactId", ContactId);
        try
        {
            connection.Open();
            object Result = command.ExecuteScalar();
            if(Result != null)
            {
                FirstName = Result.ToString();
            }
            else
            {
                FirstName = "";
            }
            connection.Close();
        }
        catch(Exception Ex)
        {
            Console.WriteLine("Error , " + Ex.Message);
        }
        return FirstName;
    }
        static void Main(string[] args)
        {
        Console.WriteLine(GitFirstName(4));
        Console.ReadKey();
        }
    }