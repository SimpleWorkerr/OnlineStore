namespace OnlineStore.Model;

public class Client
{
    public int Id { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string? Patronymic { get; set; }
    
    public List<Order> Orders { get; set; } = new();
}
