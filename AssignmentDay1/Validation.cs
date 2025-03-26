using NashConsole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static NashConsole.Car;

namespace AssignmentDay1
{
    public static class Validation
    {
        public static int GetValidYear()
        {
            int year;
            while (!int.TryParse(Console.ReadLine(), out year) || year < 0 || year > DateTime.Now.Year)
            {
                Console.WriteLine("Invalid Year! Try Again:\n>");
            }

            return year;
        }
        public static CarType GetValidType()
        {
            CarType carType;
            while (!Enum.TryParse(CapitalizeWord(Console.ReadLine()), out carType))
            {
                Console.WriteLine("Invalid Type! Try Again:\n>");
            }

            return carType;
        }
        public static string GetValidString()
        {
            string input;
            do
            {
                input = CapitalizeWord(Console.ReadLine());
                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("Invalid Type! Try Again:\n>");
                }
            }
            while (string.IsNullOrEmpty(input));

            return input;
        }
        public static string CapitalizeWord(string input)
        {
            if (input.Length == 1)
            {
                return char.ToUpper(input[0]).ToString();
            }
            StringBuilder sb = new StringBuilder();
            sb.Append(char.ToUpper(input[0]));
            sb.Append(input.Substring(1).ToLower());

            return sb.ToString();
        }

    }
}
