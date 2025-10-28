# SafeVault Secure Web Application

## Overview
SafeVault is a security-focused ASP.NET Core Razor Pages application built for the Microsoft Full-Stack Developer Professional Certificate. It demonstrates secure coding practices across input validation, authentication, and role-based access control (RBAC), with full test coverage and documentation.

---

## Vulnerability Summary

### Issues Identified
- **SQL Injection**: Unsafe query concatenation allowed malicious input to manipulate database commands.
- **Cross-Site Scripting (XSS)**: Unescaped user input could inject scripts into the frontend.
- **Authentication Flaws**: Passwords were stored and compared insecurely.
- **Authorization Gaps**: Admin-only pages lacked proper role checks.

---

## Fixes Applied
- ✅ Replaced all SQL queries with parameterized statements using `SqlCommand.Parameters.AddWithValue`.
- ✅ Implemented input sanitization via `Regex` and keyword filtering in `InputSanitizer.cs`.
- ✅ Added password hashing and verification using `BCrypt.Net` in `AuthService.cs`.
- ✅ Enforced role-based access control using `RBAC.cs` and gated admin access in `Login.cshtml.cs`.
- ✅ Created NUnit tests for SQLi, XSS, invalid login, and unauthorized access.

---

## Technologies Used
- ASP.NET Core Razor Pages
- C#
- NUnit for testing
- SQL Server (via `System.Data.SqlClient`)
- BCrypt.Net for password hashing

---

## How to Run
1. Clone the repo:
   ```bash
   git clone https://github.com/yourusername/SafeVault-SecureApp.git
   cd SafeVault-SecureApp
