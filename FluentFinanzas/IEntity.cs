namespace FluentFinanzas;

public interface IEntity
{
    public DateOnly Date { get; }
    public string Description { get; }
    public string Category { get; }
    public decimal Amount { get; }
    public string Type { get; }
    public string Currency { get; }
    public string Origin { get; }
}