# 🎯 ADO.NET: Data Deletion with Parameterized Security via `ExecuteNonQuery`

Welcome to the eighth project in the C# & SQL Server Database connectivity series! This repository focuses on implementing a safe and secure **DELETE** operation within a relational database using defense-in-depth programming.

## 🧠 Architectural Insights

### 1. The Role of `ExecuteNonQuery` in Mutation
Since a `DELETE` statement alters the state of the database tables without returning a result set or a single calculated value, **`ExecuteNonQuery`** is utilized. It returns an integer representing the exact number of rows deleted from the database.

### 2. Defending Against SQL Injection
Instead of concatenating input variables into raw SQL strings, this project enforces strict parameterization using `command.Parameters.AddWithValue`. This ensures that payload triggers are strictly treated as data literals rather than executable SQL statements.

### 3. Connection Lifecycle Guarantee
To avoid database connection leaks, the implementation enforces structural defensive resource management using a `try-catch-finally` block. The connection is guaranteed to be shut down properly within the `finally` segment, ensuring maximum performance under high workloads.

---

## 💻 Core Code Snippet

```csharp
string Query = @"Delete From Contacts Where ContactId = @ContactId";
SqlCommand command = new SqlCommand(Query, connection);
command.Parameters.AddWithValue("@ContactId", ContactId);

try
{
    connection.Open();
    int RowsEffected = command.ExecuteNonQuery();
    if (RowsEffected > 0)
    {
        Console.WriteLine("Delete successful");
    }
    else
    {
        Console.WriteLine("Failed Delete: ID not found.");
    }
}
finally
{
    if (connection.State == System.Data.ConnectionState.Open)
        connection.Close();
}
🚀 Key Architectural Takeaways
Defensive Resource Management: Utilizing finally guarantees that hardware/network resources are never leaked.

Row Effect Evaluation: Using the integer output of ExecuteNonQuery to check whether the targeted record existed prior to execution.

Refactored and organized for advanced backend engineering portfolios.