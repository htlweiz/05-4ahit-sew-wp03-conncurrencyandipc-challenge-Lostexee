using System;
using System.Threading;

namespace A2_RaceConditionBank;

public class BankAccount
{
    private int balance;
    object log_ = new object();

    public BankAccount(int initial)
    {
        balance = initial;
    }

    public void Deposit(int amount)
    {
        lock (log_)
        {
            balance += amount;
        }
    }

    public void Withdraw(int amount)
    {
        lock (log_)
        {
            balance -= amount;
        }
    }

    public int GetBalance()
    {
        return balance;
    }
}
