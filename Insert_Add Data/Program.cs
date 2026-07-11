using System;
using System.Data.SqlClient;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
internal class Program
    {
    static string StringConnection = "Server = . ; DataBase = ContactsDB; User Id = sa; Password = 123456;";
    public struct ContactInfo
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public int CountryId { get; set; }
    }
    static void InsertOneRow(ContactInfo contact)
    {
        SqlConnection connection = new SqlConnection(StringConnection);
        string Query = @"Insert Into Contacts ( FirstName , LastName , Email , Phone ,Address , CountryId)
        Values (@FirstName , @LastName , @Email,@Phone,@Address,@CountryId)";
        SqlCommand command = new SqlCommand(Query, connection);
        command.Parameters.AddWithValue(@"FirstName", contact.FirstName);
        command.Parameters.AddWithValue(@"LastName", contact.LastName);
        command.Parameters.AddWithValue(@"Email", contact.Email);
        command.Parameters.AddWithValue(@"Phone", contact.Phone);
        command.Parameters.AddWithValue(@"Address", contact.Address);
        command.Parameters.AddWithValue(@"CountryId", contact.CountryId);
        try
        {
            connection.Open();
            int RowsEffected = command.ExecuteNonQuery();
            if(RowsEffected > 0)
            {
                Console.WriteLine("Inserted Succes");
            }
            else
            {
                Console.WriteLine("Faild Inserted");
            }
            connection.Close();
        }
        catch(Exception Ex)
        {
            Console.WriteLine("Error , "+ Ex.Message);
        }
    }
        static void Main(string[] args)
        {
        ContactInfo contact = new ContactInfo
        {
            FirstName = "Mustafa",
            LastName = "Ayyan",
            Email = "Must3@gmail.com",
            Phone = "0985128034",
            Address = "Aleppo",
            CountryId = 1
        };
        InsertOneRow(contact);
        Console.ReadKey();
        }
    }