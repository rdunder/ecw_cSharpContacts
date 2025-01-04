# Contact Manager

A project for managing contacts with both console and GUI interfaces. The project consists of three separate applications sharing common functionality through a class library.

## 📋 Description

The project contains the following main components:
- A console application for basic contact management
- A .NET MAUI application with extended functionality
- A .NET MAUI application with extended functionality that uses MVVM
- A shared class library for common business logic

## 🚀 Features

## Shared Library (Lib.Main)
- Implements SOLID
- Implements Factory pattern
- Implements Service pattern

### Console Application (UI.cli.Main)
- List all contacts
- Create new contacts
- Save contacts to JSON file
- Automatic loading of contacts from JSON file

### .NET MAUI Application (UI.Maui.Main)
- Complete CRUD functionality for contacts
  - List all contacts
  - Create new contacts
  - Edit existing contacts
  - Delete contacts
- Automatic JSON file handling
- Implements Dependency Injection
- Search Contacts

### .NET MAUI Application using MVVM (UI.Maui.MVVM)
- Complete CRUD functionality for contacts
  - List all contacts
  - Create new contacts
  - Edit existing contacts
  - Delete contacts
- Automatic JSON file handling
- Implements Dependency Injection
- Search Contacts
- Implements MVVM

## 🛠️ Technical Stack
- .NET 9
- .NET MAUI for GUI
- JSON.NET for file handling
- xUnit for unit testing

## ⚙️ Installation & Usage

1. Clone the project:
```bash
git clone [repository-url]
```

2. Open the solution file in Visual Studio

3. Build the project:
```bash
dotnet build
```

4. Run desired application:
```bash
# For console application
dotnet run --project UI.cli.Main

# For MAUI application
dotnet run --project UI.Maui.Main

# For MAUI application MVVM
dotnet run --project UI.Maui.MVVM
```

## 🧪 Testing

The project contains comprehensive unit tests with xUnit for the shared library:

Run the tests with:
```bash
dotnet test
```
