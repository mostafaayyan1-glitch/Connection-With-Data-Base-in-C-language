using System;
using System.Data;
using System.Linq;
namespace Delete_Row_From_Data_Table_OffLine
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 1. Create DataTable in memory (RAM)
            DataTable employeesTable = new DataTable("Employees");

            // 2. Define the schema and specify data types for strict type safety
            employeesTable.Columns.Add("Id", typeof(int));
            employeesTable.Columns.Add("Name", typeof(string));
            employeesTable.Columns.Add("Country", typeof(string));
            employeesTable.Columns.Add("Salary", typeof(double));
            employeesTable.Columns.Add("Date", typeof(DateTime));

            // 3. Populate the DataTable with row records
            employeesTable.Rows.Add(1, "Mustafa Ayyan", "Syria", 2000, DateTime.Now);
            employeesTable.Rows.Add(2, "Adnan Ayyan", "Lebanon", 6000, DateTime.Now);
            employeesTable.Rows.Add(3, "Muhammed Adel", "Italy", 3000, DateTime.Now);
            employeesTable.Rows.Add(4, "Mosaab Adnan", "Syria", 6000, DateTime.Now);
            employeesTable.Rows.Add(5, "Yousef Muhammed", "Palestine", 2000, DateTime.Now);
            Console.WriteLine();
            foreach (DataRow row in employeesTable.Rows)
            {
                Console.WriteLine($"Id : {row["Id"]} | Name : {row["Name"]} | Salary : {row["Salary"]} | Country : {row["Country"]} | Date : {row["Date"]}   ");
            }
            DataRow[] Row = employeesTable.Select("Id = 1");
            foreach(var Item in Row)
            {
                Item.Delete();
            }
            employeesTable.AcceptChanges();
            Console.WriteLine();
            foreach (DataRow row in employeesTable.Rows)
            {
                Console.WriteLine($"Id : {row["Id"]} | Name : {row["Name"]} | Salary : {row["Salary"]} | Country : {row["Country"]} | Date : {row["Date"]}   ");
            }
            // Update Rows
            Console.WriteLine();
            DataRow[] dataRows = employeesTable.Select("Id = 4");
            foreach (var Item in dataRows)
            {
                Item["Name"] = "Yousef Adnan";
                Item["Salary"] = "650";
            }
            foreach(DataRow row in employeesTable.Rows)
            {
                Console.WriteLine($"Id : {row["Id"]} | Name : {row["Name"]} | Salary : {row["Salary"]} | Country : {row["Country"]} | Date : {row["Date"]}   ");
            }
            // Delete All Data From Data Table
            employeesTable.Clear();
            foreach (DataRow row in employeesTable.Rows)
            {
                Console.WriteLine($"Id : {row["Id"]} | Name : {row["Name"]} | Salary : {row["Salary"]} | Country : {row["Country"]} | Date : {row["Date"]}   ");
            }
            Console.ReadKey();
        }
    }
}
