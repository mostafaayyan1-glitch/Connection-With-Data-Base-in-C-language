# 🔍 ADO.NET: Safe Pattern Matching with SQL 'LIKE' Operator

Welcome to the third project in the C# & SQL Server Database connectivity series! This project demonstrates how to perform dynamic text searching using the SQL **`LIKE`** operator and wildcards (`%`) while maintaining absolute security using **Parameterized Queries**.

## 🧠 The Architectural Concept
When building search filters (e.g., *Starts With*, *Ends With*, or *Contains*), developers often fall into the trap of insecure string interpolation. 

This repository showcases the professional approach: passing the raw search term as a safe `SqlParameter` and letting the SQL Server handle the wildcard concatenation using the database-level `+` operator.

### 🛠️ Search Mechanics Implemented:
* **Starts With Filter (`Value%`)**: Fetches records where the field begins with the specific string.
* **Ends With Filter (`%Value`)**: Fetches records where the field terminates with the specific string.
* **Contains Filter (`%Value%`)**: Fetches records where the string exists anywhere within the field.

---

## 💻 Code Showcases

### Dynamic and Secure Concatenation inside SQL:
```csharp
// The safe way to combine wildcards with parameters in ADO.NET
string Query = "Select * From Contacts Where FirstName Like '%' + @Contain + '%'";
SqlCommand command = new SqlCommand(Query, connection);

// Binding pure data to the query structure
command.Parameters.AddWithValue("@Contain", Contain);
🚀 Features & Flow
Case-Insensitive Querying: Leverages SQL Server's default collation for smooth text matching.

Resource Management: Safe opening and explicit closing of SqlConnection and SqlDataReader.

Robust Error Handling: Structured try-catch blocks to capture and print database engine exceptions gracefully.

Refactored and organized for advanced backend engineering portfolios.