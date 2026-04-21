
using System.Globalization;
using FluentFinanzas;



var report = ReportGenerator.CreateReport()
    .WithDate(new DateOnly(2000, 01, 01), new DateOnly(2030, 01, 01))
    .WithCurrency(CurrencySymbol.Cop)
    .WithDataFile("data")
    .AddTotalByType()
    .BuildReport()
    .PrintReport();
Console.WriteLine(report);


// DateOnly d = DateOnly.ParseExact("20250420", "yyyyMMdd", CultureInfo.InvariantCulture);
//
// Console.WriteLine(d > DateOnly.Parse("2025-05-20"));
//
// Console.WriteLine(d.ToString("yyyy MMM dd"));

