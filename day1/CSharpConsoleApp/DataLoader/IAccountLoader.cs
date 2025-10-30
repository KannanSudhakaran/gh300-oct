using System.Collections.Generic;
using CSharpConsoleApp;

namespace DataLoader
{
    public interface IAccountLoader
    {
        List<Account> LoadAccounts(string filePath);
    }
}
