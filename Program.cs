// See https://aka.ms/new-console-template for more information
// Personal Finance Tracker - Multiple Transactions
using System;
using System.Collections.Generic;
using System.Transactions;

// Store all transactions in a list
List<Transaction> transactions = new List<Transaction>();
decimal balance = 0m; // The 'm' suffix makes this a decimal literal

Console.WriteLine("Welcome to Personal Finance Tracker!");
Console.WriteLine("====================================");

// Main program loop
while (true)
{
    ShowMenu();
    string choice = Console.ReadLine();

    switch (choice)
    {
        case "1":
            AddTransaction();
            break;
        case "2":
            ViewAllTransactions();
            break;
        case "3":
            ViewBalance();
            break;
        case "4":
            Console.WriteLine("Thank you for using Personal Finance Tracker!");
            return; // Exit the program
        default:
            Console.WriteLine("Invalid choice. Please try again.");
            break;
    }

    Console.WriteLine(); // Add blank line for readability
}

// Display menu options
static void ShowMenu()
{
    Console.WriteLine("What would you like to do?");
    Console.WriteLine("1. Add a transaction");
    Console.WriteLine("2. View all transactions");
    Console.WriteLine("3. View balance");
    Console.WriteLine("4. Exit");
    Console.WriteLine("Choose an option (1-4): ");
}

// Add a new transaction
void AddTransaction()
{
    Console.Write("Enter transaction description: ");
    string description = Console.ReadLine();

    decimal amount = GetValidAmount();
    bool isIncome = GetTransactionType();

    // Create a new transaction and add to list
    Transaction transaction = new Transaction
    {
        Description = description,
        Amount = amount,
        IsIncome = isIncome,
        Date = DateTime.Now // Current date and time
    };

    transactions.Add(transaction);

    // Update balance
    if (isIncome)
        balance += amount;
    else
        balance -= amount;

    Console.WriteLine($"Transaction added successfully! New balance: {balance:C}");
}

// Display all transactions
void ViewAllTransactions()
{
    if (transactions.Count == 0)
    {
        Console.WriteLine("No transactions recorded yet.");
        return;
    }

    Console.WriteLine("All Transactions:");
    Console.WriteLine("================");

    foreach (Transaction transaction in transactions)
    {
        string type = transaction.IsIncome ? "Income" : "Expense";
        string sign = transaction.IsIncome ? "+" : "-";

        Console.WriteLine($"{transaction.Date:yyyy-MM-dd HH:mm} | {type} | {sign}{transaction.Amount:C} | {transaction.Description}");
    }
}

// Show current balance
void ViewBalance()
{
    Console.WriteLine($"Current Balance: {balance:C}");

    // Calculate income and expense totals
    decimal totalIncome = 0;
    decimal totalExpenses = 0;

    foreach (Transaction transaction in transactions)
    {
        if (transaction.IsIncome)
            totalIncome += transaction.Amount;
        else
            totalExpenses += transaction.Amount;
    }

    Console.WriteLine($"Total Income: +{totalIncome:C}");
    Console.WriteLine($"Total Expenses: -{totalExpenses:C}");
}

// Keep the helpler methods we created earlier
static decimal GetValidAmount()
{
    while (true)
    {
        Console.Write("Enter amount: ");
        string input = Console.ReadLine();

        if (decimal.TryParse(input, out decimal amount) && amount > 0)
        {
            return amount;
        }
        else
        {
            Console.WriteLine("Please enter a valid positive number.");
        }
    }
}

static bool GetTransactionType()
{
    while (true)
    {
        Console.Write("Is this income? (y/n): ");
        string input = Console.ReadLine().ToLower();

        if (input == "y" || input == "yes")
            return true;
        else if (input == "n" || input == "no")
            return false;
        else
            Console.WriteLine("Please enter 'y' for yes or 'n' for no.");
    }
}

// Transaction class to represent a single financial transaction
public class Transaction
{
    public string Description { get; set; }
    public decimal Amount { get; set; }
    public bool IsIncome { get; set; }
    public DateTime Date { get; set; }
}