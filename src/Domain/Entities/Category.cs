namespace Domain.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Color { get; set; } = "#007bff"; // Default blue color
        public CategoryType Type { get; set; }

        public ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
    }

    public enum CategoryType
    {
        Income, // Money coming in
        Expense, // Money going out
        Transfer // Moving money between accounts
    }
}