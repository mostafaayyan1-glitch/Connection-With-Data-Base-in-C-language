# C# ADO.NET Relational In-Memory DataSet Architecture 🚀

This repository contains an advanced console implementation demonstrating how to build a fully disconnected, relational base architecture in system RAM using ADO.NET **DataSet** and **DataTable** objects.

The project models a miniature relational database entirely in memory, showcasing strict type-safety data ingestion, dictionary-based table mapping, and direct multi-dimensional coordinate querying.

---

## 🧠 Core Engineering Concepts Covered

### 1. Disconnected Architecture Layer
The project establishes two decoupled entities (`Employees` and `Department`) in the local system memory, simulating a real-world scenario where data is pulled from a remote server, processed offline to save network bandwidth, and kept in memory for high-performance execution.

### 2. Name-Based Dictionary Accessor vs. Numeric Indexing
Instead of relying on fragile integer positions (`Tables[0]`), this codebase implements robust string-key dictionary accessors. This ensures the application remains maintainable and decoupled from compilation order adjustments:
```csharp
foreach (DataRow Row in EmployeesAndDepartment.Tables["Employees"].Rows)
3. Case-Insensitive Column Resolution
Demonstrates ADO.NET's native internal column mapping engine, allowing columns instantiated as "Department_ID" to be seamlessly queried via different casings (e.g., ["Department_Id"]) without memory faults or runtime failures.

4. Direct Cell Coordinate Accessing (O(1) Memory Offsets)
Highlights how to pull an individual value directly from a multidimensional data cluster using precise grid matrix coordinates without wasting CPU cycles on unnecessary linear iteration loops:

C#
Console.WriteLine(EmployeesAndDepartment.Tables["Department"].Rows[2]["Department_Id"]); // Returns 3
📂 Project Structure & Memory Flow
Schema Initialization: Creating strongly-typed configurations for both the employeesTable and Department schemas.

Data Ingestion: Manually populating raw mock records inside individual memory scopes.

DataSet Compilation: Binding independent database abstractions together inside a single master container object named "All Tables".

Data Grid Navigation: Running data iteration passes and absolute cell coordinate reads directly from the compiled schema container.