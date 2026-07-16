using Business_Layer_contact;
using System.Windows.Forms;
using Delete_Or_Add_Contact_Form;
namespace Form_For_Edit_and_Delete_By_windows
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            dataGridView1.ContextMenuStrip = contextMenuStrip1; 
        }
        void RefreshData()
        {
            dataGridView1.DataSource = ClsContact.GetAllContacts();
        }
        private void Form1_Load(object sender, System.EventArgs e)
        {
            RefreshData();
        }
        private void deleteToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete contact [" + dataGridView1.CurrentRow.Cells[0].Value + "]", "Confirm Delete", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                if (ClsContact.Delete((int)(dataGridView1.CurrentRow.Cells[0].Value)))
                {
                    MessageBox.Show("Deleted");
                    RefreshData();
                }
                else
                {
                    MessageBox.Show("contact Not Deleted");
                }
            }
        }
        private void editToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                return; 
            }
            Form1 form = new Form1((int)dataGridView1.CurrentRow.Cells[0].Value) ;
            form.ShowDialog();
            RefreshData();
        }

        private void AddButton_Click(object sender, System.EventArgs e)
        {
            Form1 form = new Form1(-1);
            form.ShowDialog();
            RefreshData();
        }
    }
}