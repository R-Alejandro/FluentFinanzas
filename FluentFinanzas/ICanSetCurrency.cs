namespace FluentFinanzas;

public interface ICanSetCurrency
{
    public ICanSetData WithCurrency(string currencySymbol);
}