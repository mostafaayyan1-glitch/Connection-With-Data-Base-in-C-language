using System;
using System.ComponentModel.Design;
using System.Data.SqlClient;

internal class Program
{
    static string StringConnection = "Server = . ; DataBase = ContactsDB ; User Id = sa ; Password = 123456;";

    static void PrintAllContactsWithFirstName(string FirstName)
    {
        SqlConnection connection = new SqlConnection(StringConnection);
        string Query = "Select * From Contacts Where FirstName = @FirstName";
        SqlCommand command = new SqlCommand(Query, connection);

        // تصليح: تم حذف المسافة الزائدة من النص
        command.Parameters.AddWithValue("@FirstName", FirstName);

        try
        {
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                int ContactId = (int)reader["ContactId"];
                string firstName = (string)reader["FirstName"];
                string LastName = (string)reader["LastName"];
                string Email = (string)reader["Email"];
                string Phone = (string)reader["Phone"];
                string Address = (string)reader["Address"];
                int CountryId = (int)reader["CountryId"];

                Console.WriteLine($"Contact Id Equal : {ContactId} ");
                Console.WriteLine($"Name       Equal : {firstName} {LastName} ");
                Console.WriteLine($"Email      Equal : {Email} ");
                Console.WriteLine($"Phone      Equal : {Phone} ");
                Console.WriteLine($"Address    Equal : {Address} ");
                Console.WriteLine($"Country Id Equal : {CountryId} ");
                Console.WriteLine();
            }
            reader.Close();
            connection.Close();
        }
        catch (Exception EX)
        {
            Console.WriteLine("Error , " + EX.Message);
        }
    }

    static void PrintAllContactsWithFirstNameAndContryId(string FirstName, int id)
    {
        SqlConnection connection = new SqlConnection(StringConnection);
        string Query = "Select * From Contacts Where FirstName = @FirstName and CountryId = @id";
        SqlCommand command = new SqlCommand(Query, connection);

        command.Parameters.AddWithValue("@FirstName", FirstName);

        command.Parameters.AddWithValue("@id", id);

        try
        {
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                int ContactId = (int)reader["ContactId"];
                string firstName = (string)reader["FirstName"];
                string LastName = (string)reader["LastName"];
                string Email = (string)reader["Email"];
                string Phone = (string)reader["Phone"];
                string Address = (string)reader["Address"];
                int CountryId = (int)reader["CountryId"];

                Console.WriteLine($"Contact Id Equal : {ContactId} ");
                Console.WriteLine($"Name       Equal : {firstName} {LastName} ");
                Console.WriteLine($"Email      Equal : {Email} ");
                Console.WriteLine($"Phone      Equal : {Phone} ");
                Console.WriteLine($"Address    Equal : {Address} ");
                Console.WriteLine($"Country Id Equal : {CountryId} ");
                Console.WriteLine();
            }
            reader.Close();
            connection.Close();
        }
        catch (Exception EX)
        {
            Console.WriteLine("Error , " + EX.Message);
        }
    }

    static void Main(string[] args)
    {
        // تجربة التابع بعد التصليح
        PrintAllContactsWithFirstNameAndContryId("Jane", 1);
        Console.ReadKey();
    }
}