class Program {

    static void Main() {

        // ---- race condition simulation ---- // 
        // UnsafeBankAccount unsafeAccount = new(1, 500);
        // Console.WriteLine($"Initial balance: ${unsafeAccount.Balance}\n");

        // unsafeAccount.PerformConcurrentTransactions(unsafeAccount);

        // Console.WriteLine($"Final balance (after race condition): ${unsafeAccount.Balance}");

        // ---- race condition prevention ---- //
        MutexBankAccount safeAccount = new(1, 500);
        Console.WriteLine($"Initial balance: ${safeAccount.Balance}\n");

        safeAccount.PerformConcurrentTransactions(safeAccount);

        Console.WriteLine($"Final balance: ${safeAccount.Balance}");
    }
}
