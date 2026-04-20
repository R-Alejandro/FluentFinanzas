namespace FluentFinanzas;

public class ReportGenerator
{

    private ReportGenerator()
    {
        
    }

    public static ReportGenerator CreateReport()
    {
        return new ReportGenerator();
    }
}