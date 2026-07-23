using System;
using System.Data;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using AccessEmployees;
namespace Business_Employees
{
    public class BusinessEmployess
    {
        public enum EnMode { AddMode =1 , UpdateMode =2}
        EnMode Mode = EnMode.AddMode;
        public int EmpId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public double Salary { get; set; }
        public DateTime HireDate { get; set; }
        public string ImagePath { get; set; }
        public int DepartId { get; set; }
        public BusinessEmployess(int EmpId , string FirstName , 
            string LastName , string Email , string Phone , 
            double Salary , DateTime HireDate , string ImagePath , int DepartId)
        {
            this.EmpId = EmpId;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Email = Email;
            this.Phone = Phone;
            this.Salary = Salary ;
            this.HireDate = HireDate;
            this.ImagePath = ImagePath;
            this.DepartId = DepartId;
            Mode = EnMode.UpdateMode;
        }
        public BusinessEmployess()
        {
            this.EmpId = 0;
            this.FirstName = "";
            this.LastName = "";
            this.Email = "";
            this.Phone = "";
            this.Salary = 0;
            this.HireDate = DateTime.Now;
            this.ImagePath = "";
            this.DepartId = 0;
            Mode = EnMode.AddMode;
        }
        public static BusinessEmployess FindEmployees(int id )
        {
            string FirstName = "";
            string LastName = "";
            string Email = "";
            string Phone = "";
            double Salary = 0;
            DateTime HireDate = DateTime.Now;
            int DepartID = 0;
            string ImagePath = "";
            if (AccessEmployees.AccessData.FindEmployees(id,ref FirstName,ref LastName,ref Email,ref Phone,ref Salary , ref DepartID, ref ImagePath,ref HireDate))
            {
                return new BusinessEmployess(id, FirstName, LastName, Email, Phone, Salary, HireDate, ImagePath,DepartID);
            }
            else
            {
                return null;
            }
        }
        public static bool IsDeleted(int Id)
        {
            return AccessData.DeleteEmployees(Id);
        }
        public bool IsAdded()
        {
            this.EmpId = AccessData.AddNewEmployees(this.FirstName, this.LastName,
                this.Email, this.Phone, this.Salary, this.DepartId, this.ImagePath, this.HireDate);
            return (this.EmpId != -1);
        }
        public bool IsUpdate()
        {
            return AccessData.UpdateEmployees(this.EmpId, this.FirstName, this.LastName, this.Email, this.Phone, this.Salary, this.DepartId, this.HireDate, this.ImagePath);
        }
        private bool Condition()
        {
            if(string.IsNullOrWhiteSpace(this.FirstName ) || string.IsNullOrWhiteSpace(this.LastName ) || string.IsNullOrWhiteSpace(this.Email))
            {
                return true;
            }
                if (this.Salary < 3000 || this.DepartId <= 0 || this.HireDate > DateTime.Now)
                {
                    return true ;
                }
                if(AccessData .IsEmailExist(this.Email,this.EmpId))
                {
                return true  ;
                }
            return false ;
        }
        public  bool SaveEmployees()
        {
            switch (Mode)
            {
                case EnMode.AddMode:
                    {
                        if (Condition())
                        {
                            return false;
                        }
                        if (IsAdded())
                        {
                            
                            Mode = EnMode.UpdateMode;
                            return true;
                            
                        }
                        else
                        {
                            return false;
                        }
                    }
                case EnMode.UpdateMode:
                    {
                        if (Condition())
                        { return false; }
                        else
                        { return IsUpdate(); }
                    }
            }
            return false;
        }
        public static DataTable GetAllEmployees_FromAccess()
        {
            return AccessData.GetAllEmployees();
        }
        public static bool IsFound(int Id)
        {
            return AccessData.IsExist(Id);
        }
    }
}