using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Creat_Data_Table_With_Properties_for_All_Column
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 1. Create DataTable in memory (RAM)
            DataTable  employeesTable = new DataTable();

            // 2. Define the schema and specify data types for strict type safety
            //employeesTable.Columns.Add("Id", typeof(int));
            //employeesTable.Columns.Add("Name", typeof(string));
            //employeesTable.Columns.Add("Country", typeof(string));
            //employeesTable.Columns.Add("Salary", typeof(double));
            //employeesTable.Columns.Add("Date", typeof(DateTime));
            // Made Primary Key
            //DataColumn[] PrimaryKey = new DataColumn[1];
            //PrimaryKey[0] = employeesTable.Columns["Id"];
            //employeesTable.PrimaryKey = PrimaryKey;
            // 3. Populate the DataTable with row records
            //employeesTable.Rows.Add(1, "Mustafa Ayyan", "Syria", 2000, DateTime.Now);
            //employeesTable.Rows.Add(2, "Adnan Ayyan", "Lebanon", 6000, DateTime.Now);
            //employeesTable.Rows.Add(3, "Muhammed Adel", "Italy", 3000, DateTime.Now);
            //employeesTable.Rows.Add(4, "Mosaab Adnan", "Syria", 6000, DateTime.Now);
            //employeesTable.Rows.Add(5, "Yousef Muhammed", "Palestine", 2000, DateTime.Now);
            DataColumn Column = new DataColumn
            {
                ColumnName = "Id",
                Caption = "Employee Id",
                AutoIncrement = true,
                AutoIncrementSeed = 1,
                AutoIncrementStep = 1,
                ReadOnly = true,
                Unique = true,
                DataType = typeof(int)
            };
            employeesTable.Columns.Add(Column);
            Column = new DataColumn
            {
                ColumnName = "Name",
                Caption = "Employee Name",
                ReadOnly = false ,
                Unique = false ,
                DataType = typeof(string)
            };
            employeesTable.Columns.Add(Column);
            employeesTable.Rows.Add(null, "Mustafa");
            employeesTable.Rows.Add(null, "Adnan");
            Column = new DataColumn
            {
                ColumnName = "Country",
                Caption = "Country Employee",
                ReadOnly = false,
                Unique = false,
                DataType = typeof (string)
            };
            employeesTable.Columns.Add(Column);
            employeesTable.Rows.Add(null, "Mustafa", "Syria");
            employeesTable.Rows.Add(null, "Adnan", "Syria");
            employeesTable.Rows.Add(null, "Mohammed", "Syria");
            // Foreach loop
            foreach(DataRow row in employeesTable.Rows)
            {
                Console.WriteLine($"Id : {row["Id"]} , Name : {row["Name"]}, Country : {row["Country"]} ");
            }
            Console.ReadKey();
        }
    }
}
