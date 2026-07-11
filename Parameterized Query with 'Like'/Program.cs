using System;
using System.Data.SqlClient;
using System.IO;
using System.Net.Http.Headers;
internal class Program
    {
    static string StringConnection = "Server = .; DataBase = ContactsDB ; User Id = sa ; Password = 123456;";
    static void SearchConatactsStartWiht(string StartWith)
    {
        SqlConnection connection = new SqlConnection(StringConnection);
        string Query = "Select * From Contacts Where FirstName Like '' + @StartWith + '%'";
        SqlCommand command = new SqlCommand(Query, connection);
        command.Parameters.AddWithValue("@startWith", StartWith);
        try
        {
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
                Console.WriteLine($"Contact Id : {ContactId}");
                Console.WriteLine($"Name       : {FirstName} {LastName}");
                Console.WriteLine($"Email      : {Email}");
                Console.WriteLine($"Phone      : {Phone}");
                Console.WriteLine($"Address    : {Address}");
                Console.WriteLine($"Country Id : {CountryId}");
                Console.WriteLine();
            }
            reader.Close();
            connection.Close();
        }
        catch(Exception EX)
        {
            Console.WriteLine("Error , " + EX.Message);
        }
    }
    static void SearchConatactsEndWiht(string EndWith)
    {
        SqlConnection connection = new SqlConnection(StringConnection);
        string Query = "Select * From Contacts Where FirstName Like '%' + @EndWith + ''";
        SqlCommand command = new SqlCommand(Query, connection);
        command.Parameters.AddWithValue("@EndWith", EndWith);
        try
        {
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
                int CountryId = (int)reader["countryid"];
                Console.WriteLine($"Contact Id : {ContactId}");
                Console.WriteLine($"Name       : {FirstName} {LastName}");
                Console.WriteLine($"Email      : {Email}");
                Console.WriteLine($"Phone      : {Phone}");
                Console.WriteLine($"Address    : {Address}");
                Console.WriteLine($"Country Id : {CountryId}");
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
    static void SearchConatactsContain(string Contain)
    {
        SqlConnection connection = new SqlConnection(StringConnection);
        string Query = "Select * From Contacts Where FirstName Like '%' + @Contain + '%'";
        SqlCommand command = new SqlCommand(Query, connection);
        command.Parameters.AddWithValue("@Contain", Contain);
        try
        {
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
                Console.WriteLine($"Contact Id : {ContactId}");
                Console.WriteLine($"Name       : {FirstName} {LastName}");
                Console.WriteLine($"Email      : {Email}");
                Console.WriteLine($"Phone      : {Phone}");
                Console.WriteLine($"Address    : {Address}");
                Console.WriteLine($"Country Id : {CountryId}");
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
        Console.WriteLine("-------- Start with j ");
        SearchConatactsStartWiht("j");
        Console.WriteLine("-------- Contacts Ends With 'ne'");
        SearchConatactsEndWiht("ne");
        Console.WriteLine("-------- contain with 'ae'");
        SearchConatactsContain("ae");
        Console.ReadKey();
        }
    }