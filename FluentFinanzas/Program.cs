
using System.Globalization;
using FluentFinanzas;



// var report = ReportGenerator.CreateReport();

DateOnly d = DateOnly.ParseExact("20250420", "yyyyMMdd", CultureInfo.InvariantCulture);


Console.WriteLine(d.ToString("yyyy MMM dd"));

