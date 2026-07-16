using System;
using System.Data;
using System.Linq;

namespace Create_Data_Table_And_Insert_Data
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 1. Create DataTable in memory (RAM)
            DataTable employeesTable = new DataTable("Employees");

            // 2. Define the schema and specify data types for strict type safety
            employeesTable.Columns.Add("Id", typeof(int));
            employeesTable.Columns.Add("Name", typeof(string));
            employeesTable.Columns.Add("Country", typeof(string));
            employeesTable.Columns.Add("Salary", typeof(double));
            employeesTable.Columns.Add("Date", typeof(DateTime));

            // 3. Populate the DataTable with row records
            employeesTable.Rows.Add(1, "Mustafa Ayyan", "Syria", 2000, DateTime.Now);
            employeesTable.Rows.Add(2, "Adnan Ayyan", "Lebanon", 6000, DateTime.Now);
            employeesTable.Rows.Add(3, "Muhammed Adel", "Italy", 3000, DateTime.Now);
            employeesTable.Rows.Add(4, "Mosaab Adnan", "Syria", 6000, DateTime.Now);
            employeesTable.Rows.Add(5, "Yousef Muhammed", "Palestine", 2000, DateTime.Now);

            // 4. Print the entire original dataset
            Console.WriteLine("================================================================");
            Console.WriteLine("📊 Original Employees Dataset:");
            Console.WriteLine("================================================================");
            PrintTable(employeesTable);

            // 5. Compute and display global statistical calculations (no filter)
            Console.WriteLine("\n📈 Global Statistics (All Employees):");
            Console.WriteLine("----------------------------------------------------------------");
            PrintStatistics(employeesTable, string.Empty);

            // 6. Filter Scenario 1: Retrieve and compute statistics for Syrian employees only
            Console.WriteLine("\n🔍 Filter Scenario 1: Employees from Syria:");
            Console.WriteLine("----------------------------------------------------------------");
            string querySyria = "Country = 'Syria'";
            PrintFilteredData(employeesTable, querySyria);
            PrintStatistics(employeesTable, querySyria);

            // 7. Filter Scenario 2: Compound query (Syrian or Palestinian employees)
            Console.WriteLine("\n🔍 Filter Scenario 2: Employees from Syria OR Palestine:");
            Console.WriteLine("----------------------------------------------------------------");
            string queryCompound = "Country = 'Syria' Or Country = 'Palestine'";
            PrintFilteredData(employeesTable, queryCompound);
            PrintStatistics(employeesTable, queryCompound);

            // 8. Filter Scenario 3: Exact ID lookup match
            Console.WriteLine("\n🔍 Filter Scenario 3: Employee with Id = 1:");
            Console.WriteLine("----------------------------------------------------------------");
            string queryId = "Id = 1";
            PrintFilteredData(employeesTable, queryId);
            PrintStatistics(employeesTable, queryId);

            // 9. Sorting Scenario 1: Sort by ID in descending order
            Console.WriteLine("\n🔄 Sorted List: Id (Descending):");
            Console.WriteLine("----------------------------------------------------------------");
            employeesTable.DefaultView.Sort = "Id Desc";
            DataTable sortedById = employeesTable.DefaultView.ToTable();
            PrintTable(sortedById);

            // 10. Sorting Scenario 2: Sort alphabetically by Name in ascending order
            Console.WriteLine("\n🔄 Sorted List: Name (Ascending):");
            Console.WriteLine("----------------------------------------------------------------");
            employeesTable.DefaultView.Sort = "Name Asc";
            DataTable sortedByName = employeesTable.DefaultView.ToTable();
            PrintTable(sortedByName);

            Console.ReadKey();
        }

        #region Helper Methods (Clean Code Helpers to Avoid Duplication)

        /// <summary>
        /// Dynamically prints any DataTable structure to the CLI console with custom padding.
        /// </summary>
        private static void PrintTable(DataTable table)
        {
            foreach (DataRow row in table.Rows)
            {
                Console.WriteLine($"Id : {row["Id"],-3} | Name : {row["Name"],-16} | Country : {row["Country"],-10} | Salary : {row["Salary"],-6} | Date : {row["Date"]}");
            }
        }

        /// <summary>
        /// Filters the dataset based on the query string and outputs matching rows.
        /// </summary>
        private static void PrintFilteredData(DataTable table, string filter)
        {
            DataRow[] rows = table.Select(filter);
            foreach (DataRow row in rows)
            {
                Console.WriteLine($"Id : {row["Id"],-3} | Name : {row["Name"],-16} | Country : {row["Country"],-10} | Salary : {row["Salary"],-6} | Date : {row["Date"]}");
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Computes in-memory math aggregations (Count, Sum, Avg, Min, Max) based on a query filter.
        /// </summary>
        private static void PrintStatistics(DataTable table, string filter)
        {
            int count = table.Select(filter).Length;
            if (count == 0)
            {
                Console.WriteLine("No records found matching the criteria.");
                return;
            }

            double total = Convert.ToDouble(table.Compute("Sum(Salary)", filter));
            double average = Convert.ToDouble(table.Compute("Avg(Salary)", filter));
            double min = Convert.ToDouble(table.Compute("Min(Salary)", filter));
            double max = Convert.ToDouble(table.Compute("Max(Salary)", filter));

            Console.WriteLine($"Count          : {count}");
            Console.WriteLine($"Total Salary   : {total}");
            Console.WriteLine($"Average Salary : {average}");
            Console.WriteLine($"Min Salary     : {min}");
            Console.WriteLine($"Max Salary     : {max}");
        }

        #endregion
    }
}