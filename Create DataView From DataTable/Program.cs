using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Data;
using System.Linq;
namespace Create_DataView_From_DataTable
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DataTable EmployeeTable = new DataTable("Employess");
            EmployeeTable.Columns.Add("Id", typeof(int));
            EmployeeTable.Columns.Add("Name", typeof(String));
            EmployeeTable.Columns.Add("Country", typeof(string));
            EmployeeTable.Columns.Add("Salary", typeof(double));
            EmployeeTable.Columns.Add("Data_Of_Birth", typeof(DateTime));

            EmployeeTable.Rows.Add(1, "Mustafa", "Jordan", 9000, DateTime.Now);
            EmployeeTable.Rows.Add(2, "Adnan", "Syria", 4000, DateTime.Now);
            EmployeeTable.Rows.Add(3, "Ahmed", "Lebanon", 5000, DateTime.Now);
            EmployeeTable.Rows.Add(4, "Waddah", "Syria", 7000, DateTime.Now);
            EmployeeTable.Rows.Add(5, "Abul_Abbad", "Jordan", 3000, DateTime.Now);

            foreach (DataRow Row  in EmployeeTable.Rows)
            {
                Console.WriteLine($"ID : {Row["Id"]} , Name : {Row["Name"]} , Country : {Row["Country"]} , Salary : {Row["Salary"]} , DataOfBirth {Row["Data_Of_Birth"]} ");
            }
            // Creat DataTable From Data View And Print Then 
            DataView EmpemoyeesView = EmployeeTable.DefaultView;
            Console.WriteLine(" ,, All Employees From DataTable");
            for(int i = 0; i < EmpemoyeesView.Count; i++)
            {
                Console.WriteLine("{0} , {1} , {2} , {3} ", EmpemoyeesView[i][0], EmpemoyeesView[i][1], EmpemoyeesView[i][2], EmpemoyeesView[i][3]);
            }
            // Creat Query to Select Many Employees 
           // Console.WriteLine(",, After Filtering Data Table Bu Data View");
           // EmpemoyeesView.RowFilter = "Country = 'Syria' Or Country = 'Jordan' ";
           // for (int i = 0; i < EmpemoyeesView.Count; i++)
           // {
           //     Console.WriteLine("{0} , {1} , {2} , {3} ", EmpemoyeesView[i][0], EmpemoyeesView[i][1], EmpemoyeesView[i][2], EmpemoyeesView[i][3]);
           // }
            // Sorting Data In Data View
            EmpemoyeesView.Sort = "Name Asc";
            Console.WriteLine("After Sort Data Table By Data View");
            for (int i = 0; i < EmpemoyeesView.Count; i++)
            {
                Console.WriteLine("{0} , {1} , {2} , {3} ", EmpemoyeesView[i][0], EmpemoyeesView[i][1], EmpemoyeesView[i][2], EmpemoyeesView[i][3]);
            }
            Console.ReadKey();
        }
    }
}