namespace FluentFinanzas;

public interface ICanUseReport
{
    public string PrintReport();
    public void ExportReport(string reportPath);
}