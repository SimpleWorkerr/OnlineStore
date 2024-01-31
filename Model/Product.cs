namespace OnlineStore.Model;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public decimal Price { get; set; }
    public DateTime AdditionDate { get; set; }
    public int Count { get; set; }

    public List<Category?> Categories { get; set; } = new();
    public List<Order?> Orders { get; set; } = new();
}