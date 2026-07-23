using Access_Department;
using System;
using System.Data;
namespace Business_Department
{
    public class Class1
    {
        public static DataTable GetAllDepartments()
        {
            return AccessData.AllDepartment();
        }
    }
}
