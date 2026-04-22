namespace FluentFinanzas;

public interface ICanSetTable : ICanBuildReport
{
    public ICanSetTable AddTotalByType();
    public ICanSetTable AddGeneralBalance();
    public ICanSetTable AddTotalByOrigin(int order);
    
}