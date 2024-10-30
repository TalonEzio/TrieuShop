namespace TrieuShop.Domain.Entities;

public class TransactionStatus
{
    public int TransactionStatusId { get; set; }

    public string? Status { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
