// See https://aka.ms/new-console-template for more information
// Personal Finance Tracker - Getting Started
Console.WriteLine("Welcome to Personal Finance Tracker!");
Console.WriteLine("====================================");

// Get transaction details
Console.Write("Enter transaction description: ");
string description = Console.ReadLine() ?? string.Empty;

Console.WriteLine("Enter amount: ");
string amountInput = Console.ReadLine() ?? string.Empty;

// Convert string input to decimal for calculations
decimal amount;
if (decimal.TryParse(amountInput, out amount))
{
    Console.Write("Is this income? (y/n): ");
    string incomeInput = Console.ReadLine() ?? string.Empty;
    bool isIncome = incomeInput.ToLower() == "y";

    // Display the transaction with proper formatting
    Console.WriteLine($"\nTransaction recorded: ");
    Console.WriteLine($"Description: {description}");
    Console.WriteLine($"Amount: {amount:C}"); // :C formats as currency
    Console.WriteLine($"Type: {(isIncome ? "Income" : "Expense")}");

    // Show impact on balance
    string impact = isIncome ? "+" : "-";
    Console.WriteLine($"Balance change: {impact}{amount:C}");
}
else
{
    Console.WriteLine("Invalid amount entered. Please enter a valid number.");
}
