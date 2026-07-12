using System;
using System.Data.SqlClient;
internal class Program
{
    // Database connection string (specifies the server, database name, and user credentials)
    static string StringConnection = "Server = . ; DataBase = ContactsDB; User Id = sa; Password = 123456;";
    // Data structure (Struct) to hold contact information in memory efficiently using Stack Allocation
    public struct ContactInfo
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public int CountryId { get; set; }
    }
    // Executable method responsible for inserting a single row into the database
    static void InsertOneRow(ContactInfo contact)
    {
        // 1. Create the connection object (prepares the pipeline between C# and SQL Server)
        SqlConnection connection = new SqlConnection(StringConnection);
        // 2. Define the SQL query with secure parameter placeholders (@) to strictly prevent SQL Injection vulnerabilities
        string Query = @"Insert Into Contacts (FirstName, LastName, Email, Phone, Address, CountryId)
                        Values (@FirstName, @LastName, @Email, @Phone, @Address, @CountryId)";
        // 3. Initialize the Command object, binding the SQL query to the established connection pipeline
        SqlCommand command = new SqlCommand(Query, connection);
        // 4. Map the actual data values from the struct to their corresponding secure SQL parameters
        command.Parameters.AddWithValue("@FirstName", contact.FirstName);
        command.Parameters.AddWithValue("@LastName", contact.LastName);
        command.Parameters.AddWithValue("@Email", contact.Email);
        command.Parameters.AddWithValue("@Phone", contact.Phone);
        command.Parameters.AddWithValue("@Address", contact.Address);
        command.Parameters.AddWithValue("@CountryId", contact.CountryId);
        try
        {
            // Open the actual database connection pipeline
            connection.Open();
            // Execute the non-query command and capture the number of database rows affected
            int RowsEffected = command.ExecuteNonQuery();
            // Check the result: if affected rows > 0, the record was added successfully
            if (RowsEffected > 0)
            {
                Console.WriteLine("Inserted Successfully");
            }
            else
            {
                Console.WriteLine("Insertion Failed");
            }
        }
        catch (Exception Ex)
        {
            // Catch and display any unexpected exceptions/errors that occur during execution
            Console.WriteLine("Error, " + Ex.Message);
        }
        finally
        {
            // 5. Architectural Safety: Always close the connection stream at the end, regardless of success or failure
            if (connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
            }
        }
    }
    static void Main(string[] args)
    {
        // Initialize and populate the data container (Struct) with the record details to be inserted
        ContactInfo contact = new ContactInfo
        {
            FirstName = "Mustafa",
            LastName = "Ayyan",
            Email = "Must3@gmail.com",
            Phone = "0985128034",
            Address = "Aleppo",
            CountryId = 1
        };
        // Invoke the insertion function and pass the populated struct object
        InsertOneRow(contact);
        // Keep the console terminal window open to review execution outputs
        Console.ReadKey();
    }
}