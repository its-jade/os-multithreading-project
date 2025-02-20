class DeadlockBank {
    public static void Transfer(DeadlockBankAccount from, DeadlockBankAccount to, double amount) {
        lock (from.GetLock()) {
            Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} locked Account {from.ID} and is waiting for Account {to.ID}\n");
            Thread.Sleep(100); // simulate delay

            // deadlock occurs here
            lock (to.GetLock()) {
                Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} locked Account {to.ID}\n");
                if (from.Balance >= amount) {
                    from.Withdraw(amount);
                    to.Deposit(amount);
                    Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} transferred ${amount} from Account {from.ID} to Account {to.ID}\n");
                }
            }
        }
    }
}
