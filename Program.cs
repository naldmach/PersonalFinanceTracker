// See https://aka.ms/new-console-template for more information
// Personal Finance Tracker - Organized with Methods
using System;
using System.ComponentModel.DataAnnotations;

Console.WriteLine("Welcome to Personal Finance Tracker!");
Console.WriteLine("====================================");

// Use methods to organize code
AddTransaction();

// Method to handle adding a new transaction
static void AddTransaction()
{
    Console.Write("Enter transaction description: ");
    string description = Console.ReadLine();

    decimal amount = GetValidAmount();
    bool isIncome = GetTransactionType();

    DisplayTransactionSummary(description, amount, isIncome);
}

// Method to get a valid amount from user
static decimal GetValidAmount()
{
    while (true) // Keep asking until we get valid input
    {
        Console.Write("Enter amount: ");
        string input = Console.ReadLine();
        if (decimal.TryParse(input, out decimal amount) && amount > 0)
        {
            return amount; // Exit method and return the valid amount
        }
        else
        {
            Console.WriteLine("Please enter a valid positive number.");
        }
    }
}

// Method to determine if transaction is income or expense
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

// Method to display transaction summary
static void DisplayTransactionSummary(string description, decimal amount, bool isIncome)
{
    Console.WriteLine($"\nTransaction recorded:");
    Console.WriteLine($"Description: {description}");
    Console.WriteLine($"Amount: {amount:C}");
    Console.WriteLine($"Type: {(isIncome ? "Income" : "Expense")}");

    string impact = isIncome ? "+" : "-";
    Console.WriteLine($"Balance change: {impact}{amount:C}");
}