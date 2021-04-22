using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services
{
    public class Service
    {
        public async Task<IEnumerable<string>> GetStringArray()
        {
            IEnumerable<string> someStrings = new[] { "abc", "cat", "bad", "hat" };

            await Task.Delay(100);

            return someStrings;
        }

        public async Task<IEnumerable<User>> GetUsersData()
        {
            User[] users = new User[] {
                new User{ Id = 1, Name = "Kuldip", Email = "kuldip.patel@gmail.com", Address = "Rajkot"},
                new User{ Id = 2, Name = "Parth", Email = "parth.patel@gmail.com", Address = "Ahmedabad"},
                new User{ Id = 3, Name = "Rushi", Email = "rushi.patel@gmail.com", Address = null},
            };

            await Task.Delay(100);

            return users;
        }

        public int[] GetTable(int number)
        {
            int[] table = new int[10];
            for (int i = 0; i <= 9; i++)
            {
                table[i] = (i+1) * number;
            }
            return table;
        }

        public string GetName()
        {
            return "kuldip ladola";
        }
    }

    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
    }
}
