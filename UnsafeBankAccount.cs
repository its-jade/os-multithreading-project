using System.Runtime.CompilerServices;

class UnsafeBankAccount {
    public int ID { get; }
    public double Balance { get; private set; }

    public UnsafeBankAccount(int id, double balance) {
        ID = id;
        Balance = balance;
    }

    // ---- critical section ---- //
    public void Deposit(double amount) {
        double temp = Balance;
        Thread.Sleep(10); // simulating delay
        Balance += amount; // race condition
        Console.WriteLine($"Current balance: ${temp} \nDepositing ${amount} to Account {ID} \nNew balance: ${Balance}");
    }

    public void Withdraw(double amount) {
        if (Balance >= amount) {
            double temp = Balance;
            Thread.Sleep(10); // simulating delay
            Balance -= amount;
            Console.WriteLine($"Current balance: ${temp} \nWithdrawing ${amount} from Account {ID} \nNew balance: ${Balance}");
        } else {
            Console.WriteLine($"Insufficient funds in Account {ID}\n");
        }
    }

    public void PerformConcurrentTransactions(UnsafeBankAccount account) {
        Thread[] threads = new Thread[10];

        for (int i = 0; i < threads.Length; i++) {
            int threadIndex = i + 1; // Capture the value properly

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
