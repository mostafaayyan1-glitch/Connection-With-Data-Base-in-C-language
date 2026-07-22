using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
namespace Data_Set_And_Opertation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Create First Data Table
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
            Console.WriteLine("----------------------");
            Console.WriteLine("Print All Employees");
            Console.WriteLine("----------------------");
            foreach (DataRow Row in employeesTable.Rows)
            {
                Console.WriteLine($"ID : {Row["Id"]} , Name : {Row["Name"]} , Country : {Row["Country"]} , Salary : {Row["Salary"]} , DataOfBirth {Row["Date"]} ");
            }
            // Create Second Data Table
            DataTable Department = new DataTable("Department");
            Department.Columns.Add("Department_ID",typeof(int));
            Department.Columns.Add("Name", typeof(String));
            // Add Rows 
            Department.Rows.Add(1, "Marketing");
            Department.Rows.Add(2, "Sales");
            Department.Rows.Add(3, "It");
            Console.WriteLine("----------------------");
            Console.WriteLine("Print All Department");
            Console.WriteLine("----------------------");
            foreach(DataRow Row in Department.Rows)
            {
                Console.WriteLine($"Id_Department : {Row["Department_ID"]} , Name : {Row["Name"]} ");
            }
            DataSet EmployeesAndDepartment = new DataSet("All Tables");
            EmployeesAndDepartment.Tables.Add(employeesTable);
            EmployeesAndDepartment.Tables.Add(Department);
            Console.WriteLine("------------------------------------------");
            Console.WriteLine("Printing Table Employees But From Data Set");
            Console.WriteLine("------------------------------------------");
            foreach (DataRow Row in EmployeesAndDepartment.Tables["Employees"].Rows )
            {
                Console.WriteLine("Id : {0} , Name : {1} , Country : {2} , Salary : {3} , Date : {4} ", Row["ID"],
                    Row["Name"], Row["Country"], Row["Salary"], Row["Date"]);
            }
            Console.WriteLine("------------------------------------------");
            Console.WriteLine("Printing Table Department But From Data Set");
            Console.WriteLine("------------------------------------------");
            foreach(DataRow Row in EmployeesAndDepartment.Tables["Department"].Rows )
            {
                Console.WriteLine("Department Id : {0} , Name : {1} ", Row["Department_ID"], Row["Name"]);
            }
            // To Print Specifec Thing
            Console.WriteLine(EmployeesAndDepartment.Tables["Department"].Rows[2]["Department_Id"]);
            Console.ReadKey();
        }
    }
}
