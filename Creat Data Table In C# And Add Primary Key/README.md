# C# ADO.NET DataTable Primary Key Demonstration 🔑

A focused, console-based demonstration of in-memory **DataTable** schema definition in C# using ADO.NET (Offline Mode), specifically highlighting how to enforce unique records using a **Primary Key**.

This repository showcases the architectural approach to setting single or composite primary keys and seeding strongly-typed data safely in RAM.

---

## 🛠️ Features Demonstrated
- **Strict Schema Definition:** Explicitly defines columns with strict type safety.
- **Primary Key Enforcement:** Demonstrates how to register a `DataColumn[]` array to the table's `PrimaryKey` property.
- **Composite Key Ready:** Built using the standard array architecture, paving the way for multi-column identifiers.
- **In-Memory Data Seeding:** Populates the structured schema with sample record rows directly in the RAM.

---

## 💻 Code Highlight: Primary Key Architecture

Instead of assigning a single column directly, ADO.NET requires a **DataColumn Array** to support potential composite keys (multiple columns forming a single unique identifier):

```csharp
// 1. Declare a column array with a size of 1 (for a single primary key)
DataColumn[] primaryKeyColumn = new DataColumn[1];

// 2. Reference the target column at index 0
primaryKeyColumn[0] = employeesTable.Columns["Id"];

// 3. Assign the array to the DataTable's PrimaryKey property
employeesTable.PrimaryKey = primaryKeyColumn;
📂 Run Locally
Clone this repository.

Open the project in Visual Studio or VS Code.

Run the application (F5 or dotnet run)
