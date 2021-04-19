using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services
{
    public class Service
    {
        public bool CheckPrimeNumber(int num)
        {
            int i = 2;
            bool result = true;

            while (i <= num / 2)
            {
                if (num % i == 0)
                {
                    result = false;
                    break;
                }
                i++;
            }
            return result;
        }
        public string GetDayOfWeek(int day)
        {

            switch (day)
            {
                case 1:
                    return "monday";
                case 2:
                    return "tuesday";
                case 3:
                    return "wednesday";
                case 4:
                    return "thursday";
                case 5:
                    return "friday";
                case 6:
                    return "saturday";
                case 7:
                    return "sunday";
                default:
                    return "invalid";
            }
        }
        public string CheckNumber(int number)
        {
            if (number > 0)
            {
                return "positive";
            }
            else if (number < 0)
            {
                return "negative";
            }
            else
            {
                return "zero";
            }
        }


        public int FindSumOfOddNumbers(List<int> numbers)
        {
            int sum = 0;
            foreach (var number in numbers)
            {
                if (number % 2 != 0)
                {
                    sum += number;
                }
            }
            return sum;
        }

        public int Multiplication(int first, int second)
        {
            int answer = 0;
            for (int i = 1; i <= second; i++)
            {
                answer += first;
            }
            return answer;
        }

        public void MethodNotImplemented()
        {
            throw new NotImplementedException();
        }

        public int Division(int dividend, int divisor)
        {
            if (divisor != 0)
            {
                return dividend / divisor;
            }
            else
            {
                throw new InvalidOperationException("can not divide by zero");
            }
        }

        public int FindValue(int index)
        {
            int[] array = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            if (index < 0 || index > 10)
            {
                throw new IndexOutOfRangeException();
            }
            else
            {
                return array[index];
            }
        }

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
    }


    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
    }
}
