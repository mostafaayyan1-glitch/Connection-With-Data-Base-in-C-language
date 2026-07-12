using System;
using System.Data.SqlClient;
internal class Program
{
    // Database connection string
    static string StringConnection = "Server = . ; DataBase = contactsDB ; User Id = sa; Password = 123456;";
    // Struct to hold contact data fields
    public struct StContact
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public int CountryId { get; set; }
    }
    // Method to insert a contact and securely retrieve its newly generated Identity ID
    static void AddNewContactAndGetId(StContact contact)
    {
        SqlConnection connection = new SqlConnection(StringConnection);
        // Combined SQL Query: Inserts data, then immediately captures the new identity seed
        string Query = @"Insert Into Contacts (FirstName, LastName, Email, Phone, Address, CountryId) 
                         Values (@FirstName, @LastName, @Email, @Phone, @Address, @CountryId);
                         SELECT SCOPE_IDENTITY();"; // Semicolon merges the two SQL operations
        SqlCommand command = new SqlCommand(Query, connection);
        // Parameterized values mapping for defense against SQL injection
        command.Parameters.AddWithValue("@FirstName", contact.FirstName);
        command.Parameters.AddWithValue("@LastName", contact.LastName);
        command.Parameters.AddWithValue("@Email", contact.Email);
        command.Parameters.AddWithValue("@Phone", contact.Phone);
        command.Parameters.AddWithValue("@Address", contact.Address);
        command.Parameters.AddWithValue("@CountryId", contact.CountryId);
        try
        {
            connection.Open();
            // CRITICAL FIX: ExecuteScalar captures the single scalar value returned by SELECT SCOPE_IDENTITY()
            object Result = command.ExecuteScalar();
            // Securely parse the returning scalar object into a valid integer ID
            if (Result != null && int.TryParse(Result.ToString(), out int id))
            {
                Console.WriteLine($"Newly Inserted Contact ID: {id}");
            }
            else
            {
                Console.WriteLine("Insertion Failed");
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
        StContact contact = new StContact
        {
            FirstName = "Mohammed",
            LastName = "Adel Ayyan",
            Email = "Ad@gmail.com",
            Phone = "48055454",
            Address = "Aleppo _Fardous",
            CountryId = 1
        };
        // Fire the function
        AddNewContactAndGetId(contact);
        Console.ReadKey();
        // Mustafa Ayyan
    }
}