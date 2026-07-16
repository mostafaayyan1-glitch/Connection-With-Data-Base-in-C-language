# Contact Management System - Add/Update Form

A clean and robust Windows Forms application built in **C#** utilizing a **3-Tier Architecture** (Presentation, Business, and Data Access Layers) to manage contact information.

## 🚀 Features
- **Dynamic Mode Switching:** Seamlessly toggles between **Add** and **Update** modes using a single form constructor.
- **Data Binding:** Automatically populates country dropdowns dynamically from the database.
- **Profile Image Management:** Allows users to upload, preview, and remove contact profile pictures safely.
- **State Preservation:** Keeps UI controls, buttons, and state indicators perfectly synchronized with the database state.

## 📂 Architecture & Components
- **Presentation Layer:** Windows Forms (`Form1.cs`) with XML-documented clean code.
- **Business Layer:** `Business_Layer_contact` (`ClsContact`) & `ClsCountry_Business_Layer` (`BusinessCountry`).
- **Data Access Layer:** Connects to the database to persist contact information.