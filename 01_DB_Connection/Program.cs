using System;
using System.Data.SqlClient;
using System.IO;
internal class Program
{
    static string StringConnection = "Server = . ; DataBase = ContactsDB ; User Id = sa ; Password = 123456;";
    static void Print_All_ContactInfo()
    {
        try
        {
            SqlConnection connection = new SqlConnection(StringConnection);
            string Query = "Select * From Contacts " +
                " Where ContactId in ( 1 , 3 , 4 )";
            SqlCommand command = new SqlCommand(Query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                int ContactId = (int)reader["ContactId"];
                string FirstName = (string)reader["FirstName"];
                string LastName = (string)reader["LastName"];
                string Email = (string)reader["Email"];
                string Phone = (string)reader["Phone"];
                string Address = (string)reader["Address"];
                int CountryId = (int)reader["CountryId"];
                // Print 
                Console.WriteLine($"Contact Id : {ContactId} ");
                Console.WriteLine($"Name       : {FirstName} {LastName} ");
                Console.WriteLine($"Email      : {Email} ");
                Console.WriteLine($"Phone      : {Phone} ");
                Console.WriteLine($"Address    : {Address} ");
                Console.WriteLine($"Country Id : {CountryId} ");
                Console.WriteLine();
            }
            reader.Close();
            connection.Close();
        }
        catch(Exception EX)
        {
            Console.WriteLine("Error ," + EX.Message);
        }
    }
    static void Main(string[] args)
    {
        Print_All_ContactInfo();
        Console.ReadKey();
    }
}