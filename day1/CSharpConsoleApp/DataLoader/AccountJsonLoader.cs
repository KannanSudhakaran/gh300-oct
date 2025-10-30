using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using CSharpConsoleApp;

namespace DataLoader
{
    public class AccountJsonLoader : IAccountLoader
    {
        public List<Account> LoadAccounts(string filePath)
        {
            List<Account> accounts = new List<Account>();

            try
            {
                if (!File.Exists(filePath))
                {
                    throw new FileNotFoundException($"JSON file not found: {filePath}");
                }

                string jsonContent = File.ReadAllText(filePath);
                
                if (string.IsNullOrWhiteSpace(jsonContent))
                {
                    throw new InvalidDataException("JSON file is empty");
                }

                try
                {
                    JsonElement[] jsonAccounts = JsonSerializer.Deserialize<JsonElement[]>(jsonContent);
                    
                    if (jsonAccounts == null || jsonAccounts.Length == 0)
                    {
                        throw new InvalidDataException("JSON file contains no account data");
                    }

                    for (int i = 0; i < jsonAccounts.Length; i++)
                    {
                        try
                        {
                            JsonElement accountElement = jsonAccounts[i];

                            // Parse account number
                            if (!accountElement.TryGetProperty("Accno", out JsonElement accnoElement) || 
                                !accnoElement.TryGetInt32(out int accno))
                            {
                                throw new InvalidDataException($"Invalid or missing account number at index {i}");
                            }

                            // Parse name
                            if (!accountElement.TryGetProperty("Name", out JsonElement nameElement))
                            {
                                throw new InvalidDataException($"Missing name at index {i}");
                            }
                            
                            string name = nameElement.GetString();
                            if (string.IsNullOrWhiteSpace(name))
                            {
                                throw new InvalidDataException($"Invalid or empty name at index {i}");
                            }

                            // Parse balance
                            if (!accountElement.TryGetProperty("Balance", out JsonElement balanceElement) || 
                                !balanceElement.TryGetDecimal(out decimal balance))
                            {
                                throw new InvalidDataException($"Invalid or missing balance at index {i}");
                            }

                            // Create and add account
                            Account account = new Account(accno, name, balance);
                            accounts.Add(account);
                        }
                        catch (Exception ex) when (!(ex is InvalidDataException))
                        {
                            throw new InvalidDataException($"Error parsing account at index {i}: {ex.Message}", ex);
                        }
                    }
                }
                catch (JsonException ex)
                {
                    throw new InvalidDataException($"Invalid JSON format: {ex.Message}", ex);
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
                throw new Exception($"Unexpected error loading accounts from JSON: {ex.Message}", ex);
            }

            return accounts;
        }
    }
}
