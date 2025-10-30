using System;
using System.Collections.Generic;
using System.IO;
using System.Globalization;
using CSharpConsoleApp;

namespace DataLoader
{
    public class AccountCSVLoader : IAccountLoader
    {
        public List<Account> LoadAccounts(string filePath)
        {
            List<Account> accounts = new List<Account>();

            try
            {
                if (!File.Exists(filePath))
                {
                    throw new FileNotFoundException($"CSV file not found: {filePath}");
                }

                string[] lines = File.ReadAllLines(filePath);
                
                if (lines.Length <= 1)
                {
                    throw new InvalidDataException("CSV file is empty or contains only header");
                }

                // Skip header line (index 0)
                for (int i = 1; i < lines.Length; i++)
                {
                    string line = lines[i].Trim();
                    
                    if (string.IsNullOrWhiteSpace(line))
                        continue;

                    try
                    {
                        string[] fields = line.Split(',');
                        
                        if (fields.Length != 3)
                        {
                            throw new InvalidDataException($"Invalid CSV format at line {i + 1}. Expected 3 fields, got {fields.Length}");
                        }

                        // Parse account number
                        if (!int.TryParse(fields[0].Trim(), out int accno))
                        {
                            throw new InvalidDataException($"Invalid account number at line {i + 1}: {fields[0]}");
                        }

                        // Parse name
                        string name = fields[1].Trim();
                        if (string.IsNullOrWhiteSpace(name))
                        {
                            throw new InvalidDataException($"Invalid or empty name at line {i + 1}");
                        }

                        // Parse balance
                        if (!decimal.TryParse(fields[2].Trim(), NumberStyles.Number, CultureInfo.InvariantCulture, out decimal balance))
                        {
                            throw new InvalidDataException($"Invalid balance at line {i + 1}: {fields[2]}");
                        }

                        // Create and add account
                        Account account = new Account(accno, name, balance);
                        accounts.Add(account);
                    }
                    catch (Exception ex) when (!(ex is InvalidDataException))
                    {
                        throw new InvalidDataException($"Error parsing line {i + 1}: {ex.Message}", ex);
                    }
                }
            }
            catch (UnauthorizedAccessException ex)
            {
                throw new UnauthorizedAccessException($"Access denied to file: {filePath}", ex);
            }
            catch (IOException ex)
            {
                throw new IOException($"I/O error reading file: {filePath}", ex);
            }
            catch (Exception ex) when (!(ex is FileNotFoundException || ex is InvalidDataException || ex is UnauthorizedAccessException || ex is IOException))
            {
                throw new Exception($"Unexpected error loading accounts from CSV: {ex.Message}", ex);
            }

            return accounts;
        }
    }
}
