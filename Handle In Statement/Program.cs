using System;
using System.Data.SqlClient;
internal class Program
{
    // Database connection string
    static string StringConnection = "Server = .; DataBase = ContactsDB; User Id = sa ; Password = 123456;";
    // Method to safely delete multiple contacts using a secure dynamic parameterized IN clause
    static void DeleteContactsWith_In(string ContactsId)
    {
        // Split the comma-separated string into an array of individual IDs
        string[] idList = ContactsId.Split(',');
        SqlConnection connection = new SqlConnection(StringConnection);
        SqlCommand command = new SqlCommand();
        command.Connection = connection;
        // Dynamically build individual parameters to avoid SQL Injection completely
        string[] parameterNames = new string[idList.Length];
        for (int i = 0; i < idList.Length; i++)
        {
            parameterNames[i] = "@Id" + i;
            // Trim whitespace and bind each ID securely as a separate parameter
            command.Parameters.AddWithValue(parameterNames[i], idList[i].Trim());
        }
        // Construct the final secure query: Delete from Contacts where ContactId in (@Id0, @Id1, @Id2)
        command.CommandText = $"Delete from Contacts where ContactId in ({string.Join(",", parameterNames)})";
        try
        {
            connection.Open();
            int RowsAffected = command.ExecuteNonQuery();

            if (RowsAffected > 0)
            {
                Console.WriteLine($"{RowsAffected} Record(s) Deleted Successfully");
            }
            else
            {
                Console.WriteLine("Delete Failed: No matching IDs found.");
            }
        }
        catch (Exception Ex)
        {
            Console.WriteLine("Error , " + Ex.Message);
        }
        finally
        {
            // Structural Resource Management: Ensures connection closure under any runtime scenario
            if (connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
            }
        }
    }
    static void Main(string[] args)
    {
        // Testing the secure mass-deletion on IDs 6, 7, and 8
        DeleteContactsWith_In("6,7,8");
        Console.ReadKey();
    }
}