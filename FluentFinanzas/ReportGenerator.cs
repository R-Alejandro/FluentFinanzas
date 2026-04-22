using System.Text;

namespace FluentFinanzas;

public enum CurrencySymbol
{
    Cop,
    Usd
}

public enum MovementType
{
    Income,
    Expense
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
            new Item{Date = new DateOnly(2025,4,2), Desc = "d",Category=  "c", Amount =23500m,Type = MovementType.Income,Currency= CurrencySymbol.Cop,Origin= "b"},
            new Item{Date = new DateOnly(2025,4,2), Desc = "d",Category=  "c", Amount =235m,Type = MovementType.Expense,Currency= CurrencySymbol.Usd,Origin= "b"},
            new Item{Date = new DateOnly(2025,4,2), Desc = "d",Category=  "c", Amount =500m,Type =MovementType.Income,Currency= CurrencySymbol.Cop,Origin= "b"},
            new Item{Date = new DateOnly(2001,4,2), Desc = "d",Category=  "c", Amount =10000m,Type = MovementType.Expense,Currency=CurrencySymbol.Cop,Origin= "b"},
        };
        
        _data = _filters.Aggregate(
            d.AsEnumerable(),
            (actual, filtro) => actual.Where(filtro)
        );

        //convierte a la moneda
        foreach (var item in _data.Where(x => x.Currency != _currencySymbol))
        {
            item.Amount = _currencyConverter[_currencySymbol][item.Currency](item.Amount);
        }
        return this;
    }

    public ICanSetTable AddTotalByType()
    {
        var table = _data
            .GroupBy(
                x => x.Type,
                (type, total) => new { Type = type, Total = total.Sum(x => x.Amount) }
            );
        _content.AppendLine($"\nTOTAL BY TYPE $({_currencySymbol})");
        _content.AppendLine("-------------------");
        foreach (var row in table)
        {
            _content.AppendLine($"| {row.Type} | {row.Total:C2} |");
            _content.AppendLine("-------------------");
        }
        
        return this;
    }

    public ICanSetTable AddGeneralBalance()
    {
        var totalIncomes = _data
            .Where(x=> x.Type == MovementType.Income)
            .Sum(x=> x.Amount);
        var totalExpenses = _data
            .Where(x=> x.Type == MovementType.Expense)
            .Sum(x=> x.Amount);
        
        var totalCash = totalIncomes - totalExpenses;
        
        _content.AppendLine("\n-------------------");
        _content.AppendLine($"CURRENT BALANCE {totalCash:C2} {_currencySymbol}");
        _content.AppendLine("-------------------");
        
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