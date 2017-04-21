using System;

public class BankAccount
{
    private object _lock = new object();
    private int balance = 0;
    private bool isOpen = false;

    public void Open()
    {
        lock (_lock)
        {
            if (isOpen) throw new InvalidOperationException("Account already open.");
            isOpen = true;
        }
    }

    public int Balance
    {
        get
        {
            lock (_lock)
            {
                if (!isOpen) throw new InvalidOperationException("Account not open.");
                return balance;
            }
        }
    }

    public void UpdateBalance(int deposit)
    {
        lock (_lock)
        {
            if (!isOpen) throw new InvalidOperationException("Account not open.");
            balance += deposit;
        }
    }

    public void Close()
    {
        lock (_lock)
        {
            if (!isOpen) throw new InvalidOperationException("Account not open.");
            balance = 0;
            isOpen = false;
        }
    }
}
