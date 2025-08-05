using System.ComponentModel;

namespace Domain.Entities
{
    public class Transaction
    {
        public int Id { get; set; }
        public decimal Amount { get; set; } // Positive for income, negative for expenses
        public string Description { get; set; } = string.Empty;
        public DateTime TransactionDate { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Foreign keys - these link to other entities
        public int UserId { get; set; }
        public User User { get; set; } = null!; // null! tells compiler this will be set by EF
        public int CategoryId { get; set; }
        public CategoryAttribute Category { get; set; } = null!;
    }
}