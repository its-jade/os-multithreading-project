using System.Threading;
using Xunit;

namespace tests;

public class UnitTest1 {

    [Fact]
    public void ConcurrencyTest() {
        var account = new MutexBankAccount(1, 1000.0);
        var threads = new Thread[10];

        for (int i = 0; i < threads.Length; i++) {
            threads[i] = new Thread(() => {
                account.Deposit(100);
                account.Withdraw(100);
            });
            threads[i].Start();
        }

        foreach (var thread in threads) {
            thread.Join();
        }

        Assert.Equal(1000.0, account.Balance);
    }

    [Fact]
    public void SynchronizationValidationTest() {
        var account = new BankAccount(1, 1000.0);
        var threads = new Thread[10];

        for (int i = 0; i < threads.Length; i++) {
            threads[i] = new Thread(() => {
                lock (account) {
                    account.Deposit(100);
                    Thread.Sleep(10); // Simulate delay
                    account.Withdraw(100);
                }
            });
            threads[i].Start();
        }

        foreach (var thread in threads) {
            thread.Join();
        }

        Assert.Equal(1000.0, account.Balance);
    }

    [Fact]
    public void StressTest() {
        var account = new BankAccount(1, 1000.0);
        var threads = new Thread[100];

        for (int i = 0; i < threads.Length; i++) {
            threads[i] = new Thread(() => {
                account.Deposit(100);
                account.Withdraw(100);
            });
            threads[i].Start();
        }

        foreach (var thread in threads) {
            thread.Join();
        }

        Assert.Equal(1000.0, account.Balance);
    }


}
