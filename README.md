# OS Multithreading Project

## Overview

This project is designed for an Operating Systems class to demonstrate various multithreading concepts, including race conditions, deadlocks, and synchronization mechanisms. The project simulates a banking system where multiple customer threads perform transactions on shared bank accounts. The simulations include:

1. Race Condition
2. Resolved Race Condition
3. Deadlock
4. Resolved Deadlock
5. Multiple Customers

## Installation Instructions

1. **Install .NET SDK**:
   Download and install the .NET SDK from the [official website](https://dotnet.microsoft.com/download).

2. **Clone the repository**:
   ```sh
   git clone https://github.com/yourusername/os-multithreading-project.git
   cd os-multithreading-project
   ```

## Building and Running Instructions

1. **Build the project**
   `dotnet build`

2. **Run the program**
   `dotnet run --project src/os-multithreading-project.csproj`

3. **Run the tests**
   `dotnet test`

## Dependencies

- [.NET SDK](https://dotnet.microsoft.com/download) (version 6.0 or later)
- xUnit (for unit testing)
