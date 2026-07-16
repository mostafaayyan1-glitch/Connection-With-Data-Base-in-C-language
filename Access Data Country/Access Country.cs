using String_Connection;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Access_Data_Country
{
    /// <summary>
    /// Provides data access methods for the Countries database table.
    /// </summary>
    public class AccessCountry
    {
        /// <summary>
        /// Retrieves detailed information for a specific country by its ID.
        /// </summary>
        /// <param name="CountryId">The unique identifier of the country.</param>
        /// <param name="CountryName">Outputs the name of the country (returns empty string if NULL).</param>
        /// <param name="CodeCountries">Outputs the country's ISO/short code (returns empty string if NULL).</param>
        /// <param name="PhoneCode">Outputs the country's international phone dial code (returns empty string if NULL).</param>
        /// <returns>True if the country was found; otherwise, false.</returns>
        public static bool GetCountryById(int CountryId, ref string CountryName, ref
            string CodeCountries, ref string PhoneCode)
        {
            bool IsFound = false;
            string Query = @"SELECT * FROM Countries WHERE CountryId = @CountryId";

            using (SqlConnection connection = new SqlConnection(Sittengs.Connection_String))
            using (SqlCommand command = new SqlCommand(Query, connection))
            {
                command.Parameters.AddWithValue("@CountryId", CountryId);

                try
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            IsFound = true;

                            CountryName = reader["CountryName"] != DBNull.Value ? (string)reader["CountryName"] : "";
                            CodeCountries = reader["CodeCountries"] != DBNull.Value ? (string)reader["CodeCountries"] : "";
                            PhoneCode = reader["PhoneCode"] != DBNull.Value ? (string)reader["PhoneCode"] : "";
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
        /// Inserts a new country record into the database and returns its newly generated ID.
        /// </summary>
        /// <param name="CountryName">The name of the country.</param>
        /// <param name="PhoneCode">The international phone dialing code.</param>
        /// <param name="CodeCountries">The standard country code (ISO).</param>
        /// <returns>The newly created Country ID if successful; otherwise, -1.</returns>
        public static int InsertToData(string CountryName, string PhoneCode, string CodeCountries)
        {
            int CountryId = -1;
            string Query = @"INSERT INTO Countries (CountryName, PhoneCode, CodeCountries) 
                             VALUES (@CountryName, @PhoneCode, @CodeCountries);
                             SELECT SCOPE_IDENTITY();";

            using (SqlConnection connection = new SqlConnection(Sittengs.Connection_String))
            using (SqlCommand command = new SqlCommand(Query, connection))
            {
                command.Parameters.AddWithValue("@CountryName", CountryName);
                command.Parameters.AddWithValue("@PhoneCode", string.IsNullOrEmpty(PhoneCode) ? DBNull.Value : (object)PhoneCode);
                command.Parameters.AddWithValue("@CodeCountries", string.IsNullOrEmpty(CodeCountries) ? DBNull.Value : (object)CodeCountries);

                try
                {
                    connection.Open();
                    object Result = command.ExecuteScalar();

                    if (Result != null && int.TryParse(Result.ToString(), out int Id))
                    {
                        CountryId = Id;
                    }
                }
                catch (Exception Ex)
                {
                    Console.WriteLine("Error, " + Ex.Message);
                }
            }

            return CountryId;
        }

        /// <summary>
        /// Updates the details of an existing country in the database.
        /// </summary>
        /// <param name="countryId">The ID of the country to update.</param>
        /// <param name="CountryName">The updated name of the country.</param>
        /// <param name="CodeCountries">The updated country code.</param>
        /// <param name="PhoneCode">The updated phone dialing code.</param>
        /// <returns>True if the country details were updated successfully; otherwise, false.</returns>
        public static bool UpdateCountry(int countryId, string CountryName, string CodeCountries, string PhoneCode)
        {
            int Rows = 0;
            string Query = @"UPDATE Countries 
                             SET CountryName = @CountryName, 
                                 CodeCountries = @CodeCountries, 
                                 PhoneCode = @PhoneCode 
                             WHERE CountryId = @CountryId";

            using (SqlConnection connection = new SqlConnection(Sittengs.Connection_String))
            using (SqlCommand command = new SqlCommand(Query, connection))
            {
                command.Parameters.AddWithValue("@CountryId", countryId);
                command.Parameters.AddWithValue("@CountryName", CountryName);
                command.Parameters.AddWithValue("@CodeCountries", string.IsNullOrEmpty(CodeCountries) ? DBNull.Value : (object)CodeCountries);
                command.Parameters.AddWithValue("@PhoneCode", string.IsNullOrEmpty(PhoneCode) ? DBNull.Value : (object)PhoneCode);

                try
                {
                    connection.Open();
                    Rows = command.ExecuteNonQuery();
                }
                catch (Exception Ex)
                {
                    Console.WriteLine("Error: " + Ex.Message);
                }
            }

            return (Rows > 0);
        }

        /// <summary>
        /// Deletes a country record from the database using its ID.
        /// </summary>
        /// <param name="countryId">The unique identifier of the country to delete.</param>
        /// <returns>True if deleted successfully; otherwise, false.</returns>
        public static bool DeleteCountry(int countryId)
        {
            int Rows = 0;
            string Query = "DELETE FROM Countries WHERE CountryId = @CountryId";

            using (SqlConnection connection = new SqlConnection(Sittengs.Connection_String))
            using (SqlCommand command = new SqlCommand(Query, connection))
            {
                command.Parameters.AddWithValue("@CountryId", countryId);

                try
                {
                    connection.Open();
                    Rows = command.ExecuteNonQuery();
                }
                catch (Exception Ex)
                {
                    Console.WriteLine("Error: " + Ex.Message);
                }
            }

            return (Rows > 0);
        }

        /// <summary>
        /// Retrieves all country records from the Countries table.
        /// </summary>
        /// <returns>A DataTable populated with all countries in the database.</returns>
        public static DataTable GetAllCountries()
        {
            DataTable dataTable = new DataTable();
            string Query = "SELECT * FROM Countries";

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
                catch (Exception Ex)
                {
                    Console.WriteLine("Error, " + Ex.Message);
                }
            }

            return dataTable;
        }

        /// <summary>
        /// Checks if a country exists in the database by its unique ID.
        /// </summary>
        /// <param name="Id">The Country ID to check.</param>
        /// <returns>True if the country exists; otherwise, false.</returns>
        public static bool IsExistCountries(int Id)
        {
            bool IsFound = false;
            string Query = "SELECT 1 FROM Countries WHERE CountryId = @CountryId";

            using (SqlConnection connection = new SqlConnection(Sittengs.Connection_String))
            using (SqlCommand command = new SqlCommand(Query, connection))
            {
                command.Parameters.AddWithValue("@CountryId", Id);

                try
                {
                    connection.Open();
                    object Res = command.ExecuteScalar();
                    IsFound = (Res != null);
                }
                catch (Exception Ex)
                {
                    Console.WriteLine("Error, " + Ex.Message);
                }
            }

            return IsFound;
        }
        /// <summary>
        /// Retrieves detailed information for a specific country by its Name.
        /// </summary>
        /// <param name="CountryName">The name of the country to search for.</param>
        /// <param name="CountryId">Outputs the unique identifier of the country.</param>
        /// <param name="CodeCountries">Outputs the country's ISO/short code (returns empty string if NULL).</param>
        /// <param name="PhoneCode">Outputs the country's international phone dial code (returns empty string if NULL).</param>
        /// <returns>True if the country was found; otherwise, false.</returns>
        public static bool GetCountryByName(string CountryName, ref int CountryId, ref
            string CodeCountries, ref string PhoneCode)
        {
            bool IsFound = false;
            string Query = @"SELECT * FROM Countries WHERE CountryName = @CountryName";
            using (SqlConnection connection = new SqlConnection(Sittengs.Connection_String))
            using (SqlCommand command = new SqlCommand(Query, connection))
            {
                command.Parameters.AddWithValue("@CountryName", CountryName);
                try
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            IsFound = true;

                            CountryId = (int)reader["CountryId"];

                            CodeCountries = reader["CodeCountries"] != DBNull.Value ? (string)reader["CodeCountries"] : "";
                            PhoneCode = reader["PhoneCode"] != DBNull.Value ? (string)reader["PhoneCode"] : "";
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
    }
}