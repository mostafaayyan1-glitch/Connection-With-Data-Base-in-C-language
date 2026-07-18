using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Creat_Data_Table_In_C__And_Add_Primary_Key
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DataTable employeesTable = new DataTable("Employees");

            // 2. Define the schema and specify data types for strict type safety
            employeesTable.Columns.Add("Id", typeof(int));
            employeesTable.Columns.Add("Name", typeof(string));
            employeesTable.Columns.Add("Country", typeof(string));
            employeesTable.Columns.Add("Salary", typeof(double));
            employeesTable.Columns.Add("Date", typeof(DateTime));
            // Make Id Column The Primary Key Column
            DataColumn[] primaryKeycoulmn = new DataColumn[1];
            primaryKeycoulmn[0] = employeesTable.Columns["Id"];
            employeesTable.PrimaryKey = primaryKeycoulmn;
            // 3. Populate the DataTable with row records
            employeesTable.Rows.Add(1, "Mustafa Ayyan", "Syria", 2000, DateTime.Now);
            employeesTable.Rows.Add(2, "Adnan Ayyan", "Lebanon", 6000, DateTime.Now);
            employeesTable.Rows.Add(3, "Muhammed Adel", "Italy", 3000, DateTime.Now);
            employeesTable.Rows.Add(4, "Mosaab Adnan", "Syria", 6000, DateTime.Now);
            employeesTable.Rows.Add(5, "Yousef Muhammed", "Palestine", 2000, DateTime.Now);
            Console.ReadKey();
        }
    }
}
