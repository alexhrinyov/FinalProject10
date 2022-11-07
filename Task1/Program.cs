using System.Runtime.CompilerServices;
using Windows.ApplicationModel.Background;
using static System.Console;

namespace Task1
{
    internal class Program
    {
        static int a;
        static int b;
        static ILogger Logger { get; set; }
        static void Main(string[] args)
        {
            // вводим экземпляр класса логгер, который реализует интерфейс Ilogger, выводит сообщения
            Logger = new Logger();
            Calculate calculate1 = new Calculate(Logger);
            GetValues();
            calculate1.Addition(a, b);
            BackgroundColor = ConsoleColor.White;
            WriteLine("A + B = " + calculate1.addResult);
            calculate1.Subtraction(a, b);
            BackgroundColor = ConsoleColor.White;
            WriteLine("A + B = " + calculate1.subResult);

            //Реализуйте механизм внедрения зависимостей: добавьте в мини - калькулятор логгер, используя материал из скринкаста юнита 10.1.
            //Дополнительно: текст ошибки, выводимый в логгере, окрасьте в красный цвет, а текст события — в синий цвет.

        }

        static void GetValues()
        {
            bool Converted1;
            bool Converted2;
            do
            {
                BackgroundColor = ConsoleColor.White;
                WriteLine("Number 1:");
                Converted1 = int.TryParse(ReadLine(), out a);
                switch (Converted1)
                {
                    case false:
                        Logger.Error("Wrong number 1! Try again.");
                        break;
                }
            } while (Converted1 == false);


            do
            {
                BackgroundColor = ConsoleColor.White;
                WriteLine("Number 2:");
                Converted2 = int.TryParse(ReadLine(), out b);
                switch (Converted2)
                {
                    case false:
                        Logger.Error("Wrong number 2! Try again.");
                        break;
                }
            } while (Converted2 == false);
        }
    }

    class Calculate : ICalculate
    {
        public int addResult;
        public int subResult;
        ILogger Logger { get; }

        public string Greetings;
        public Calculate(ILogger logger)
        {
            Greetings = "Hi, I'll help you to Calculate!";
            WriteLine(Greetings);
            Logger = logger;
        }

        public void Addition(int a, int b)
        {
            Logger.Event("Now I'll try to make addition...");
            Thread.Sleep(2000);
            addResult = a + b;
        }

        public void Subtraction(int a, int b)
        {
            Logger.Event("Now I'll try to make subtraction...");
            Thread.Sleep(2000);
            subResult =  a - b;
        }
    }

    public interface ICalculate
    {
        public void Addition(int a, int b);
        public void Subtraction(int a, int b);
    }

    public interface ILogger
    {
        string Property {get; set;}
        void Event(string message);
        void Error(string message);
    }

    public class Logger : ILogger
    {
        public string Property { get; set; }


        public void Error(string message)
        {
            BackgroundColor = ConsoleColor.Red;
            WriteLine(message);
        }

        public void Event(string message)
        {
            BackgroundColor = ConsoleColor.Blue;
            WriteLine(message);
        }
    }
}