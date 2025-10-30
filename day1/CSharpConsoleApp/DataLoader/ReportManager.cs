using System;
using System.Collections.Generic;
using CSharpConsoleApp;

namespace DataLoader
{
    public class ReportManager
    {
        private readonly IAccountLoader _accountLoader;
        private readonly IReportBuilder _reportBuilder;

        public ReportManager(IAccountLoader accountLoader, IReportBuilder reportBuilder)
        {
            _accountLoader = accountLoader ?? throw new ArgumentNullException(nameof(accountLoader));
            _reportBuilder = reportBuilder ?? throw new ArgumentNullException(nameof(reportBuilder));
        }

        public void GenerateAndDisplayReport(string filePath)
        {
            try
            {
                List<Account> accounts = _accountLoader.LoadAccounts(filePath);
                _reportBuilder.DisplayReport(accounts);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error generating report: {ex.Message}");
            }
        }

        public string GenerateReportString(string filePath)
        {
            try
            {
                List<Account> accounts = _accountLoader.LoadAccounts(filePath);
                return _reportBuilder.GenerateReport(accounts);
            }
            catch (Exception ex)
            {
                return $"Error generating report: {ex.Message}";
            }
        }
    }
}
