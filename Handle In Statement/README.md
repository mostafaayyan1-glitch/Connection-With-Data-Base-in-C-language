# 🎯 ADO.NET: Secure Bulk Deletion via Dynamic Parameterized `IN` Clause

Welcome to the project focusing on executing safe batch mutations in SQL Server using C# and ADO.NET. This repository showcases how to implement a **DELETE** operation over multiple primary keys using the SQL `IN` operator while completely neutralizing SQL Injection vulnerabilities.

## 🧠 Architectural Insights

### 1. The Vulnerability of Static IN String Concatenation
When dealing with an `IN` clause (e.g., `IN (6,7,8)`), passing a raw concatenated string directly into the SQL textual layout strips away the security layer provided by default ADO.NET parameters, re-exposing the application to lethal **SQL Injection** payloads.

### 2. The Dynamic Parameterization Solution
To enforce an absolute security standard, this implementation introduces **Dynamic Parameterization**:
* The raw string payload is split into individual array fragments via `.Split(',')`.
* An isolated parameter placeholder (`@Id0`, `@Id1`, etc.) is dynamically generated and securely added to the `SqlCommand.Parameters` collection for each target element.
* The query is compiled dynamically inside the runtime safely without embedding raw user parameters.

### 3. Resource Lifecycle Safety
A resilient structural `try-catch-finally` block isolates the lifecycle of the `SqlConnection`. The backend guarantees resource disposal and system de-allocation inside the `finally` statement, blocking potential network connection leaks.

---

## 💻 Core Logic Implementation

```csharp
string[] idList = ContactsId.Split(',');
string[] parameterNames = new string[idList.Length];

for (int i = 0; i < idList.Length; i++)
{
    parameterNames[i] = "@Id" + i;
    command.Parameters.AddWithValue(parameterNames[i], idList[i].Trim());
}

command.CommandText = $"Delete from Contacts where ContactId in ({string.Join(",", parameterNames)})";
🚀 Engineering Takeaways
Bulk Operation Safety: Mutating multiple records securely without looping multiple individual round-trips to the DB instance.

SQL Injection Neutralization: Demonstrating full control over query building under structural text parameters.

Engineered for secure enterprise data layers.