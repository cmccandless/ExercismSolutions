import java.util.concurrent.locks.*;

public class BankAccount {
	private ReadWriteLock lock = new ReentrantReadWriteLock();
	private int balance = 0;
	private boolean isOpen = false;
	public void open() throws BankAccountActionInvalidException {
		if (isOpen)
			throw new BankAccountActionInvalidException("Account open.");
		lock.readLock().lock();
		try {
			isOpen = true;
		} finally {
			lock.readLock().unlock();
		}
	}
	public int getBalance() throws BankAccountActionInvalidException {
		if (!isOpen)
			throw new BankAccountActionInvalidException("Account closed.");
		lock.readLock().lock();
		try {
			return balance;	
		} finally {
			lock.readLock().unlock();
		}
	}
	public void deposit(int amt) throws BankAccountActionInvalidException {
		if (!isOpen)
			throw new BankAccountActionInvalidException("Account closed.");
		if (amt < 0)
			throw new BankAccountActionInvalidException("Cannot deposit or withdraw negative amount");
		lock.writeLock().lock();
		try {
			balance += amt;	
		} finally {
			lock.writeLock().unlock();
		}
	}
	public void withdraw(int amt) throws BankAccountActionInvalidException {
		if (!isOpen)
			throw new BankAccountActionInvalidException("Account closed.");
		if (balance == 0)
			throw new BankAccountActionInvalidException("Cannot withdraw money from an empty account");
		if (amt < 0)
			throw new BankAccountActionInvalidException("Cannot deposit or withdraw negative amount");
		if (amt > balance)
			throw new BankAccountActionInvalidException("Cannot withdraw more money than is currently in the account");
		lock.writeLock().lock();
		try {
			balance -= amt;	
		} finally {
			lock.writeLock().unlock();
		}
	}
	public void close() throws BankAccountActionInvalidException {
		if (!isOpen)
			throw new BankAccountActionInvalidException("Account closed.");
		lock.readLock().lock();
		try {
			balance = 0;
			isOpen = false;
		} finally {
			lock.readLock().unlock();
		}
	}
}