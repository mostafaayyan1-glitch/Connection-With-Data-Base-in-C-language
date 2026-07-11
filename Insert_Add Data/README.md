]# 🎯 ADO.NET: Secure Record Insertion using `ExecuteNonQuery` and Struct Data Mapping

Welcome to the sixth project in the C# & SQL Server Database connectivity series! This repository demonstrates how to perform safe data insertion operations into a database using **`ExecuteNonQuery`**, secure SQL parameters to mitigate injection risks, and encapsulation using a lightweight **`struct`**.

## 🧠 The Architectural Concept

### 1. The Power of `ExecuteNonQuery`
Unlike `ExecuteReader` (which streams rows) or `ExecuteScalar` (which retrieves a single cell), **`ExecuteNonQuery`** is dedicated strictly to state-changing commands (INSERT, UPDATE, DELETE). 
* It returns an `int` value representing the number of rows affected by the transaction.
* Evaluating this integer (`RowsEffected > 0`) is the industry standard for verification of database state changes.

### 2. Parameterized Queries (`@` Placeholders)
To enforce strict boundaries between executable SQL code and user input, this project avoids string concatenation entirely. Using `command.Parameters.AddWithValue` explicitly wraps the inputs, completely eliminating **SQL Injection** risks.

### 3. Connection Lifecycle (`finally` Block)
Database connections are expensive OS resources. This code uses a structured `try-catch-finally` block ensuring the connection pipeline is explicitly closed in the `finally` block, ensuring no leaked connections even if runtime exceptions occur.

---

## 💻 Code Showcases

### Secure Data Insertion:
```csharp
static void InsertOneRow(ContactInfo contact)
{
    SqlConnection connection = new SqlConnection(StringConnection);
    string Query = @"Insert Into Contacts (FirstName, LastName, Email, Phone, Address, CountryId)
                    Values (@FirstName, @LastName, @Email, @Phone, @Address, @CountryId)";
                    
    SqlCommand command = new SqlCommand(Query, connection);

    // Secure Binding
    command.Parameters.AddWithValue("@FirstName", contact.FirstName);
    command.Parameters.AddWithValue("@LastName", contact.LastName);
    // ... remaining parameters ...

    try
    {
        connection.Open();
        int RowsEffected = command.ExecuteNonQuery();
        
        if (RowsEffected > 0)
            Console.WriteLine("Inserted Successfully");
    }
    catch (Exception Ex)
    {
        Console.WriteLine("Error, " + Ex.Message);
    }
    finally
    {
        if (connection.State == System.Data.ConnectionState.Open)
            connection.Close(); // Guaranteed structural cleanup
    }
}
🚀 Features & Engineering Design
Encapsulated Transit: Utilizing a struct for stack-allocated data transport from Main to the database layer.

Defensive Programming: Integration of deterministic cleanup logic (finally) to safeguard memory and connection pools.

Data Integrity Verification: Accurate validation checking through operational return states.

Refactored and organized for advanced backend engineering portfolios.