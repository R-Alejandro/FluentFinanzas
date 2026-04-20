namespace FluentFinanzas;

public interface ICanSetCurrency
{
    public ICanSetTable WithCurrency(string currencySymbol);
}