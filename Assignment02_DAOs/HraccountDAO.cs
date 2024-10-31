using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Assignment02_BusinessObject;

namespace Assignment02_DAOs
{
    public class HraccountDAO
    {
        private List<Hraccount> hrAccounts;
        private static HraccountDAO instance;
        private readonly string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "FileData/Hraccount.txt");

        public static HraccountDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new HraccountDAO();
                }
                return instance;
            }
        }

        private HraccountDAO()
        {
            hrAccounts = new List<Hraccount>();
            LoadDataFromFile(); 
        }

        private void LoadDataFromFile()
        {
            if (File.Exists(filePath))
            {
                var lines = File.ReadAllLines(filePath);
                foreach (var line in lines)
                {
                    var data = line.Split('\t');
                    if (data.Length >= 4 && int.TryParse(data[3], out int memberRole))
                    {
                        var hrAccount = new Hraccount
                        {
                            Email = data[0],
                            Password = data[1],
                            FullName = data[2],
                            MemberRole = memberRole
                        };
                        hrAccounts.Add(hrAccount);
                    }
                }
            }
            else
            {
                File.Create(filePath).Dispose();
                Console.WriteLine("File not found. A new file has been created.");
            }
        }

        private void SaveDataToFile()
        {
            // Kiểm tra xem hrAccounts có null không
            if (hrAccounts != null && hrAccounts.Any())
            {
                var lines = hrAccounts.Select(a => $"{a.Email}\t{a.Password}\t{a.FullName}\t{a.MemberRole}");
                File.WriteAllLines(filePath, lines);
            }
            else
            {
                Console.WriteLine("No accounts to save.");
            }
        }

        public Hraccount GetHraccountByEmail(string email)
        {
            if (hrAccounts == null)
            {
                throw new InvalidOperationException("Account list is not initialized.");
            }
            return hrAccounts.SingleOrDefault(n => n.Email.Equals(email, StringComparison.OrdinalIgnoreCase));
        }

        public void AddHraccount(Hraccount account)
        {
            if (account != null)
            {
                hrAccounts.Add(account);
                SaveDataToFile(); // Cập nhật dữ liệu sau khi thêm
            }
            else
            {
                throw new ArgumentNullException(nameof(account), "Account cannot be null.");
            }
        }
    }
}
