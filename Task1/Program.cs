using static System.Console;

namespace Task1
{
    internal class Program
    {
        static int a;
        static int b;
        static void Main(string[] args)
        {
            
            ICalculate calculate1 = new Calculate();
            GetValues();
            WriteLine("A + B = " + calculate1.Addition(a, b));
            WriteLine("A - B = " + calculate1.Subtraction(a, b));

            //Реализуйте механизм внедрения зависимостей: добавьте в мини - калькулятор логгер, используя материал из скринкаста юнита 10.1.
            //Дополнительно: текст ошибки, выводимый в логгере, окрасьте в красный цвет, а текст события — в синий цвет.

        }

        static void GetValues()
        {
            bool Converted1;
            bool Converted2;
            do
            {
                WriteLine("Number 1:");
                Converted1 = int.TryParse(ReadLine(), out a);
                switch (Converted1)
                {
                    case false:
                        WriteLine("Wrong number 1! Try again.");
                        break;
                }
            } while (Converted1 == false);


            do
            {
                WriteLine("Number 2:");
                Converted2 = int.TryParse(ReadLine(), out b);
                switch (Converted2)
                {
                    case false:
                        WriteLine("Wrong number 2! Try again.");
                        break;
                }
            } while (Converted2 == false);
        }
    }

    class Calculate : ICalculate
    {
        public string Greetings;
        public Calculate()
        {
            Greetings = "Hi, I'll help you to Calculate!";
            WriteLine(Greetings);
        }
        int ICalculate.Subtraction(int a, int b)
        {
            return a - b;
        }

   
    }

    public interface ICalculate
    {
        public int Addition(int a, int b)
        {
            return a + b;   
        }
        public int Subtraction(int a, int b);


    }
}