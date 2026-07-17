# C# ADO.NET DataTable Column Properties Exploration ⚙️

This project demonstrates advanced **DataColumn** configuration within an in-memory **DataTable** using C# and ADO.NET. 

It highlights the exact property configurations required for automating data-entry behaviors (like primary keys) versus manual text fields.

---

## 🔑 Key Concepts Explored

### 1. Auto-Incrementing Numeric Keys
To let the RAM handle sequential IDs automatically, the `Id` column is configured with:
- `AutoIncrement = true`
- `AutoIncrementSeed = 1` (Starts at 1)
- `AutoIncrementStep = 1` (Increments by 1 for each new row)
- `ReadOnly = true` (Prevents manual edits to ensure data integrity)

### 2. Variable Reusability (OOP Concept)
Demonstrates how to efficiently reuse a single `DataColumn` reference variable to initialize and add multiple distinct columns to the table schema sequentially.

> **Note:** Always remember to call `Columns.Add()` for each instantiated column *before* reassignment, and ensure non-numeric fields (like `string` names) do not have `AutoIncrement` enabled.