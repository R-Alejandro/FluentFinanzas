namespace FluentFinanzas;

public interface ICanSetData
{
    public ICanSetTable WithDataFile(string filePath);
}