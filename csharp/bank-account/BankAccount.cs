using System;
namespace Exercism.bank_account
{
    public class BankAccount
    {
        private object _lock = new object();
        private int balance = 0;
        private bool isOpen = false;

        public void Open()
        {
            lock (_lock) isOpen = true;
        }

        public int GetBalance()
        {
            lock (_lock)
            {
                if (!isOpen) throw new InvalidOperationException();
                return balance;
            }
        }

        public void UpdateBalance(int deposit)
        {
            lock (_lock)
            {
                if (!isOpen) throw new InvalidOperationException();
                balance += deposit;
            }
        }

        public void Close()
        {
            lock (_lock)
            {
                balance = 0;
                isOpen = false;
            }
        }
    }
}