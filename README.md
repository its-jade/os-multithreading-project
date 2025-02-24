# OS Multithreading Project

## Overview

This project is designed for an **Operating Systems** class to demonstrate various **multithreading concepts** including:

1. Race Conditions
2. Resolved Race Conditions (Synchronization Solutions)
3. Deadlocks
4. Resolved Deadlocks (Deadlock Prevention)
5. Multiple Customers Performing Transactions

The project simulates a banking system where multiple customer threads concurrently perform transactions on shared bank accounts, showcasing potential issues and solutions in multithreaded applications.

## Installation Instructions

1. **Install .NET SDK**:
   Download and install the **.NET SDK (version 6.0 or later)** from the [official website](https://dotnet.microsoft.com/download).

2. **Clone the repository**:
   ```sh
   git clone https://github.com/its-jade/os-multithreading-project.git
   cd os-multithreading-project
   ```

## Building and Running Instructions

1. **Build the project**
   `dotnet build`

2. **Run the program**
   `dotnet run --project src/os-multithreading-project.csproj`

## Dependencies

- [.NET SDK](https://dotnet.microsoft.com/download) (version 6.0 or later)
