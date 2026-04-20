using System.Text;

namespace FluentFinanzas;

// public class ReportGenerator :
//     ICanSetDate,
//     ICanSetCurrency,
//     ICanSetData,
//     ICanSetTable,
//     ICanBuildReport,
//     ICanUseReport
// {
//
//     private List<Func<IEntity, bool>> _filters = [];
//     private StringBuilder _content;
//     
//     private ReportGenerator()
//     {
//         this._content = new StringBuilder();
//     }
//
//     public static ReportGenerator CreateReport()
//     {
//         return new ReportGenerator();
//     }
//
//     public ICanSetCurrency WithDate(DateOnly from, DateOnly to)
//     {
//         _filters.Add(item => item.Date);
//     }
// }