# OS Multithreading Project

## Overview

This project was developed for an Operating Systems course to demonstrate key **multithreading concepts** using C#. The program simulates a banking system where multiple customer threads perform transactions on shared bank accounts, illustrating issues like race conditions and deadlocks, along with their respective solutions.

## Features

- Simulates concurrent transactions on shared bank accounts.
- Demonstrates **race conditions** and their resolution using **mutexes**.
- Simulates **deadlocks** and implements **ordered locking** to prevent them.
- Supports multiple customer threads performing deposits and withdrawals.
- Provides an interactive interface to observe different concurrency issues.

## Technologies Used

- **Language**: C#
- **Framework**: .NET
- **Threading**: `Thread`, `lock`, and `Mutex` for synchronization
- **Synchronization Primitives**: Mutex-based locking, Ordered Locking

## How It Works

### Race Condition Simulation

- `UnsafeBankAccount`: Demonstrates an account that is not thread-safe.
- Multiple threads deposit and withdraw simultaneously without synchronization.
- Leads to inconsistent balances due to race conditions.
- `MutexBankAccount`: Implements mutex-based synchronization to prevent race conditions.

### Deadlock Simulation

- `DeadlockBank`: Simulates a deadlock scenario when two threads attempt to lock two accounts in an inconsistent order.
- `OrderedLockBank`: Implements ordered locking based on account IDs to prevent deadlocks.

### Multiple Customer Transactions

- Simulates multiple customers performing transactions concurrently.
- Ensures thread-safe execution while maintaining data consistency.

## Installation Instructions

1. **Install .NET SDK**:
   Download and install the **.NET SDK (version 6.0 or later)** from the [official website](https://dotnet.microsoft.com/download).

2. **Clone the repository**:
   ```sh
   git clone https://github.com/its-jade/os-multithreading-project.git
   cd os-multithreading-project
   ```

## Building and Running Instructions

### Compile the Program

```sh
dotnet build
```

### Run the Program

```sh
dotnet run --project src/os-multithreading-project.csproj
```

## Dependencies

- [.NET SDK](https://dotnet.microsoft.com/download) (version 6.0 or later)
