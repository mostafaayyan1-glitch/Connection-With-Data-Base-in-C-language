using System;
using System.Data;
using System.Windows.Forms;
using Business_Employees;
namespace Presintaion____Show_And_Add_Employees
{
    public partial class Operation : Form
    {
        int _EmployeeId;
        BusinessEmployess _Employees;
        public enum EnMode { Add_Mode = 1 , Update_Mode = 2}
        EnMode Mode = EnMode.Add_Mode;
        public Operation(int EmployeeId)
        {
            InitializeComponent();
            _EmployeeId = EmployeeId;
            if(_EmployeeId == -1)
            {
                Mode = EnMode.Add_Mode;
            }
            else
            {
                Mode = EnMode.Update_Mode;
            }
        }
        private void All_Department()
        {
            DataTable Data = Business_Department.Class1.GetAllDepartments();
            comboBox1.DataSource = Data;
            comboBox1.DisplayMember = "DepartName";
            comboBox1.ValueMember = "DepartId";
        }
        private void Load_Data()
        {
            All_Department();
            comboBox1.SelectedIndex = 0;
            if(Mode == EnMode.Add_Mode)
            {
                _Employees = new BusinessEmployess();
                return;
            }
            _Employees = BusinessEmployess.FindEmployees(_EmployeeId);
            if (_Employees == null)
            {
                MessageBox.Show("This Employee Is Not Found");
                this.Close();
                return;
            }
            Id.Text = _Employees.EmpId.ToString();
            TextFirst.Text = _Employees.FirstName.ToString();
            TextLast.Text = _Employees.LastName.ToString();
            TextEmail.Text = _Employees.Email.ToString();
            TextPhone.Text = _Employees.Phone.ToString();
            TextSalary.Text = _Employees.Salary.ToString();
            comboBox1.SelectedValue = _Employees.DepartId;
            dateTimePicker1.Value = _Employees.HireDate;
            pictureBox1.ImageLocation = _Employees.ImagePath;
            if (!string.IsNullOrEmpty(_Employees.ImagePath))
            {
                pictureBox1.ImageLocation = _Employees.ImagePath;
                ButtonDeleteImage.Visible = true;
            }
            else
            {
                _Employees.ImagePath = "";
                pictureBox1.Image = null; // Clear image buffer
                ButtonDeleteImage.Visible = false;
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Load_Data();
        }
        private void ButtonSave_Click(object sender, EventArgs e)
        {            
            _Employees.FirstName = TextFirst.Text;
            _Employees.LastName = TextLast.Text;
            _Employees.Email = TextEmail.Text;
            _Employees.Phone = TextPhone.Text;
            _Employees.Salary = double.Parse( TextSalary.Text);
            if (!string.IsNullOrEmpty(pictureBox1.ImageLocation))
            {
                _Employees.ImagePath = pictureBox1.ImageLocation;
                ButtonDeleteImage.Visible = true;
            }
            else
            {
                _Employees.ImagePath = "";
                ButtonDeleteImage.Visible = false;
            }
            _Employees.DepartId = (int)comboBox1.SelectedValue;
            _Employees.HireDate = dateTimePicker1.Value;
            if (_Employees.SaveEmployees())
            {
                MessageBox.Show("Saved Succesfuly ");
                Id.Text = _Employees.EmpId.ToString();
                Mode = EnMode.Update_Mode;
            }
            else
            {
                MessageBox.Show("Not Saved !");
            }
        }
        private void ButtonaddImage_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string selectedFilePath = openFileDialog1.FileName;
                pictureBox1.Load(selectedFilePath); // Load image preview

                pictureBox1.Visible = true;
                ButtonDeleteImage .Visible = true;
            }
        }
        private void ButtonDeleteImage_Click(object sender, EventArgs e)
        {
            pictureBox1.ImageLocation = null;
            pictureBox1.Image = null; // Safely release resources
            ButtonDeleteImage.Visible = false;
        }
        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
