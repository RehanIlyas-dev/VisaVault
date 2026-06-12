# VisaVault

A desktop-based Visa Consultancy Management System developed as a second-semester Database Systems course project. VisaVault provides a structured platform for visa consultancy agencies to manage their clients, travel documents, renewal workflows, invoicing, and appointments through a centralized, database-driven application.

---

## Table of Contents

- [Project Overview](#project-overview)
- [Features](#features)
- [Technology Stack](#technology-stack)
- [Architecture](#architecture)
- [Database Design](#database-design)
- [Prerequisites](#prerequisites)
- [Setup and Installation](#setup-and-installation)
- [Project Structure](#project-structure)
- [Authors](#authors)

---

## Project Overview

Visa consultancy agencies deal with large volumes of client records, travel documents, and renewal processes on a daily basis. Managing these through paper-based systems or disconnected spreadsheets leads to missed deadlines, lost records, and billing errors.

VisaVault addresses these problems by providing a single desktop application where all agency operations are handled in one place. The system tracks document expiry dates, alerts staff to upcoming renewals, manages the full workflow of each renewal case from opening to completion, generates invoices and records payments, and produces professional PDF reports on demand.

The application was built with a strict three-tier architecture separating the user interface, business logic, and data access layers.

---

## Features

**Client Management**

- Register and manage client profiles with contact information, CNIC, and destination country
- Search and filter clients by name, CNIC, or status
- Soft activation and deactivation of client accounts

**Document Management**

- Record travel documents for each client with issue and expiry dates
- Classify documents by type (visa, passport, Emirates ID, etc.)
- Validate document dependency rules before registration

**Expiry Alert System**

- Automatic classification of documents into urgency levels: Critical, Warning, Safe, and Expired
- Filtered views to prioritize the most time-sensitive documents
- Deadline calculator showing the action date based on processing time requirements

**Visa Renewal Workflow**

- Open renewal cases linked to a client document
- Move cases through configurable workflow stages (Document Collection, Under Review, Submitted, Approved, Completed)
- Full audit trail of every stage transition with timestamps, responsible user, and remarks

**Invoicing and Payments**

- Generate invoices with line items based on fee rules per document type and country
- Record partial and full payments against invoices
- Automatic invoice status computation: Unpaid, Partially Paid, Paid, Overdue

**Appointment Scheduling**

- Schedule client consultations with assigned staff members
- Track appointment statuses: Scheduled, Complete, Unattended, Cancelled
- Validation prevents scheduling appointments in the past

**Fee Calculator**

- Calculate service fees by document type and destination country
- View itemised breakdown of base fee, urgent fee, and processing fee

**PDF Report Generation**

- Ten professionally formatted business reports exportable as PDF files
- Reports include Client Registry, Active Renewals, Expiring Documents, Accounts Receivable, Revenue Collection, Daily Appointments, Fee Rates, Dependencies Map, Audit Logs, and Case Timeline

**System Audit Log**

- Database-level audit trail maintained automatically by triggers
- Every create, update, or status change on critical records is logged with old and new values

---

## Technology Stack

| Component             | Technology                         |
| --------------------- | ---------------------------------- |
| Application Framework | .NET Framework, Windows Forms (C#) |
| Database              | MySQL 8.0                          |
| Data Access           | ADO.NET with MySql.Data connector  |
| PDF Generation        | iTextSharp                         |
| IDE                   | Visual Studio                      |
| Version Control       | Git                                |

---

## Architecture

The project follows a strict three-tier architecture:

```
UI Layer (Windows Forms)
    |
    v
Business Logic Layer (BLL — Service Classes)
    |
    v
Data Access Layer (DAL — Repository Classes)
    |
    v
MySQL 8.0 Database
```

**UI Layer** contains 14 Windows Forms modules. Each form is responsible for displaying data and capturing user input, with no business logic embedded in the form code.

**Business Logic Layer** contains 11 service classes that validate inputs, enforce business rules, map database results to domain objects, and coordinate multi-step operations.

**Data Access Layer** contains 8 DAL classes that execute parameterized SQL queries and stored procedure calls against the database. A shared Database Helper class provides four core methods: ExecuteQuery, ExecuteNonQuery, ExecuteScalar, and ExecuteTransaction.

---

## Database Design

The database contains 15 tables, designed to third normal form (3NF):

| Table              | Purpose                                                   |
| ------------------ | --------------------------------------------------------- |
| client             | Core client personal and contact information              |
| country            | Reference table for destination countries                 |
| document           | Client travel documents with issue and expiry dates       |
| documenttype       | Categories of document types                              |
| documentdependency | Rules specifying which document types require other types |
| feerule            | Fee pricing rules by document type and country            |
| renewalcase        | Visa renewal workflow cases                               |
| renewalstage       | Configurable workflow stages                              |
| renewalstagelog    | Historical log of all stage transitions                   |
| invoice            | Billing invoices linked to renewal cases                  |
| invoicelineitem    | Individual fee line items within an invoice               |
| payment            | Payment transactions against invoices                     |
| appointment        | Scheduled client-consultant meetings                      |
| user               | System user accounts                                      |
| audit_log          | System-wide change history populated by triggers          |

**Views (5)**

- `vw_active_clients` — Active clients with their destination country
- `vw_expiring_documents` — Documents expiring within 90 days with days remaining
- `vw_invoice_summary` — Invoices with computed total paid and balance due
- `vw_active_renewals` — Open renewal cases with stage, client, and document details
- `vw_fee_rules_summary` — Fee rules joined with document types and countries

**Stored Procedures (3)**

- `sp_GetClientInvoices` — Retrieves all invoices for a client with balance information
- `sp_RecordPayment` — Transactional payment recording with automatic invoice status update
- `sp_AdvanceRenewalStage` — Transactional stage advancement with automatic log entry

**Triggers (7)**

- `validate_appointment_date` — Prevents scheduling appointments in the past
- `tg_appointment_audit_insert` — Logs new appointment creation to the audit log
- `tg_appointment_audit_update` — Logs appointment changes to the audit log
- `tg_user_after_insert` — Logs new user account creation
- `tg_user_after_update` — Logs changes to user account fields
- Two additional triggers on core entity tables for change tracking

---

## Prerequisites

Before setting up the project, ensure the following software is installed on your machine:

- Visual Studio 2022 (or later) with .NET Framework desktop workload
- MySQL Server 8.0
- MySQL Workbench (recommended, for running the schema script)

---

## Setup and Installation

**Step 1 — Clone the repository**

```
git clone https://gitlab.com/RehanIlyas-dev/visavault-g43.git
cd visavault-g43
```

**Step 2 — Set up the database**

Open MySQL Workbench and connect to your local MySQL server. Open and execute the `visa_vault.sql` file located in the project root. This script will create the `visa_vault` database, all 15 tables, views, stored procedures, triggers, and insert sample data.

**Step 3 — Configure the database connection**

Open `DLL/Database/Database_Helper.cs` and update the connection string if your MySQL instance uses a different port, username, or password:

```csharp
private string connString = "Server=localhost;Port=3306;Database=visa_vault;Uid=root;Pwd=YourPassword";
```

**Step 4 — Restore NuGet packages**

Open the solution file `visavault_g43.slnx` in Visual Studio. Right-click the solution in Solution Explorer and select Restore NuGet Packages. This will download the MySql.Data and iTextSharp dependencies.

**Step 5 — Build and run**

Build the solution using Ctrl+Shift+B or Build > Build Solution. Press F5 to run the application.

---

## Project Structure

```
visavault-g43/
|
|-- Models/                
|   |-- Client.cs
|   |-- Document.cs
|   |-- Invoice.cs
|   |-- RenewalCase.cs
|   |-- ValidationResult.cs
|   `-- (13 more models)
|
|-- BLL/                   
|   |-- AuthService.cs       
|   |-- ClientService.cs     
|   |-- DocumentService.cs   
|   |-- AlertService.cs      
|   |-- RenewalService.cs   
|   |-- InvoiceService.cs   
|   |-- DeadlineService.cs   
|   |-- FeeService.cs        
|   |-- AppointmentService.cs 
|   |-- DependencyService.cs 
|   `-- ReportService.cs     
|
|-- DLL/                    
|   |-- Database/
|   |   `-- Database_Helper.cs
|   |-- ClientDAL.cs
|   |-- AuthDAL.cs
|   |-- DocumentDAL.cs
|   |-- InvoiceDAL.cs
|   |-- RenewalDAL.cs
|   |-- FeeDAL.cs
|   |-- AppointmentDAL.cs
|   `-- DependencyDAL.cs
|
|-- UI/                     
|   |-- Form1/               
|   |-- Home/                
|   |-- Client_Registry/     
|   |-- Client_Management/   
|   |-- Document_Portfolio/  
|   |-- Document_Manag/      
|   |-- Expiry_Alert/        
|   |-- Deadline_Calculator/ 
|   |-- Dependency_Validator/ 
|   |-- Renewal_WorkFlow/    
|   |-- Invoice/             
|   |-- Appoinment/          
|   |-- Fee_Calculator/      
|   `-- Reports/  
|-- visavault_g43.slnx  
```

---


## Authors

Developed by Group 43 as part of the Database Systems course, second semester.

### Group Members

- Rehan Ilyas
- Ali Fayyaz
- Hassan Rauf


