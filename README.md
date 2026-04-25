# MSFD Secure Data App

## Overview

This C# console application demonstrates secure data storage and access control using role-based authorization and AES encryption. The project is designed as a lab exercise to show how sensitive information can be protected.

## Features

✅ Role-based access control (Admin vs. User)
✅ AES symmetric encryption for sensitive data
✅ Exception handling for unauthorized access
✅ Simple, clear code structure for educational purposes

## Getting Started

1. Clone the repository or download the source code.
2. Open the solution in Visual Studio or your preferred C# IDE.
3. Restore any required packages (if prompted).
4. Build and run the application:

   ```sh
   dotnet run
   ```

5. Observe the console output:
   - Admin users can access and decrypt sensitive data.
   - Basic users are denied access and receive an error message.

## Project Structure

```
MSFD_SecureDataApp/
│
├─ Models/
│   ├─ User.cs           # User class with Username and Role
│   └─ DataStorage.cs    # SecureStorage class for encryption and access control
│
├─ Program.cs            # Main entry point, demo logic
├─ MSFD_SecureDataApp.csproj
└─ MSFD_SecureDataApp.sln
```

## Key Concepts Demonstrated

- Role-based authorization: Only users with the "Admin" role can access sensitive data.
- Symmetric encryption: Data is encrypted and decrypted using AES.
- Exception handling: Unauthorized access attempts are caught and reported.
- Separation of concerns: User and storage logic are separated into different classes.

## Usage

- The application creates two users: one Admin and one regular User.
- Sensitive information is encrypted and stored.
- The app attempts to retrieve the data as both users, demonstrating access control.

## Security Notes

- This is a demo. In real applications:
  - Implement robust authentication and authorization (e.g., ASP.NET Identity).
  - Manage encryption keys securely (never hardcode or expose them).
  - Use secure storage for keys (e.g., Azure Key Vault, AWS KMS).

## About

.NET 10 console application built for the Microsoft Security and Authentication course as part of the Microsoft Full-Stack Developer Certification track. This project demonstrates secure data storage, role-based access control, and AES encryption—essential skills for full-stack software developers building secure applications.

## Author

Daisy Viruet-Allen (boricua007)  
GitHub: https://github.com/boricua007
