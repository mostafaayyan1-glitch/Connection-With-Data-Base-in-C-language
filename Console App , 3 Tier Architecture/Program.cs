using Business_Layer_contact;
using ClsCountry_Business_Layer;
using System;
using System.Data;
internal class Program
{
    public static void TestFind(int Id)
    {
        ClsContact contact = ClsContact.Find(Id);
        if (contact != null)
        {
            Console.WriteLine(contact.FirstName);
            Console.WriteLine(contact.LastName);
            Console.WriteLine(contact.Email);
            Console.WriteLine(contact.Address);
            Console.WriteLine(contact.Phone);
            Console.WriteLine(contact.DateOfBirth);
            Console.WriteLine(contact.CountryId);
            Console.WriteLine(contact.ImagePath);
        }
        else
        {
            Console.WriteLine("Not Found");
        }
    }
    public static void TestInsert()
    {
        ClsContact contact = new ClsContact();
        contact.FirstName = "Mustafa";
        contact.LastName = "Ayyan";
        contact.Email = "Mus@gmail.com";
        contact.Phone = "0985128034";
        contact.ImagePath = "";
        contact.Address = "Aleppo";
        contact.CountryId = 1;
        contact.DateOfBirth = new DateTime(2006, 8, 28, 3, 43, 4);
        if (contact.Save())
        {
            Console.WriteLine("Yes ,, Saved");
        }
        else
        {
            Console.WriteLine("Error");
        }
    }
    public static void TestUpdate(int Id)
    {
        ClsContact contact = ClsContact.Find(Id);
        if (contact != null)
        {
            contact.FirstName = "Adnan";
            contact.LastName = "Ayyan";
            contact.Email = "adn@gmail.com";
            contact.Phone = "0908897";
            contact.Address = "Aleppo";
            contact.DateOfBirth = DateTime.Now;
            contact.CountryId = 2;
            contact.ImagePath = "";

            // تم التعديل من save() إلى Save()
            if (contact.Save())
            {
                Console.WriteLine("Yes");
            }
            else
            {
                Console.WriteLine("no");
            }
        }
        else
        {
            Console.WriteLine("Not Found");
        }
    }

    public static void TestDelete(int Id)
    {
        // تم التعديل من IsExistFromAccess إلى Exists
        if (ClsContact.Exists(Id))
        {
            if (ClsContact.Delete(Id))
            {
                Console.WriteLine("Success Delete");
            }
            else
            {
                Console.WriteLine("Failed Delete");
            }
        }
        else
        {
            Console.WriteLine("Not Found My bro");
        }
    }

    public static void TestGetAllContact()
    {
        // تم التعديل من GetAllcontactfromaccess إلى GetAllContacts
        DataTable dataTable = ClsContact.GetAllContacts();
        Console.WriteLine("Data Info");
        foreach (DataRow row in dataTable.Rows)
        {
            Console.WriteLine($"{row["ContactId"]}, {row["FirstName"]} {row["LastName"]}");
        }
    }

    public static void TestIsExist(int Id)
    {
        // تم التعديل من IsExistFromAccess إلى Exists
        if (ClsContact.Exists(Id))
        {
            Console.WriteLine("Found My Bro");
        }
        else
        {
            Console.WriteLine("Not Found My Bro");
        }
    }

    public static void TestFindCountry(int Id)
    {
        BusinessCountry country = BusinessCountry.GetCountryFromAccess(Id);
        if (country != null)
        {
            Console.WriteLine(country.CountryName);
            Console.WriteLine(country.CountryId);
            Console.WriteLine(country.PhoneCode);
            Console.WriteLine(country.CodeCountries);
        }
        else
        {
            Console.WriteLine("Not Found");
        }
    }

    public static void TestInsertCountry()
    {
        BusinessCountry country = new BusinessCountry();
        country.CountryName = "Syria";
        country.PhoneCode = "12";
        country.CodeCountries = "1";
        if (country.Save())
        {
            Console.WriteLine("Success Insertion");
        }
        else
        {
            Console.WriteLine("Failed Insertion");
        }
    }

    public static void TestUpdateCountry(int Id)
    {
        BusinessCountry country = BusinessCountry.GetCountryFromAccess(Id);
        if (country != null)
        {
            country.CountryName = "Italy";
            country.CodeCountries = "2";
            country.PhoneCode = "3";
            if (country.Save())
            {
                Console.WriteLine("Updated :-)");
            }
            else
            {
                Console.WriteLine("Not Updated :-(");
            }
        }
        else
        {
            Console.WriteLine("Failed ,, Not Found");
        }
    }

    public static void TestDeleteCountry(int Id)
    {
        // تم تعديل السبيلينغ من ExistFromAcces إلى ExistFromAccess
        if (BusinessCountry.ExistFromAccess(Id))
        {
            if (BusinessCountry.DeleteCountryByAccess(Id))
            {
                Console.WriteLine("Deleted :-)");
            }
            else
            {
                Console.WriteLine("Not Deleted :-(");
            }
        }
        else
        {
            Console.WriteLine("Not Found");
        }
    }

    public static void TestGetAllCountries()
    {
        DataTable dataTable = BusinessCountry.GetAllCountriesFromAccess();
        Console.WriteLine("Countries Info");
        foreach (DataRow row in dataTable.Rows)
        {
            Console.WriteLine($"{row["CountryId"]} , {row["CountryName"]}, {row["CodeCountries"]}, {row["PhoneCode"]}");
        }
    }

    public static void TestExistCountry(int Id)
    {
        if (BusinessCountry.ExistFromAccess(Id))
        {
            Console.WriteLine("Found :-)");
        }
        else
        {
            Console.WriteLine("Not Found :-(");
        }
    }

    static void Main(string[] args)
    {
        // TestFind(5);
        // TestInsert();
        // TestUpdate(2);
        // TestDelete(9);
        // TestGetAllContact();
        // TestIsExist(7);
        // TestFindCountry(3);
        // TestInsertCountry();
        // TestUpdateCountry(3);
        // TestDeleteCountry(6);
        // TestGetAllCountries();
        // TestExistCountry(2);

        Console.ReadKey();
    }
}