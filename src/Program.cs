class Program {

    static void Main() {

        // *** race condition simulation *** // 
        // UnsafeBankAccount unsafeAccount = new(1, 500);
        // Console.WriteLine($"Initial balance: ${unsafeAccount.Balance}\n");

        // unsafeAccount.PerformConcurrentTransactions(unsafeAccount);

        // Console.WriteLine($"Final balance (after race condition): ${unsafeAccount.Balance}");

        // ------------------------------------------------------------------------------------- //

        // *** race condition prevention *** //
        // MutexBankAccount safeAccount = new(1, 500);
        // Console.WriteLine($"Initial balance: ${safeAccount.Balance}\n");

        // safeAccount.PerformConcurrentTransactions(safeAccount);

        // Console.WriteLine($"Final balance: ${safeAccount.Balance}");

        // ------------------------------------------------------------------------------------- //

        // *** deadlock simulation *** //
        // DeadlockBankAccount account1 = new(1, 500);
        // DeadlockBankAccount account2 = new(2, 500);

        // Thread t1 = new Thread(() => DeadlockBank.Transfer(account1, account2, 100));
        // Thread t2 = new Thread(() => DeadlockBank.Transfer(account2, account1, 50));

        // t1.Start();
        // t2.Start();

        // t1.Join();
        // t2.Join();

        // Console.WriteLine($"Final Balances:\nAccount 1 = ${account1.Balance} \nAccount 2 = ${account2.Balance}");

        // ------------------------------------------------------------------------------------- //

        // *** ordered locking simulation *** //
        DeadlockBankAccount account1 = new(1, 500);
        DeadlockBankAccount account2 = new(2, 500);

        Thread t1 = new Thread(() => OrderedLockBank.Transfer(account1, account2, 100));
        Thread t2 = new Thread(() => OrderedLockBank.Transfer(account2, account1, 50));

        t1.Start();
        t2.Start();

        t1.Join();
        t2.Join();

        Console.WriteLine($"Final Balances:\nAccount 1 = ${account1.Balance} \nAccount 2 = ${account2.Balance}");
    }
}
