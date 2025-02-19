class Program {
    static void PerformConcurrentTransactions(BankAccount account) {
        Thread[] threads = new Thread[5];

        for (int i = 0; i < threads.Length; i++) {
            if (i % 2 == 0) {
                threads[i] = new Thread(() => account.Withdraw(100));
            } else {
                threads[i] = new Thread(() => account.Deposit(100));
            }

            threads[i].Start();
        }

        foreach (Thread t in threads) {
            t.Join();
        }
    }
    static void Main() {
        // ---- race condition simulation ---- // 
        BankAccount account = new BankAccount(1, 500);
        Console.WriteLine($"Initial balance: {account.Balance}");
        PerformConcurrentTransactions(account);
        Console.WriteLine($"Final balance (after race condition): {account.Balance}");
        // expected output should be 500
    }
}
