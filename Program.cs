using System;
using System.Globalization;
using System.Linq;

namespace Long.Division
{
    public class Program
    {
        public static void Main(string[] _)
        {
            var random = new Random();

            double dividendLength;
            double divisorLength;

            do
            {
                Console.Clear();
                Console.Write("Divisor length:");
            }
            while (!double.TryParse(Console.ReadLine(), NumberStyles.Integer, NumberFormatInfo.CurrentInfo, out divisorLength));

            do
            {
                Console.Clear();
                Console.Write("Dividend length:");
            }
            while (!double.TryParse(Console.ReadLine(), NumberStyles.Integer, NumberFormatInfo.CurrentInfo, out dividendLength));

            var divisorStart = Convert.ToInt32(Math.Pow(10, divisorLength - 1));
            var divisorCount = Convert.ToInt32(Math.Pow(10, divisorLength) - divisorStart - 1);

            var dividendStart = Convert.ToInt32(Math.Pow(10, dividendLength - 1));
            var dividendCount = Convert.ToInt32(Math.Pow(10, dividendLength) - dividendStart - 1);

            var exercises = Exercises(dividendStart, dividendCount, divisorStart, divisorCount);

            while (true)
            {
                var (dividend, divisor, answer) = exercises[random.Next(exercises.Length)];

                Console.Clear();
                Console.Write(new string(' ', Convert.ToInt32(divisorLength) + 1));
                Console.WriteLine(new string('_', Convert.ToInt32(dividendLength)));
                Console.WriteLine($"{divisor}|{dividend}");

                while (true)
                {
                    Console.Write("=");

                    var input = Console.ReadLine();
                    if (input == string.Empty)
                    {
                        return;
                    }

                    if (input != answer.ToString())
                    {
                        continue;
                    }

                    break;
                }
            }
        }
        
        private static (int, int, int)[] Exercises
            (int dividendStart, int dividendCount, int divisorStart, int divisorCount) =>
            (from dividend in Enumerable.Range(dividendStart, dividendCount)
             from divisor in Enumerable.Range(divisorStart, divisorCount)
             where dividend % divisor == 0
             let answer = dividend / divisor
             where answer != 11 &&
                   answer % 10 != 0
             select (dividend, divisor, answer))
            .ToArray();
    }
}
