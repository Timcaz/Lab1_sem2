using System.Security.Cryptography.X509Certificates;

namespace ConsoleApp1
{
    internal class Program
    {
        public delegate int Action(int a, int b);
        public delegate void Delegate(int a);
        static void Main(string[] args)
        {
            Console.WriteLine("Введіть арифметичний вираз:");
            string input = Console.ReadLine();
            string[] tokens = input.Split(' ');
            if (tokens.Length != 3)
            {
                Console.WriteLine("Неправильний формат виразу.");
                return;
            }
            if (!double.TryParse(tokens[0], out double number1) || !double.TryParse(tokens[2], out double number2))
            {
                Console.WriteLine("Неправильний формат чисел.");
                return;
            }
            Func<double, double, double> operation;
            switch (tokens[1])
            {
                case "+":
                    operation = (x, y) => x + y;
                    break;
                case "-":
                    operation = (x, y) => x - y;
                    break;
                case "*":
                    operation = (x, y) => x * y;
                    break;
                case "/":
                    operation = (x, y) =>
                    {
                        if (y == 0)
                        {
                            Console.WriteLine("Помилка: ділення на нуль.");
                            return double.NaN;
                        }
                        return x / y;
                    };
                    break;
                default:
                    Console.WriteLine("Неправильний оператор.");
                    return;
            }
            Console.WriteLine("Результат: " + operation(number1, number2));

            Random rand = new Random();
            Func<int>[] delegates = new Func<int>[] {
            () => rand.Next(0, 10),
            () => rand.Next(0, 100),
            () => rand.Next(0, 100)
            };

            Func<Func<int>[], double> averageDelegateValues = delegate (Func<int>[] dels) {
                int sum = 0;
                foreach (Func<int> del in dels)
                {
                    sum += del();
                }
                return (double)sum / dels.Length;
            };

            double result = averageDelegateValues(delegates);
            Console.WriteLine("Середнє значення: " + result);

            
            Func<int, int, int, double> average = delegate (int first, int second, int third) {
                return (double)(first + second + third) / 3;
            };

            double res = average(1080, 2140, 1200);
            Console.WriteLine("Середнє значення: " + res);
        }
    }
}