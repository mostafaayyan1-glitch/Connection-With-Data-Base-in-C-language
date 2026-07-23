# 🚀 Employee Management System (3-Tier Architecture)

![C#](https://img.shields.io/badge/Language-C%23-blue.svg)
![Framework](https://img.shields.io/badge/Framework-.NET%20WinForms-purple.svg)
![Architecture](https://img.shields.io/badge/Architecture-3--Tier%20(UI--BLL--DAL)-green.svg)
![Database](https://img.shields.io/badge/Database-MS%20Access-red.svg)

A comprehensive Employee Management System built using **C# (Windows Forms)** following a clean **3-Tier Architecture** (Presentation, Business Logic, and Data Access Layers) to ensure strict Separation of Concerns and scalable codebase design.

---

## 🔥 Key Features

* 🏢 **Full Employee CRUD Operations:**
  * Display all employees efficiently using `DataGridView`.
  * Add new employees with dynamic department binding.
  * Update existing employee records with automatic data loading.
  * Safe employee deletion with confirmation dialogs and error handling.

* 🏬 **Dynamic Department Binding:**
  * Fetch departments dynamically from the database into `ComboBox` UI components.
  * Properly mapped using `DisplayMember` (Department Name) and `ValueMember` (Department ID).

* 🖼️ **Image Management:**
  * Upload and preview employee pictures in real-time (`Live Preview`).
  * Optimized database performance by storing relative image file paths (`ImagePath`) instead of heavy binary BLOBs.
  * Safe memory disposal when clearing or deleting uploaded images.

* ⚡ **Interactive UI & UX:**
  * Context Menu (`ContextMenuStrip`) integration on right-click for quick edit and delete actions.
  * State management handled cleanly via `Enum Mode` (`AddNew` vs `Update`).

---

## 🏗️ Project Architecture

The project strictly follows the **N-Tier (3-Tier) Architecture** pattern:

```text
📁 Employee-Management-System
│
├── 🎨 Presentation Layer (UI)
│   ├── Main.cs                 # Main data grid dashboard & context menu actions
│   └── Operation.cs            # Employee add/edit form & image control
│
├── 🧠 Business Logic Layer (BLL)
│   ├── BusinessEmployees.cs    # Employee rules, validation, and operations
│   └── BusinessDepartment.cs   # Department domain logic
│
└── 💾 Data Access Layer (DAL)
    ├── AccessEmployees.cs      # Direct CRUD database access for employees
    └── AccessDepartment.cs     # Direct database access for departments
🛠️ Tech Stack
Language: C# (.NET)

UI Framework: Windows Forms (WinForms)

Database: MS Access (.accdb)

Design Pattern: Object-Oriented Programming (OOP) & 3-Tier Architecture

🚀 How to Run
Clone or download this repository:

Bash
git clone [https://github.com/your-username/Employee-Management-System.git](https://github.com/your-username/Employee-Management-System.git)
Open the solution file (.sln) in Visual Studio.

Ensure the MS Access database file path is correctly set in your Connection String.

Press F5 to build and run the application.

📝 Designed & Developed with Passion by Mustafa Ayyan