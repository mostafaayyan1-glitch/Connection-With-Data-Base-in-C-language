# 🎯 ADO.NET: Efficient Single-Value Retrieval using `ExecuteScalar`

Welcome to the fourth project in the C# & SQL Server Database connectivity series! This repository demonstrates how to optimally retrieve a single value (a scalar value) from a database using **`ExecuteScalar`** and secure **Parameterized Queries**.

## 🧠 The Architectural Concept
When an SQL query returns a dataset, but you only need a specific single cell (e.g., a specific contact's phone number, name, or an aggregate like `COUNT(*)`), using a full `SqlDataReader` introduces unnecessary resource overhead. 

The **`ExecuteScalar`** method is designed precisely for this scenario. It executes the query and returns the value located at the **first column of the first row** of the returned result set, ignoring all other data columns or rows.

### 🛠️ Key Highlights of this Implementation:
* **Targeted Queries**: Fetches precise data fields (such as `Phone`) based on a unique identifier (`ContactId`).
* **Result-Set Focus**: Demonstrates that `ExecuteScalar` doesn't care about the layout of the source table, but rather grabs the top-left cell of the final *filtered result*.
* **Parameterized Security**: Employs `SqlParameter` to entirely eliminate SQL Injection vulnerabilities.
* **Null-Safety Checking**: Properly handles scenarios where the requested record might not exist (`Result != null`).

---

## 💻 Code Showcases

### Secure Scalar Execution:
```csharp
// Target a single piece of data based on a parameter
string Query = "Select Phone From Contacts Where ContactId = @ContactId";
SqlCommand command = new SqlCommand(Query, connection);
command.Parameters.AddWithValue("@ContactId", ContactId);

// Execute and retrieve the first cell of the result set
object Result = command.ExecuteScalar();
if(Result != null)
{
    Phone = Result.ToString();
}
🚀 Features & Flow
Resource Efficiency: Bypasses the reader loop, ensuring faster execution for single-item lookups.

Graceful Error Catching: Utilizes structured try-catch blocks to safely handle database engine exceptions.

Clean Architecture: Encapsulates data access inside a reusable, parameterized method.

Refactored and organized for advanced backend engineering portfolios.