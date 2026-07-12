using System;
using System.Data.SqlClient;
internal class Program
{
    static string StringConnection = "Server = .; DataBase = ContactsDB;User Id = sa ; Password = 123456;";
    public struct ContactInfo
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public int CountryId { get; set; }
    }
    static bool Find(int Contacts, ref ContactInfo contact)
    {
        bool IsFound = false;
        SqlConnection connection = new SqlConnection(StringConnection);
        string Query = "Select * From Contacts Where ContactId = @Contacts";
        SqlCommand command = new SqlCommand(Query, connection);
        command.Parameters.AddWithValue("@Contacts", Contacts);
        try
        {
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                IsFound = true;
                contact.Id = (int)reader["ContactId"];
                contact.FirstName = (string)reader["FirstName"];
                contact.LastName = (string)reader["LastName"];
                contact.Email = (string)reader["Email"];
                contact.Phone = (string)reader["Phone"];
                contact.Address = (string)reader["Address"];
                contact.CountryId = (int)reader["CountryId"];
            }
            else
            {
                IsFound = false;
            }
            reader.Close();
            connection.Close();
        }
        catch (Exception EX)
        {
            Console.WriteLine("Error , " + EX.Message);
        }
        return IsFound;
    }
    static void Main(string[] args)
    {
        ContactInfo con = new ContactInfo();
        if (Find(1,ref con) )
        {
            Console.WriteLine($"Contact Id : {con.Id} ");
            Console.WriteLine($"Name       : {con.FirstName} {con.LastName} ");
            Console.WriteLine($"Email      : {con.Email} ");
            Console.WriteLine($"Phone      : {con.Phone} ");
            Console.WriteLine($"Address    : {con.Address} ");
            Console.WriteLine($"Country Id : {con.CountryId} ");
        }
        else
        {
            Console.WriteLine("Not Found");
        }
        Console.ReadKey();
    }
}