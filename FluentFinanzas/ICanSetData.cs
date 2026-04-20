namespace FluentFinanzas;

public interface ICanSetData
{
    public ICanGenerateReport WithDataFile(string filePath);
}