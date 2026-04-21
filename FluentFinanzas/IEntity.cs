namespace FluentFinanzas;

public interface IEntity
{
    public DateOnly Date { get; }
    public string Desc { get; }
    public string Category { get; }
    public decimal Amount { get; }
    public string Type { get; }
    public string Currency { get; }
    public string Origin { get; }
}

public class Item : IEntity
{
    public DateOnly Date { get; set; }
    public string Desc { get; set; }
    public string Category { get; set; }
    public decimal Amount { get; set; }
    public string Type { get; set; }
    public string Currency { get; set; }
    public string Origin { get; set; }
}