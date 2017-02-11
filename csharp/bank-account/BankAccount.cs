using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class BankAccount
{
	private object _lock = new Object();
	private int balance = 0;
	private bool isOpen = false;

	public void Open()
	{
		isOpen = true;
	}

	public int GetBalance()
	{
		if (!isOpen) throw new InvalidOperationException();
		return balance;
	}

	public void UpdateBalance(int deposit)
	{
		if (!isOpen) throw new InvalidOperationException();
		lock (_lock) balance += deposit;
	}

	public void Close()
	{
		balance = 0;
		isOpen = false;
	}
}
