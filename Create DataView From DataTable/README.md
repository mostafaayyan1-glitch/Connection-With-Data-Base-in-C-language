# C# ADO.NET Dynamic DataView Filtering & Sorting 🚀

This project demonstrates advanced data manipulation techniques using the **DataView** class (`DefaultView`) over an in-memory **DataTable** in C# and ADO.NET.

It explicitly showcases how a `DataView` acts as a **dynamic live window** (pointer-based), allowing real-time multi-criteria filtering and chained sorting without duplicating or altering the underlying raw data in the RAM.

---

## 🧠 Key Architectures & Concepts Explored

### 1. Dynamic Live Filtering (`RowFilter`)
Demonstrates how to apply compound SQL-like logical expressions (`Or` criteria) to instantly filter the visible rows down to specific subsets:
```csharp
EmpemoyeesView.RowFilter = "Country = 'Syria' Or Country = 'Jordan'";
2. Chained Data Presentation (Sort)
Demonstrates how to easily chain sorting properties (Name Asc) directly on top of an already filtered view, dynamically altering the index presentation layer for UI layouts.

3. Pointer-Based Architecture vs. Snapshots
Highlights the architectural difference between DataTable.Select() (which takes a static snapshot) and DataView (which uses live memory pointers), ensuring that any updates to the original DataTable propagate instantly and inevitably to the active view.

📂 Execution Workflow
Schema Definition: Creates a 5-column structured schema (Id, Name, Country, Salary, Data_Of_Birth).

Data Ingestion: Populates rows manually using strict sequential primary IDs.

Raw Data Loop: Prints the raw table state directly from memory.

Dynamic RowFilter Application: Filters the view to present only Syrian and Jordanian employees.

Alphabetical Sorting: Organizes the filtered subset from A to Z using the Name column.