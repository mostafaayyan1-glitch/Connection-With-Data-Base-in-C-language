using Business_Employees;
using System;
using System.Configuration;
using System.Data;
namespace Company.self___Initiated_Project
{
    internal class Program
    {
      static void TestFind(int id)
        {
            BusinessEmployess employee = BusinessEmployess.FindEmployees(id);
            if(employee != null)
            {
                Console.WriteLine("Id            : " + employee.EmpId);
                Console.WriteLine("FirstName     : " + employee.FirstName);
                Console.WriteLine("LastName      : " + employee.LastName);
                Console.WriteLine("Phone         : " + employee.Phone);
                Console.WriteLine("Email         : " + employee.Email);
                Console.WriteLine("Salary        : " + employee.Salary);
                Console.WriteLine("Hire Date     : " + employee.HireDate);
                Console.WriteLine("Image Path    : " + employee.ImagePath);
                Console.WriteLine("Department Id : " + employee.DepartId);
            }
            else
            {
                Console.WriteLine("This Employees Is not Found");
            }
        }
        static void TestAdd()
        {
            BusinessEmployess employess = new BusinessEmployess();
            employess.FirstName = "Adnan";
            employess.LastName = "Amir";
            employess.Email = "Adn2@.gmail.com";
            employess.Phone = "099876556";
            employess.DepartId = 3;
            employess.Salary = 2000;
            employess.ImagePath = null;
            employess.HireDate = DateTime.Now;
            if (employess.SaveEmployees())
            {
                Console.WriteLine("Added");
            }
            else
            {
                Console.WriteLine("Not Added");
            }
        }
        static void TestUpdate(int Id)
        {
            BusinessEmployess employess = BusinessEmployess.FindEmployees(Id);
            if(employess!= null)
            {
                employess.FirstName = "Fathia";
                employess.LastName = "Fattosh";
                employess.Email = "FatFat2@gmail.com";
                employess.Phone = "0966898788";
                employess.Salary = 9800;
                employess.ImagePath = "C:\\Users\\HP\\Pictures\\Screenshots";
                employess.HireDate = DateTime.Now;
                if (employess.SaveEmployees())
                {
                    Console.WriteLine("Updated");
                }
                else
                {
                    Console.WriteLine("Not Updated");
                }
            }
        }
        static void TestDeleted(int Id)
        {
            if (BusinessEmployess.FindEmployees(Id) != null)
            {
                if(BusinessEmployess.IsDeleted(Id))
                {
                    Console.WriteLine("This Id Is Deleted");
                }
                else
                {
                    Console.WriteLine("Not Deleted");
                }
            }
            else
            {
                Console.WriteLine("This Employee Is Not Found");
            }
        }
        static void TestGetEmployees()
        {
            DataTable table = BusinessEmployess.GetAllEmployees_FromAccess();
            Console.WriteLine("All Employees");
            foreach (DataRow Row in table.Rows)
            {
                Console.WriteLine($" {Row["EmployeeID"]} , {Row["FirstName"]} , {Row["LastName"]}");
            }
        }
        static void TestIsExist(int Id)
        {
            if (BusinessEmployess.IsFound(Id))
            {
                Console.WriteLine("Found");
            }
            else
            {
                Console.WriteLine("Not Found");
            }
        }
        static void Main(string[] args)
        {
            //TestFind(10);
            //TestAdd();
            //TestUpdate(2);
            //TestDeleted(6);
            //TestGetEmployees();
            //TestIsExist(3);
            Console.ReadKey();
        }
    }
}
