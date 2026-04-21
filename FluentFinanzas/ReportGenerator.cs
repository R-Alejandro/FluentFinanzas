using System.Text;

namespace FluentFinanzas;

public enum CurrencySymbol
{
    Cop,
    Usd
}

public class ReportGenerator :
    ICanSetDate,
    ICanSetCurrency,
    ICanSetData,
    ICanSetTable,
    ICanBuildReport,
    ICanUseReport
{

    private List<Func<IEntity, bool>> _filters = [];
    private StringBuilder _content;
    private CurrencySymbol _currencySymbol = CurrencySymbol.Cop;
    private IEnumerable<IEntity> _data;

    //hacer una clase aparte para esto
    private Dictionary<CurrencySymbol, Dictionary<CurrencySymbol, Func<decimal, decimal>>> _currencyConverter =
        new()
        {
            {
                CurrencySymbol.Cop,
                new Dictionary<CurrencySymbol, Func<decimal, decimal>>()
                {
                    { CurrencySymbol.Usd, (amount) => amount * 3580.22m }
                }
            }
        };
    
    private ReportGenerator()
    {
        this._content = new StringBuilder();
    }

    public static ICanSetDate CreateReport()
    {
        return new ReportGenerator();
    }

    //filter
    public ICanSetCurrency WithDate(DateOnly from, DateOnly to)
    {
        _filters.Add(item => item.Date >= from && item.Date <= to);
        return this;
    }
    
    public ICanSetData WithCurrency(CurrencySymbol currencySymbol)
    {
        this._currencySymbol = currencySymbol;
        return this;
    }

    public ICanSetTable WithDataFile(string filePath)
    {
        //obtiene data del archivo y filtra
        var d = new List<IEntity>()
        {
            new Item{Date = new DateOnly(2025,4,2), Desc = "d",Category=  "c", Amount =23500m,Type = "i",Currency= CurrencySymbol.Cop,Origin= "b"},
            new Item{Date = new DateOnly(2025,4,2), Desc = "d",Category=  "c", Amount =235m,Type = "e",Currency= CurrencySymbol.Usd,Origin= "b"},
            new Item{Date = new DateOnly(2025,4,2), Desc = "d",Category=  "c", Amount =500m,Type = "i",Currency= CurrencySymbol.Cop,Origin= "b"},
            new Item{Date = new DateOnly(2001,4,2), Desc = "d",Category=  "c", Amount =10000m,Type = "e",Currency=CurrencySymbol.Cop,Origin= "b"},
        };
        _data = _filters.Aggregate(
            d.AsEnumerable(),
            (actual, filtro) => actual.Where(filtro)
        );

        foreach (var item in _data.Where(x => x.Currency != _currencySymbol))
        {
            item.Amount = _currencyConverter[_currencySymbol][item.Currency](item.Amount);
        }
        return this;
    }

    public ICanSetTable AddTotalByType()
    {
        var f = _data
            .GroupBy(
                x => x.Type,
                (type, total) => new { Type = type, Total = total.Sum(x => x.Amount) }
            );
        foreach (var VARIABLE in f)
        {
            _content.AppendLine($"{VARIABLE.Type}: {VARIABLE.Total}");
        }
        
        return this;
    }

    public ICanSetTable AddGeneralBalance()
    {
        throw new NotImplementedException();
        return this;
    }

    public ICanSetTable AddTotalByOrigin(int order)
    {
        throw new NotImplementedException();
        return this;
    }

    public ICanUseReport BuildReport()
    {
        return this;
    }

    public string PrintReport() => _content.ToString();

    public void ExportReport(string reportPath)
    {
        throw new NotImplementedException();
    }
}