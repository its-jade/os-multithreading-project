class BankAccount {
    public int ID { get; }
    public double Balance { get; private set; }

    public BankAccount(int id, double balance) {
        ID = id;
        Balance = balance;
    }

    // critical section 
    public void Deposit(double amount) {
        Thread.Sleep(10); // simulating delay
        Balance += amount; // race condition
        Console.WriteLine($"Depositing ${amount} to Account {ID}. New balance: ${Balance}");
    }

    public void Withdraw(double amount) {
        if (Balance >= amount) {
            Thread.Sleep(10); // simulating delay
            Balance -= amount;
            Console.WriteLine($"Withdrawing ${amount} from Account {ID}. New balance: ${Balance}");
        } else {
            Console.WriteLine($"Insufficient funds in Account {ID}");
        }
    }
}
