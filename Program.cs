class Program {
    static void Main() {
        // ---- race condition simulation ---- // 
        UnsafeBankAccount account = new(1, 500);
        Console.WriteLine($"Initial balance: ${account.Balance}\n");

        account.PerformConcurrentTransactions(account);

        Console.WriteLine($"Final balance (after race condition): ${account.Balance}");

        // ---- race condition prevention ---- //
    }
}
