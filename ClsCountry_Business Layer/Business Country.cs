using Access_Data_Country;
using System.Data;

namespace ClsCountry_Business_Layer
{
    /// <summary>
    /// Represents the business logic layer for managing Country data.
    /// </summary>
    public class BusinessCountry
    {
        public enum EnMode { Add = 1, Update = 2 };

        private EnMode _mode = EnMode.Add;
        public int CountryId { get; set; }
        public string CountryName { get; set; }
        public string CodeCountries { get; set; }
        public string PhoneCode { get; set; }

        /// <summary>
        /// Default constructor initializing a new country in Add mode.
        /// </summary>
        public BusinessCountry()
        {
            CountryId = -1;
            CountryName = "";
            CodeCountries = "";
            PhoneCode = "";
            _mode = EnMode.Add;
        }

        /// <summary>
        /// Private constructor used to load an existing country's data in Update mode.
        /// </summary>
        private BusinessCountry(int id, string countryName, string phoneCode, string code)
        {
            this.CountryId = id;
            this.CountryName = countryName;
            this.PhoneCode = phoneCode;
            this.CodeCountries = code;
            _mode = EnMode.Update;
        }

        /// <summary>
        /// Retrieves a country object from the database using its ID.
        /// </summary>
        /// <param name="id">The unique identifier of the country.</param>
        /// <returns>An instance of BusinessCountry if found; otherwise, null.</returns>
        public static BusinessCountry GetCountryFromAccess(int id)
        {
            string countryName = "";
            string phoneCode = "";
            string codeCountries = "";

            if (AccessCountry.GetCountryById(id, ref countryName, ref codeCountries, ref phoneCode))
            {
                return new BusinessCountry(id, countryName, phoneCode, codeCountries);
            }
            else
            {
                return null;
            }
        }

        private bool InsertYesOrNoFromAccess()
        {
            this.CountryId = AccessCountry.InsertToData(this.CountryName, this.PhoneCode, this.CodeCountries);
            return (this.CountryId != -1);
        }
        private bool UpdateFromAccess()
        {
            return AccessCountry.UpdateCountry(this.CountryId, this.CountryName, this.CodeCountries, this.PhoneCode);
        }
        /// <summary>
        /// Deletes a country from the database by its ID.
        /// </summary>
        /// <param name="id">The ID of the country to delete.</param>
        /// <returns>True if deleted successfully; otherwise, false.</returns>
        public static bool DeleteCountryByAccess(int id)
        {
            return AccessCountry.DeleteCountry(id);
        }

        /// <summary>
        /// Retrieves all country records from the database.
        /// </summary>
        /// <returns>A DataTable containing all countries.</returns>
        public static DataTable GetAllCountriesFromAccess()
        {
            return AccessCountry.GetAllCountries();
        }

        /// <summary>
        /// Checks if a country exists in the database by its ID.
        /// </summary>
        /// <param name="id">The Country ID.</param>
        /// <returns>True if it exists; otherwise, false.</returns>
        public static bool ExistFromAccess(int id)
        {
            return AccessCountry.IsExistCountries(id);
        }

        /// <summary>
        /// Saves the country object to the database (Inserts if new, Updates if existing).
        /// </summary>
        /// <returns>True if the save operation was successful; otherwise, false.</returns>
        public bool Save()
        {
            switch (_mode)
            {
                case EnMode.Add:
                    {
                        if (InsertYesOrNoFromAccess())
                        {
                            _mode = EnMode.Update;
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                case EnMode.Update:
                    {
                        return UpdateFromAccess();
                    }
            }
            return false;
        }
        /// <summary>
        /// Retrieves a country object from the database using its Name.
        /// </summary>
        /// <param name="name">The name of the country.</param>
        /// <returns>An instance of BusinessCountry if found; otherwise, null.</returns>
        public static BusinessCountry GetCountryByName(string name)
        {
            int countryId = -1;
            string phoneCode = "";
            string codeCountries = "";

            if (AccessCountry.GetCountryByName(name, ref countryId, ref codeCountries, ref phoneCode))
            {
                return new BusinessCountry(countryId, name, phoneCode, codeCountries);
            }
            else
            {
                return null;
            }
        }
    }
}