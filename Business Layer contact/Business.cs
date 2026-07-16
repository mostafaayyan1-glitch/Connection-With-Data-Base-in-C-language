using System;
using System.Data;
using Access_Data_Layer;

namespace Business_Layer_contact
{
    /// <summary>
    /// Represents the business logic layer for managing Contact data.
    /// </summary>
    public class ClsContact
    {
        public enum EnMode { AddNew = 0, UpdateMode = 1 }

        private EnMode _mode = EnMode.AddNew;

        // Properties
        public int ContactId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int CountryId { get; set; }
        public string ImagePath { get; set; }

        /// <summary>
        /// Gets the current mode of the contact object (AddNew or UpdateMode).
        /// </summary>
        public EnMode Mode => _mode;

        /// <summary>
        /// Default constructor initializing a new contact in AddNew mode.
        /// </summary>
        public ClsContact()
        {
            this.ContactId = -1;
            this.FirstName = "";
            this.LastName = "";
            this.Email = "";
            this.Phone = "";
            this.Address = "";
            this.DateOfBirth = DateTime.Now;
            this.CountryId = -1;
            this.ImagePath = "";
            _mode = EnMode.AddNew;
        }

        /// <summary>
        /// Private constructor used to instantiate an existing contact in UpdateMode.
        /// </summary>
        private ClsContact(int id, string firstName, string lastName, string email,
            string phone, string address, DateTime dateOfBirth, int countryId, string imagePath)
        {
            this.ContactId = id;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Email = email;
            this.Phone = phone;
            this.Address = address;
            this.DateOfBirth = dateOfBirth;
            this.CountryId = countryId;
            this.ImagePath = imagePath;
            _mode = EnMode.UpdateMode;
        }

        /// <summary>
        /// Finds and retrieves a contact from the database by its ID.
        /// </summary>
        /// <param name="id">The unique identifier of the contact.</param>
        /// <returns>An instance of ClsContact if found; otherwise, null.</returns>
        public static ClsContact Find(int id)
        {
            string firstName = "", lastName = "", email = "", phone = "", address = "", imagePath = "";
            DateTime dateOfBirth = DateTime.Now;
            int countryId = -1;

            if (Access.GetContactInfoByID(id, ref firstName, ref lastName, ref email, ref phone, ref address, ref dateOfBirth, ref countryId, ref imagePath))
            {
                return new ClsContact(id, firstName, lastName, email, phone, address, dateOfBirth, countryId, imagePath);
            }
            else
            {
                return null;
            }
        }

        private bool _AddNewContact()
        {
            this.ContactId = Access.InsertToData(this.FirstName, this.LastName, this.Email, this.Phone, this.Address,
                this.DateOfBirth, this.CountryId, this.ImagePath);

            return (this.ContactId != -1);
        }
        private bool _Update()
        {
            return Access.UpdateContact(this.ContactId, this.FirstName, this.LastName, this.Email, this.Phone, this.Address, this.DateOfBirth, this.CountryId, this.ImagePath);
        }
        /// <summary>
        /// Deletes a contact from the database by its ID.
        /// </summary>
        /// <param name="id">The unique identifier of the contact to delete.</param>
        /// <returns>True if the deletion was successful; otherwise, false.</returns>
        public static bool Delete(int id)
        {
            return Access.DeleteContact(id);
        }

        /// <summary>
        /// Saves the current contact (inserts if new, updates if existing).
        /// </summary>
        /// <returns>True if the operation succeeded; otherwise, false.</returns>
        public bool Save()
        {
            switch (_mode)
            {
                case EnMode.AddNew:
                    if (_AddNewContact())
                    {
                        _mode = EnMode.UpdateMode;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case EnMode.UpdateMode:
                    return _Update();
            }
            return false;
        }

        /// <summary>
        /// Retrieves all contact records from the database.
        /// </summary>
        /// <returns>A DataTable containing all contacts.</returns>
        public static DataTable GetAllContacts()
        {
            return Access.GetAllContact();
        }

        /// <summary>
        /// Checks if a contact exists in the database by its ID.
        /// </summary>
        /// <param name="id">The unique identifier of the contact.</param>
        /// <returns>True if the contact exists; otherwise, false.</returns>
        public static bool Exists(int id)
        {
            return Access.IsExist(id);
        }
    }
}