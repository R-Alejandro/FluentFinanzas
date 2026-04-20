namespace FluentFinanzas;

public interface ICanSetTable : ICanBuildReport
{
    public ICanSetData AddTotalByType();
    public ICanSetData AddGeneralBalance();
    public ICanSetData AddTotalByOrigin(int order);
    
}