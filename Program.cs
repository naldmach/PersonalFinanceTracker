// See https://aka.ms/new-console-template for more information
// Personal Finance Tracker - Getting Started
Console.WriteLine("Welcome to Personal Finance Tracker!");
Console.WriteLine("====================================");

// Get user input for a single transaction
Console.Write("Enter transaction description: ");
string description = Console.ReadLine() ?? string.Empty;


Console.WriteLine("Enter amount: ");
string amountInput = Console.ReadLine() ?? string.Empty;

// Display the information back
Console.WriteLine($"\nTransaction recorded:");
Console.WriteLine($"Description: {description}");
Console.WriteLine($"Amount: ₱{amountInput}");
