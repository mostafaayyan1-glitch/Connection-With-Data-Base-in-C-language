# C# ADO.NET Offline DataTable CRUD Operations 🚀

A structured, clean, and console-based demonstration of in-memory **DataTable** manipulation in C# using ADO.NET (Offline Mode). 

This repository showcases how to dynamically create schemas, insert rows, query/filter records, perform CRUD (Update & Delete) actions safely using `AcceptChanges()`, and manage memory states.

---

## 🛠️ Features Demonstrated
- **Schema Blueprint:** Strict type-safety by defining dynamic columns.
- **Data Population:** Seeding mock records directly in RAM.
- **In-Memory Filtering:** Selecting precise data rows using SQL-like syntax in `.Select()`.
- **Soft Deletion:** Utilizing `.Delete()` combined with `.AcceptChanges()` to safely remove rows.
- **Data Modification:** Querying and live updating specific cells.
- **Memory Flushing:** Clearing data completely with `.Clear()` while preserving schema metadata.

---

## 💻 Code Structure & Logic Flow

```csharp
// 1. Memory Table Setup
DataTable employeesTable = new DataTable("Employees");

// 2. Schema Blueprint & Strict Types
employeesTable.Columns.Add("Id", typeof(int));
employeesTable.Columns.Add("Name", typeof(string));
employeesTable.Columns.Add("Country", typeof(string));
employeesTable.Columns.Add("Salary", typeof(double));
employeesTable.Columns.Add("Date", typeof(DateTime));

// 3. CRUD: Filter & Delete Workflow
DataRow[] rowsToDelete = employeesTable.Select("Id = 1");
foreach(var row in rowsToDelete) {
    row.Delete(); // Marks row for deletion
}
employeesTable.AcceptChanges(); // Commits changes to the memory table
📂 Run Locally
Clone this repository.

Open the project in Visual Studio or VS Code.

Run the application (F5 or dotnet run).

Observe the console output representing various offline lifecycle states of the datatable