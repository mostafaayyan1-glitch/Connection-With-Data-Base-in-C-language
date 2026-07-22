using String_Connection;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Access_Data_Layer
{
    /// <summary>
    /// Provides data access methods for the Contacts database table.
    /// </summary>
    public class Access
    {
        /// <summary>
        /// Retrieves detailed information for a specific contact by their ID.
        /// </summary>
        /// <param name="Id">The unique identifier of the contact.</param>
        /// <param name="FirstName">Outputs the first name of the contact.</param>
        /// <param name="LastName">Outputs the last name of the contact.</param>
        /// <param name="Email">Outputs the email address (returns empty string if NULL).</param>
        /// <param name="Phone">Outputs the phone number (returns empty string if NULL).</param>
        /// <param name="Address">Outputs the physical address (returns empty string if NULL).</param>
        /// <param name="DateOfbirth">Outputs the contact's date of birth.</param>
        /// <param name="CountryId">Outputs the country identifier linked to the contact.</param>
        /// <param name="ImagePath">Outputs the profile image path (returns empty string if NULL).</param>
        /// <returns>True if the contact was found; otherwise, false.</returns>
        public static bool GetContactInfoByID(int Id, ref string FirstName,
            ref string LastName, ref string Email, ref string Phone,
            ref string Address, ref DateTime DateOfbirth, ref int CountryId,
            ref string ImagePath)
        {
            bool IsFound = false;
            string Query = @"SELECT * FROM Contacts WHERE ContactId = @ContactId";

            using (SqlConnection connection = new SqlConnection(Sittengs.Connection_String))
            using (SqlCommand command = new SqlCommand(Query, connection))
            {
                command.Parameters.AddWithValue("@ContactId", Id);
                try
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            IsFound = true;
                            FirstName = reader["FirstName"] != DBNull.Value ? (string)reader["FirstName"] : "";
                            LastName = reader["LastName"] != DBNull.Value ? (string)reader["LastName"] : "";
                            Email = reader["Email"] != DBNull.Value ? (string)reader["Email"] : "";
                            Phone = reader["Phone"] != DBNull.Value ? (string)reader["Phone"] : "";
                            Address = reader["Address"] != DBNull.Value ? (string)reader["Address"] : "";
                            DateOfbirth = reader["DateOfBirth"] != DBNull.Value ? (DateTime)reader["DateOfBirth"] : DateTime.MinValue;
                            CountryId = reader["CountryId"] != DBNull.Value ? (int)reader["CountryId"] : -1;
                            ImagePath = reader["ImagePath"] != DBNull.Value ? (string)reader["ImagePath"] : "";
                        }
                    }
                }
                catch (Exception Ex)
                {
                    Console.WriteLine("Error, " + Ex.Message);
                }
            }
            return IsFound;
        }
        /// <summary>
        /// Inserts a new contact into the database and returns the newly generated ID.
        /// </summary>
        /// <param name="FirstName">The first name of the contact.</param>
        /// <param name="LastName">The last name of the contact.</param>
        /// <param name="Email">The email address.</param>
        /// <param name="Phone">The phone number.</param>
        /// <param name="Address">The physical address.</param>
        /// <param name="DateOfBirth">The contact's date of birth.</param>
        /// <param name="CountryId">The country identifier.</param>
        /// <param name="ImagePath">The profile image path (can be null or empty).</param>
        /// <returns>The newly created Contact ID if successful; otherwise, -1.</returns>
        public static int InsertToData(string FirstName, string LastName, string Email, string Phone,
           string Address, DateTime DateOfBirth, int CountryId, string ImagePath)
        {
            int ContactId = -1;
            string Query = @"INSERT INTO Contacts (FirstName, LastName, Email, Phone, Address, DateOfBirth, CountryId, ImagePath) 
                             VALUES (@FirstName, @LastName, @Email, @Phone, @Address, @DateOfBirth, @CountryId, @ImagePath);
                             SELECT SCOPE_IDENTITY();";
            using (SqlConnection connection = new SqlConnection(Sittengs.Connection_String))
            using (SqlCommand command = new SqlCommand(Query, connection))
            {
                command.Parameters.AddWithValue("@FirstName", FirstName);
                command.Parameters.AddWithValue("@LastName", LastName);
                command.Parameters.AddWithValue("@Email", string.IsNullOrEmpty(Email) ? DBNull.Value : (object)Email);
                command.Parameters.AddWithValue("@Phone", string.IsNullOrEmpty(Phone) ? DBNull.Value : (object)Phone);
                command.Parameters.AddWithValue("@Address", string.IsNullOrEmpty(Address) ? DBNull.Value : (object)Address);
                command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
                command.Parameters.AddWithValue("@CountryId", CountryId);
                command.Parameters.AddWithValue("@ImagePath", string.IsNullOrEmpty(ImagePath) ? DBNull.Value : (object)ImagePath);
                try
                {
                    connection.Open();
                    object Result = command.ExecuteScalar();

                    if (Result != null && int.TryParse(Result.ToString(), out int Id))
                    {
                        ContactId = Id;
                    }
                }
                catch (Exception Ex)
                {
                    Console.WriteLine("Error, " + Ex.Message);
                }
            }

            return ContactId;
        }

        /// <summary>
        /// Updates an existing contact's details in the database.
        /// </summary>
        /// <param name="Contactid">The ID of the contact to update.</param>
        /// <param name="FirstName">The updated first name.</param>
        /// <param name="LastName">The updated last name.</param>
        /// <param name="Email">The updated email.</param>
        /// <param name="Phone">The updated phone number.</param>
        /// <param name="Address">The updated physical address.</param>
        /// <param name="DateOfBirth">The updated date of birth.</param>
        /// <param name="CountryId">The updated country identifier.</param>
        /// <param name="ImagePath">The updated image path.</param>
        /// <returns>True if the contact was successfully updated; otherwise, false.</returns>
        public static bool UpdateContact(int Contactid, string FirstName, string LastName, string Email, string Phone,
           string Address, DateTime DateOfBirth, int CountryId, string ImagePath)
        {
            int Rows = 0;
            string Query = @"UPDATE Contacts 
                             SET FirstName = @FirstName,
                                 LastName = @LastName, 
                                 Email = @Email,
                                 Phone = @Phone, 
                                 Address = @Address,
                                 DateOfBirth = @DateOfBirth,
                                 CountryId = @CountryId,
                                 ImagePath = @ImagePath
                             WHERE ContactId = @ContactId";
            using (SqlConnection connection = new SqlConnection(Sittengs.Connection_String))
            using (SqlCommand command = new SqlCommand(Query, connection))
            {
                command.Parameters.AddWithValue("@ContactId", Contactid);
                command.Parameters.AddWithValue("@FirstName", FirstName);
                command.Parameters.AddWithValue("@LastName", LastName);
                command.Parameters.AddWithValue("@Email", string.IsNullOrEmpty(Email) ? DBNull.Value : (object)Email);
                command.Parameters.AddWithValue("@Phone", string.IsNullOrEmpty(Phone) ? DBNull.Value : (object)Phone);
                command.Parameters.AddWithValue("@Address", string.IsNullOrEmpty(Address) ? DBNull.Value : (object)Address);
                command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
                command.Parameters.AddWithValue("@CountryId", CountryId);
                command.Parameters.AddWithValue("@ImagePath", string.IsNullOrEmpty(ImagePath) ? DBNull.Value : (object)ImagePath);

                try
                {
                    connection.Open();
                    Rows = command.ExecuteNonQuery();
                }
                catch (Exception Ex)
                {
                    Console.WriteLine("Error, " + Ex.Message);
                    return false;
                }
            }

            return (Rows > 0);
        }

        /// <summary>
        /// Deletes a specific contact from the database using their ID.
        /// </summary>
        /// <param name="ContactId">The unique ID of the contact to delete.</param>
        /// <returns>True if deleted successfully; otherwise, false.</returns>
        public static bool DeleteContact(int ContactId)
        {
            int Rows = 0;
            string Query = "DELETE FROM Contacts WHERE ContactId = @ContactId";

            using (SqlConnection connection = new SqlConnection(Sittengs.Connection_String))
            using (SqlCommand command = new SqlCommand(Query, connection))
            {
                command.Parameters.AddWithValue("@ContactId", ContactId);

                try
                {
                    connection.Open();
                    Rows = command.ExecuteNonQuery();
                }
                catch (Exception Ex)
                {
                    Console.WriteLine("Error, " + Ex.Message);
                }
            }

            return (Rows > 0);
        }

        /// <summary>
        /// Retrieves all contact records from the Contacts table.
        /// </summary>
        /// <returns>A DataTable containing all contacts.</returns>
        public static DataTable GetAllContact()
        {
            DataTable dataTable = new DataTable();
            string Query = "SELECT * FROM Contacts";

            using (SqlConnection connection = new SqlConnection(Sittengs.Connection_String))
            using (SqlCommand command = new SqlCommand(Query, connection))
            {
                try
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            dataTable.Load(reader);
                        }
                    }
                }
                catch (Exception EX)
                {
                    Console.WriteLine("Error, " + EX.Message);
                }
            }

            return dataTable;
        }
        /// <summary>
        /// Checks if a contact exists in the database by their unique ID.
        /// </summary>
        /// <param name="Id">The Contact ID to search for.</param>
        /// <returns>True if the contact exists; otherwise, false.</returns>
        public static bool IsExist(int Id)
        {
            bool isFound = false;
            string Query = "SELECT 1 FROM Contacts WHERE ContactId = @ContactId";

            using (SqlConnection connection = new SqlConnection(Sittengs.Connection_String))
            using (SqlCommand command = new SqlCommand(Query, connection))
            {
                command.Parameters.AddWithValue("@ContactId", Id);
                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();
                    isFound = (result != null);
                }
                catch (Exception Ex)
                {
                    Console.WriteLine("Error: " + Ex.Message);
                }
            }

            return isFound;
        }
    }
}