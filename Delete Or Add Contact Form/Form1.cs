using Business_Layer_contact;
using ClsCountry_Business_Layer;
using System.Data;
using System.Diagnostics;
using System.Windows.Forms;

namespace Delete_Or_Add_Contact_Form
{
    public partial class Form1 : Form
    {
        // Defines the state of the form: either creating a new contact or editing an existing one.
        enum EnMode { Add = 1, Update = 2 }
        EnMode mode = EnMode.Add;

        int _ContactId;
        ClsContact contact;

        /// <summary>
        /// Constructor: Initializes the form and sets the operation mode based on the Contact ID.
        /// </summary>
        /// <param name="ContactId">Pass -1 to open in 'Add New' mode, or a valid ID for 'Update' mode.</param>
        public Form1(int ContactId)
        {
            InitializeComponent();
            _ContactId = ContactId;

            if (ContactId == -1)
            {
                mode = EnMode.Add;
            }
            else
            {
                mode = EnMode.Update;
            }
        }

        /// <summary>
        /// Retrieves the list of countries from the Business Layer and populates the Country ComboBox.
        /// </summary>
        void AllCountries()
        {
            DataTable Data = BusinessCountry.GetAllCountriesFromAccess();
            comboBox1.DataSource = Data;
            comboBox1.DisplayMember = "CountryName"; // Text visible to the user
            comboBox1.ValueMember = "CountryId";     // Underlying value stored in database
        }

        /// <summary>
        /// Loads and binds data to UI controls based on the current form mode (Add / Update).
        /// </summary>
        private void Load_Data()
        {
            AllCountries();
            comboBox1.SelectedIndex = 0;

            if (mode == EnMode.Add)
            {
                LableMain.Text = "Add New Contact";
                contact = new ClsContact(); // Initialize a clean new contact object
                return;
            }

            // Fetch the contact from the database using the provided ID
            contact = ClsContact.Find(_ContactId);

            // If contact is not found, show warning and close the form safely
            if (contact == null)
            {
                MessageBox.Show("This Contact Is Not Found");
                this.Close();
                return;
            }

            // Populate UI controls with retrieved database values
            LableMain.Text = "Update Contact";
            TextFirstName.Text = contact.FirstName;
            LastNameText.Text = contact.LastName;
            TextEmail.Text = contact.Email;
            TextPhone.Text = contact.Phone;
            TextAddress.Text = contact.Address;
            LableContactIdReader.Text = contact.ContactId.ToString();
            comboBox1.SelectedValue = contact.CountryId;
            dateTimePicker1.Value = contact.DateOfBirth;

            // Handle the contact image setup
            if (!string.IsNullOrEmpty(contact.ImagePath))
            {
                pictureBox1.ImageLocation = contact.ImagePath;
                LinkLableRemoveImage.Visible = true;
            }
            else
            {
                contact.ImagePath = "";
                pictureBox1.Image = null; // Clear image buffer
                LinkLableRemoveImage.Visible = false;
            }
        }

        /// <summary>
        /// Form Load Event: Triggered automatically when the form window is opened.
        /// </summary>
        private void Form1_Load(object sender, System.EventArgs e)
        {
            Load_Data();
        }

        /// <summary>
        /// Save Button Event: Maps UI inputs back to the object and commits changes to the database.
        /// </summary>
        private void ButtonSave_Click(object sender, System.EventArgs e)
        {
            // Map text inputs to the contact object properties
            contact.FirstName = TextFirstName.Text;
            contact.LastName = LastNameText.Text;
            contact.Email = TextEmail.Text;
            contact.Phone = TextPhone.Text;
            contact.Address = TextAddress.Text;

            // Handle image path mapping and adjust "Remove" label visibility
            if (!string.IsNullOrEmpty(pictureBox1.ImageLocation))
            {
                contact.ImagePath = pictureBox1.ImageLocation;
                LinkLableRemoveImage.Visible = true;
            }
            else
            {
                contact.ImagePath = "";
                LinkLableRemoveImage.Visible = false;
            }

            contact.CountryId = (int)comboBox1.SelectedValue;
            contact.DateOfBirth = dateTimePicker1.Value;

            // Call Save method from Business Layer (automatically handles Insert or Update)
            if (contact.Save())
            {
                MessageBox.Show("Saved Successfully!");

                // Shift UI state to 'Update' mode once the contact is successfully persisted
                LableMain.Text = "Update Contact";
                LableContactIdReader.Text = contact.ContactId.ToString();
                mode = EnMode.Update;
            }
            else
            {
                MessageBox.Show("Error: Data Not Saved!");
            }
        }

        /// <summary>
        /// Close Button Event: Safely exits the current form instance.
        /// </summary>
        private void ButtonClose_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// LinkLabel Click Event: Opens a file dialog to choose and display a profile photo.
        /// </summary>
        private void LinkLableSetImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Setup accepted image file formats
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string selectedFilePath = openFileDialog1.FileName;
                pictureBox1.Load(selectedFilePath); // Load image preview

                pictureBox1.Visible = true;
                LinkLableRemoveImage.Visible = true;
            }
        }

        /// <summary>
        /// LinkLabel Click Event: Clears the loaded image from the UI and hides the remove button.
        /// </summary>
        private void LinkLableRemoveImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pictureBox1.ImageLocation = null;
            pictureBox1.Image = null; // Safely release resources
            LinkLableRemoveImage.Visible = false;
        }
    }
}