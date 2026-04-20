namespace FluentFinanzas;

public interface ICanSetDate
{
    public ICanSetCurrency WithDate(DateOnly from, DateOnly to);
}