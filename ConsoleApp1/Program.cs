namespace ConsoleApp1
{
    internal class Program
    {
        public delegate int Action(int a, int b);
        public delegate int Delegate(int a, int b);
        static void Main(string[] args)
        {
            Console.WriteLine("Введіть перше число:");
            int a = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введіть друге число:");
            int b = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Виберіть дію +, -, *, / :");
            string action = Console.ReadLine();
            switch (action)
            {
                case "+":
                    int action1 = new Action((a, b) =>
                    {
                        return a + b;
                    }).Invoke(a, b);
                    Console.WriteLine("Вiдповiдь: {0}", action1);
                    break;
                case "-":
                    int action2 = new Action((a, b) =>
                    {
                        return a - b;
                    }).Invoke(a, b);
                    Console.WriteLine("Вiдповiдь: {0}", action2);
                    break;
                case "*":
                    int action3 = new Action((a, b) =>
                    {
                        return a * b;
                    }).Invoke(a, b);
                    Console.WriteLine("Вiдповiдь: {0}", action3);
                    break;
                case "/":
                    int action4 = new Action((a, b) =>
                    {
                        if (b == 0)
                        {
                            Console.WriteLine("Не можна ділити на нуль");
                            return 0;
                        };
                        return a / b;
                    }).Invoke(a, b);
                    Console.WriteLine("Вiдповiдь: {0}", action4);
                    break;
            }
        }
    }
}