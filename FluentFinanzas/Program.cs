
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

// if (Enum.TryParse<CurrencySymbol>("Cop", out var currency))
// {
//     Console.WriteLine(currency);
// }


/* PREGUNTAS
 
 1) hay una mejor manera de cargar los datos a Item sin dejar todas las propiedades con setter?
 2) si es buena idea dejar el setter para transformar el Amount, no se cambia en el archivo pero si en el Enuemrable
 */