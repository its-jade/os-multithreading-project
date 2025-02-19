class MutexBankAccount {
    public int ID { get; }
    public double Balance { get; private set; }
    private readonly Mutex mutex = new();

    public MutexBankAccount(int id, double balance) {
        ID = id;
        Balance = balance;
    }

    public void Deposit(double amount) {
        mutex.WaitOne();
        try {
            double temp = Balance;
            Balance += amount; // race condition
            Console.WriteLine($"Current balance: ${temp} \nDepositing ${amount} to Account {ID} \nNew balance: ${Balance}");
        } finally {
            mutex.ReleaseMutex();
        }
    }

    public void Withdraw(double amount) {
        mutex.WaitOne();
        try {
            if (Balance >= amount) {
                double temp = Balance;
                Balance -= amount;
                Console.WriteLine($"Current balance: ${temp} \nWithdrawing ${amount} from Account {ID} \nNew balance: ${Balance}");
            } else {
                Console.WriteLine($"Insufficient funds in Account {ID}\n");
            }
        } finally {
            mutex.ReleaseMutex();
        }
    }

    public void PerformConcurrentTransactions(MutexBankAccount account) {
        Thread[] threads = new Thread[10];

        for (int i = 0; i < threads.Length; i++) {
            int threadIndex = i + 1;

            threads[i] = new Thread(() => {
                if (threadIndex % 2 == 0) {
                    account.Withdraw(100);
                } else {
                    account.Deposit(100);
                }
                Console.WriteLine($"Thread {threadIndex} finished.\n");
            });

            threads[i].Start();
        }

        foreach (Thread t in threads) {
            t.Join();
        }
    }
}
