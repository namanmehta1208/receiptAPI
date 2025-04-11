
# receiptAPI

This repository contains the backend API for the reimbursement receipt submission application, built with .NET Core and MySQL. The API allows users to submit receipts with details such as date, amount, description, and a file upload, which are stored in a MySQL database.

# Running the Application
Prerequisites
- .NET Core SDK (version 6.0 or later)
- MySQL Server (version 8.0 or later)
- MySQL Workbench or any MySQL client for running SQL scripts
---

# Clone the Repository
 ```bash
 git clone https://github.com/namanmehta1208/receiptAPI.git
 cd receiptAPI
 ```
 ---

 # Set Up the MySQL Database
- Connect to your MySQL server using your credentials.
- Run the following SQL script to create the receipts database:
```bash
CREATE DATABASE `receipts` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;
```
- Create the receipts Table:
```bash
USE `receipts`;

CREATE TABLE `receipts` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Date` datetime NOT NULL,
  `Amount` decimal(18,2) NOT NULL,
  `Description` varchar(255) NOT NULL,
  `FilePath` varchar(255) NOT NULL,
  `Create_Date` datetime NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
```
---
# Configure the Connection String in your .NET application
- Update appsettings.json with your MySQL Datrabase User and Password:
```bash
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Database=receipts;User=your_username;Password=your_password;"
}
```
---
# Restore Dependencies and Run the Application
- Restore NuGet Packages (In the terminal, navigate to the project root and run the below commands)

```bash
dotnet restore

dotnet run
```
- The API will launch on https://localhost:7237 (It's a good idea to check launchSettings.json for the exact port).
- Test the Database Connection by gooing to https://localhost:7237/api/receipts/test-db. A successful response will indicate "Database connection successful."
---
