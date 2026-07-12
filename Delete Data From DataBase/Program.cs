using System;
using System.Data.SqlClient;
internal class Program
{
    // Database connection string
    static string StringConnection = "Server = . ; DataBase = ContactsDB; User Id = sa; Password = 123456;";
    // Method to safely delete a contact record by its Unique ID
    static void Delete_Data(int ContactId)
    {
        SqlConnection connection = new SqlConnection(StringConnection);
        string Query = @"Delete From Contacts Where ContactId = @ContactId";
        SqlCommand command = new SqlCommand(Query, connection);
        // Defensive Parameter mapping to eliminate SQL Injection risks
        command.Parameters.AddWithValue("@ContactId", ContactId);
        try
        {
            connection.Open();
            // ExecuteNonQuery is used as DELETE alters state without returning rows
            int RowsEffected = command.ExecuteNonQuery();

            if (RowsEffected > 0)
            {
                Console.WriteLine("Delete successful");
            }
            else
            {
                // Triggered if the execution succeeded but the ID was not found
                Console.WriteLine("Failed Delete: Contact ID does not exist.");
            }
            connection.Close();
        }
        catch (Exception Ex)
        {
            Console.WriteLine("Error, " + Ex.Message);
        }
    }
    static void Main(string[] args)
    {
        // Testing the delete functionality on Contact ID 12
        Delete_Data(12);
        Console.ReadKey();
    }
}