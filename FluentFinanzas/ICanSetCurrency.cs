namespace FluentFinanzas;

public interface ICanSetCurrency
{
    public ICanSetData WithCurrency(CurrencySymbol currencySymbol);
}