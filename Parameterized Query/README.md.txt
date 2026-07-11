# 🛡️ ADO.NET: Parameterized Queries & Database Security

Welcome to the second project of the C# Database Connection course! This project focuses deeply on **Database Security**, specifically demonstrating how to mitigate one of the most dangerous web vulnerabilities: **SQL Injection**.

## 🚀 The Core Problem: SQL Injection
In traditional database connectivity, developers often use **String Concatenation** to build queries:
```csharp
// ⚠️ EXTREMELY DANGEROUS CODE
string Query = "SELECT * FROM Contacts WHERE FirstName = '" + FirstName + "'";
If an attacker inputs malicious payloads like ' OR 1=1; DROP TABLE Contacts; --, the SQL Server executes it blindly, leading to catastrophic data loss or unauthorized access.

🛡️ The Professional Solution: Parameterized Queries
This project implements Parameterized Queries using ADO.NET's SqlCommand.Parameters. By separating the strict Query Structure from the User Data, the SQL Server treats user inputs strictly as literal values (Pure Data), completely neutralizing any embedded executable code.

🔑 Key Implementations inside this Project:
Single Parameter Filtering: Searching contacts securely by FirstName.

Multi-Parameter Filtering: Combining multiple logical conditions (FirstName AND CountryId) within a single query safely.

Scalar Variables Declaration: Ensuring all SQL variables (like @id and @FirstName) are explicitly declared and bound using AddWithValue to prevent runtime exceptions.

💻 Code Preview
Here is how the secure multi-parameter binding is implemented in this repository:

C#
// 1. Define placeholders using the '@' symbol
string Query = "Select * From Contacts Where FirstName = @FirstName and CountryId = @id";
SqlCommand command = new SqlCommand(Query, connection);

// 2. Safely bind pure data variables to the placeholders
command.Parameters.AddWithValue("@FirstName", FirstName);
command.Parameters.AddWithValue("@id", id);
🛠️ Technologies Used
Language: C# (.NET Framework / Console Application)

Database System: Microsoft SQL Server

Data Provider: System.Data.SqlClient (Connected Architecture)

Developed as part of structured Technical Education for mastering Backend Software Engineering.