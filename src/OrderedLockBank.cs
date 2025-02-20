class OrderedLockBank {
    public static void Transfer(DeadlockBankAccount from, DeadlockBankAccount to, double amount) {
        // order locks based on account ID
        DeadlockBankAccount first = from.ID < to.ID ? from : to;
        DeadlockBankAccount second = from.ID < to.ID ? to : from;

        lock (first.GetLock()) {
            Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} locked Account {first.ID}\n");
            Thread.Sleep(100); // simulate delay

            lock (second.GetLock()) {
                Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} locked Account {second.ID}\n");
                if (from.Balance >= amount) {
                    from.Withdraw(amount);
                    to.Deposit(amount);
                    Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} transferred ${amount} from Account {from.ID} to Account {to.ID}\n");
                }
            }
        }
    }
}
