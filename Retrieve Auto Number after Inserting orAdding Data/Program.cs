using System;
using System.Data.SqlClient;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Net;
internal class Program
    {
    static string StringConnection = "Server = . ; DataBase = contactsDB ; User Id = sa; Password = 123456;";
    public struct StContact
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public int CountryId { get; set; } 
    }
    static void AddNewContactAndGetId(StContact contact)
    {
        SqlConnection connection = new SqlConnection(StringConnection);
        string Query = @"Insert Into Contacts (FirstName, LastName ,Email,Phone,Address,CountryId ) 
Values (@FirstName ,@LastName,@Email,@Phone,@Address ,@CountryId);
select Scope_Identity()";
        SqlCommand command = new SqlCommand(Query, connection);
        command.Parameters.AddWithValue("@FirstName", contact.FirstName);
        command.Parameters.AddWithValue("@LastName", contact.LastName);
        command.Parameters.AddWithValue("@Email", contact.Email);
        command.Parameters.AddWithValue("@Phone", contact.Phone);
        command.Parameters.AddWithValue("@Address", contact.Address);
        command.Parameters.AddWithValue("@CountryId ", contact.CountryId);
        try
        {
            connection.Open();
            object Result = command.ExecuteScalar();
            if(Result != null && int.TryParse (Result.ToString () ,out int Id))
            {
                Console.WriteLine($"Newly Inserted {Id}");
            }
            else
            {
                Console.WriteLine("Faild Insertion");
            }
            connection.Close();
        }
        catch(Exception Ex)
        {
            Console.WriteLine("Error , " + Ex.Message);
        }
    }
    static void Main(string[] args)
        {
        StContact contact = new StContact
        {
            FirstName = "Mustafa ",
            LastName = "Ayyan",
            Address = "Aleppo - Al_Fardous",
            Email = "Mustafa1@12gmail.com",
            Phone = "930843",
            CountryId = 2
        };
        AddNewContactAndGetId(contact);
        Console.ReadKey();

        }
    }