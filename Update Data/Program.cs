using System;
using System.Data.SqlClient;
    internal class Program
    {
    static string StringConnection =
        "Server = . ; DataBase = ContactsDB ; " +
        "User Id = sa ; Password = 123456;";
    public struct StContact
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string phone { get; set; }
        public string Address { get; set; }
        public int CountryId { get; set; }
    }
    static void Update(int ContactId, StContact contact)
    {
        SqlConnection connection = new SqlConnection(StringConnection);
        String Querey = "Update Contacts set " +
            "FirstName = @FirstName ," +
            "LastName = @LastName , " +
            "Email = @Email ," +
            "Phone = @Phone  ," +
            "Address = @Address ," +
            "CountryId = @countryId where ContactId = @ContactId";
        SqlCommand command = new SqlCommand(Querey, connection);
        command.Parameters.AddWithValue(@"ContactId", ContactId);
        command.Parameters.AddWithValue(@"FirstName", contact.FirstName);
        command.Parameters.AddWithValue(@"LastName", contact.LastName);
        command.Parameters.AddWithValue(@"Email", contact.Email);
        command.Parameters.AddWithValue(@"Phone", contact.phone );
        command.Parameters.AddWithValue(@"Address", contact.Address );
        command.Parameters.AddWithValue(@"CountryId", contact.CountryId);
        try
        {
            connection.Open();
            int RowsEffected = command.ExecuteNonQuery();
            if (RowsEffected > 0)
            {
                Console.WriteLine("Update Succesful");
            }
            else
            {
                Console.WriteLine("Faild Update");
            }
            connection.Close();
        }
        catch (Exception Ex)
        {
            Console.WriteLine("Error , " + Ex.Message);
        }
    }
        static void Main(string[] args)
        {
        StContact contact = new StContact
        {
            FirstName = "Mustafa",
            LastName = "Adnan",
            Email = "Mus3@gmail.com",
            phone = "434354",
            Address = "Aleppo",
            CountryId =4
        };
        Update(1, contact);
        // By Aspiring Developer
        Console.ReadKey();
        }
    }