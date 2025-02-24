class BankAccount {
    public int ID { get; }
    public double Balance { get; set; }
    private readonly object lockObj = new();

    public BankAccount(int id, double balance) {
        ID = id;
        Balance = balance;
    }

    public void Deposit(double amount) {
        Balance += amount;
    }

    public void Withdraw(double amount) {
        Balance -= amount;
    }

    public object GetLock() {
        return lockObj;
    }
}
