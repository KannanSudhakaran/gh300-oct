using System.Collections.Generic;
using CSharpConsoleApp;

namespace DataLoader
{
    public interface IReportBuilder
    {
        string GenerateReport(List<Account> accounts);
        void DisplayReport(List<Account> accounts);
    }
}
