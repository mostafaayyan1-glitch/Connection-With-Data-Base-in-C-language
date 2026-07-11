# 🎯 ADO.NET: Efficient Record Retrieval using `SqlDataReader` and `struct` (Pass by Reference)

Welcome to the fifth project in the C# & SQL Server Database connectivity series! This repository showcases how to cleanly retrieve a full database record using **`SqlDataReader`**, map it onto a custom data structure (**`struct`**), and pass it efficiently using the **`ref`** keyword to optimize memory management.

## 🧠 The Architectural Concept

### 1. Custom Data Structures (`struct`)
Instead of handling loose variables or allocating heavy objects on the Heap for simple data transfer, this project uses a lightweight `struct` (`ContactInfo`). In C#, structs are **Value Types** allocated on the Stack, providing high performance for data encapsulation.

### 2. Pass by Reference (`ref` Keyword)
By default, C# passes structs by value, meaning it creates a complete duplicate/copy of the structure in memory when passed into a method. 
* By utilizing the **`ref`** keyword, we force the program to pass the **actual memory address** of the original struct located in the `Main` method. 
* This allows the database retrieval function to modify the original container directly, entirely eliminating deep-copy overhead.

### 3. Record Existence Checking (`if` vs `while`)
Since we are querying via a unique Primary Key (`ContactId`), the query will either return exactly **one row** or **zero rows**. Therefore, a conditional **`if (reader.Read())`** statement is used rather than a looping `while` structure, ensuring immediate, non-allocating execution.

---

## 💻 Code Showcases

### Optimized Reference Mapping:
```csharp
static bool Find(int Contacts, ref ContactInfo contact)
{
    // ... Connection & Command Setup ...
    SqlDataReader reader = command.ExecuteReader();
    
    if (reader.Read())
    {
        IsFound = true;
        // Direct modification of the original struct via reference
        contact.Id = (int)reader["ContactId"];
        contact.FirstName = (string)reader["FirstName"];
        contact.LastName = (string)reader["LastName"];
        contact.Phone = (string)reader["Phone"];
        contact.Address = (string)reader["Address"];
    }
    // ... Proper Resource Management ...
}
🚀 Features & Flow
Zero-Overhead Transfer: Direct memory manipulation using ref to prevent object/struct cloning.

Secure Parameters: Complete protection against SQL Injection using SqlParameter.

Robust Lifecycle: Demonstrates explicit closing of active datareader streams and connection pipelines.

Refactored and organized for advanced backend engineering portfolios.