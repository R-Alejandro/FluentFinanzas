namespace FluentFinanzas;

public interface ICanGenerateReport
{
    public void ExportReport(string reportPath);
}