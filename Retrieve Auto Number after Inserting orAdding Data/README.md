ADO.NET: Retrieving Newly Generated Identity ID using `ExecuteScalar`

Welcome to the seventh project in the C# & SQL Server Database connectivity series! This repository demonstrates how to securely insert records into a SQL Server database and immediately fetch the newly generated auto-incremented Identity column value using **`SCOPE_IDENTITY()`** and **`ExecuteScalar`**.

## 🧠 The Architectural Concept

### 1. The Purpose of `ExecuteScalar`
Unlike `ExecuteNonQuery` (which only returns the number of affected rows as an integer), **`ExecuteScalar`** is designed to execute a query and return the first column of the first row in the result set. It is the ideal choice for fetching single values, such as newly generated IDs or aggregate results (`COUNT`, `SUM`, `MAX`).

### 2. Merging SQL Batches with `SCOPE_IDENTITY()`
By appending `; SELECT SCOPE_IDENTITY();` to the insertion statement, we force SQL Server to execute both operations in a single database round-trip. `SCOPE_IDENTITY()` returns the last identity value inserted into an identity column in the same execution scope, ensuring complete thread safety.

### 3. Defensive Parsing & Object Handling
Because `ExecuteScalar` returns a generic `object`, defensive type-checking is required. This project implements a robust check (`Result != null && int.TryParse(...)`) to ensure the application won't crash if the database fails to return a valid numeric seed.

---

## 💻 Code Showcases

### Fetching Identity ID on Insertion:
```csharp
static void AddNewContactAndGetId(StContact contact)
{
    SqlConnection connection = new SqlConnection(StringConnection);
    string Query = @"Insert Into Contacts (FirstName, LastName, Email, Phone, Address, CountryId) 
                     Values (@FirstName, @LastName, @Email, @Phone, @Address, @CountryId);
                     SELECT SCOPE_IDENTITY();";

    SqlCommand command = new SqlCommand(Query, connection);
    // ... parameters mapping ...

    try
    {
        connection.Open();
        object Result = command.ExecuteScalar(); // Using the scalar hunter!

        if (Result != null && int.TryParse(Result.ToString(), out int id))
        {
            Console.WriteLine($"Newly Inserted Contact ID: {id}");
        }
    }
    catch (Exception Ex)
    {
        Console.WriteLine("Error, " + Ex.Message);
    }
    finally
    {
        if (connection.State == System.Data.ConnectionState.Open)
            connection.Close(); // Defensive connection lifecycle management
    }
}
🚀 Key Learning Takeaways
The Scalar Hunter: Understanding when to use ExecuteScalar versus ExecuteNonQuery.

Defensive Validation: Safeguarding application state through int.TryParse output mapping.

Atomic Batches: Merging multiple SQL commands safely using the semicolon ; character.

Refactored and organized for advanced backend engineering portfolios.