namespace OnlineStore.Model;

public class Order
{
    public int Id { get; set; }
    public DateTime OrderDate { get; set; }

    public Client Client { get; set; } = new();

    public List<Product?> Products { get; set; } = new();
}