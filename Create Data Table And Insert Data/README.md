# 🎯 ADO.NET: In-Memory Data Manipulation, Aggregation, and Sorting via `DataTable`

Welcome to the ninth project in the C# & ADO.NET connectivity series! This repository showcases advanced memory-resident database engineering by constructing, filtering, analyzing, and sorting complex relational datasets directly within the computer's RAM using the ADO.NET `DataTable` object.

---

## 🧠 Architectural Insights

### 1. The Power of In-Memory Data Storage (`DataTable`)
Instead of keeping expensive and continuous live connections open to physical databases (like SQL Server or MS Access), this project leverages the **Disconnected Architecture** of ADO.NET. A structured dataset is designed, allocated, and constrained inside RAM, guaranteeing lightning-fast manipulation speeds and offline resilience.

### 2. Dynamic In-Memory Aggregations via `Compute`
The program demonstrates how to execute relational-algebra operations on dynamic datasets without delegating the work back to database engines. By calling the `DataTable.Compute` method, aggregate functions such as `Sum`, `Avg`, `Min`, and `Max` are executed programmatically with variable runtime search-filters.

### 3. Dynamic Selection, Logical Operators, and Compound Queries
Using the `DataTable.Select` method, this implementation simulates SQL-like querying on in-memory collections. The project implements:
- **Exact Matches:** Filtering data utilizing numeric primary lookups (e.g., `Id = 1`).
- **Compound Queries:** Utilizing boolean relational operators (e.g., `Country = 'Syria' Or Country = 'Palestine'`) to construct robust array filters.

### 4. Advanced Sorting via `DefaultView` State-Machine
Rather than writing costly sorting algorithms (like QuickSort or BubbleSort) from scratch, this solution demonstrates how to manipulate the native `DefaultView` of the `DataTable` structure. Setting the `DefaultView.Sort` metadata dynamically builds sorted table schemas (e.g., `Id Desc` or `Name Asc`) and exports them safely into fresh decoupled data tables using `ToTable()`.

---

## 💻 Core Code Snippet

The logic employs clean-code, DRY (Don't Repeat Yourself) design patterns. Here is the architectural core showing how filtered data-subsets and statistical calculations are derived programmatically:

```csharp
// Dynamically compute statistical data on custom filtered subsets inside memory
private static void PrintStatistics(DataTable table, string filter)
{
    int count = table.Select(filter).Length;
    if (count == 0) return;

    double total   = Convert.ToDouble(table.Compute("Sum(Salary)", filter));
    double average = Convert.ToDouble(table.Compute("Avg(Salary)", filter));
    double min     = Convert.ToDouble(table.Compute("Min(Salary)", filter));
    double max     = Convert.ToDouble(table.Compute("Max(Salary)", filter));

    Console.WriteLine($"Count: {count} | Total: {total} | Average: {average}");
}
🚀 Key Architectural Takeaways
Resource Preservation: Bypasses continuous database roundtrips by keeping dataset manipulations entirely local to RAM.

Strongly-Typed Column Definitions: Restricting column types (e.g., typeof(int)) preserves type-safety and triggers runtime exceptions if constraints are violated.

Polymorphic DataViews: Facilitates safe UI-binding processes (e.g., GridViews and ComboBoxes) by decoupling raw table schemas from active UI sorting behaviors.