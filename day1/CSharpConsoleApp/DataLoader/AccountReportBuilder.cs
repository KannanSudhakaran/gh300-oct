using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpConsoleApp;

namespace DataLoader
{
    public class AccountReportBuilder : IReportBuilder
    {
        public string GenerateReport(List<Account> accounts)
        {
            if (accounts == null || accounts.Count == 0)
            {
                return "No accounts found to generate report.";
            }

            var report = new StringBuilder();
            report.AppendLine("=== ACCOUNT REPORT ===");
            report.AppendLine($"Generated on: {DateTime.Now:yyyy-MM-dd HH:mm:ss}");
            report.AppendLine();
            
            // Header
            report.AppendLine("Account No. | Name                | Balance");
            report.AppendLine("------------|---------------------|----------");
            
            // Account details
            decimal totalBalance = 0;
            foreach (var account in accounts.OrderBy(a => a.AccountNumber))
            {
                report.AppendLine($"{account.AccountNumber,11} | {account.Name,-19} | {account.Balance,8:C}");
                totalBalance += account.Balance;
            }
            
            report.AppendLine("------------|---------------------|----------");
            report.AppendLine($"Total Accounts: {accounts.Count,20} | {totalBalance,8:C}");
            report.AppendLine();
            
            // Summary statistics
            report.AppendLine("=== SUMMARY STATISTICS ===");
            report.AppendLine($"Total Accounts: {accounts.Count}");
            report.AppendLine($"Total Balance: {totalBalance:C}");
            report.AppendLine($"Average Balance: {(accounts.Count > 0 ? totalBalance / accounts.Count : 0):C}");
            report.AppendLine($"Highest Balance: {(accounts.Count > 0 ? accounts.Max(a => a.Balance) : 0):C}");
            report.AppendLine($"Lowest Balance: {(accounts.Count > 0 ? accounts.Min(a => a.Balance) : 0):C}");
            
            return report.ToString();
        }

        public void DisplayReport(List<Account> accounts)
        {
            string report = GenerateReport(accounts);
            Console.WriteLine(report);
        }
    }
}
