using System;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;

namespace Lab2ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            string option;
            double ar, ai, br, bi;
            var Calculator = new ServiceReference1.ComplexCalculatorClient();
            ServiceReference1.Complex complex;

            do
            {

                Console.WriteLine("---||-----------------------------------||---");
                Console.WriteLine("---||--- Kalkulator licz zespolonych ---||---");
                Console.WriteLine("---||--- 1. - Dodawanie              ---||---");
                Console.WriteLine("---||--- 2. - Odejmowanie            ---||---");
                Console.WriteLine("---||--- 3. - Mnożenie               ---||---");
                Console.WriteLine("---||--- 4. - Dzielenie              ---||---");
                Console.WriteLine("---||--- 5. - Wyjście                ---||---");
                Console.WriteLine("---||-----------------------------------||---");

                option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        try
                        {
                            EnterNumbers();
                            complex = Calculator.AddDoubleDataAsync(ar, ai, br, bi).Result;
                            Console.WriteLine("Wynik: " + ComplexToString(complex) + "\n");
                        }
                        catch (AggregateException ae)
                        {
                            foreach(Exception ex in ae.InnerExceptions)
                            {
                                Console.WriteLine(ex.Message);
                            }
                        }
                        break;
                    case "2":
                        try
                        {
                            EnterNumbers();
                            complex = Calculator.SubstractDoubleDataAsync(ar, ai, br, bi).Result;
                            Console.WriteLine("Wynik: " + ComplexToString(complex) + "\n");
                        }
                        catch (AggregateException ae)
                        {
                            foreach (Exception ex in ae.InnerExceptions)
                            {
                                Console.WriteLine(ex.Message);
                            }
                        }
                        break;
                    case "3":
                        try
                        {
                            EnterNumbers();
                            complex = Calculator.MultiplyDoubleDataAsync(ar, ai, br, bi).Result;
                            Console.WriteLine("Wynik: " + ComplexToString(complex) + "\n");
                        }
                        catch (AggregateException ae)
                        {
                            foreach (Exception ex in ae.InnerExceptions)
                            {
                                Console.WriteLine(ex.Message);
                            }
                        }
                        break;
                    case "4":
                        try
                        {
                            EnterNumbers();
                            complex = Calculator.DivideDoubleDataAsync(ar, ai, br, bi).Result;
                            Console.WriteLine("Wynik: " + ComplexToString(complex) + "\n");
                        }
                        catch (AggregateException ae)
                        {
                            foreach (Exception ex in ae.InnerExceptions)
                            {
                                Console.WriteLine(ex.Message);
                            }
                        }
                        break;
                    case "5":

                        break;
                    default:
                            Console.WriteLine("Nie ma takiej opcji");
                        break;
                }


            } while (option != "5");

            void EnterNumbers()
            {
                Console.WriteLine("Podaj A - część rzeczywista");
                while(!double.TryParse(Console.ReadLine(), out ar))
                {
                    Console.WriteLine("Nie poprawna wartość");
                }
                Console.WriteLine("Podaj A - część urojona");
                while (!double.TryParse(Console.ReadLine(), out ai))
                {
                    Console.WriteLine("Nie poprawna wartość");
                }
                Console.WriteLine("Podaj B - część rzeczywista");
                while (!double.TryParse(Console.ReadLine(), out br))
                {
                    Console.WriteLine("Nie poprawna wartość");
                }
                Console.WriteLine("Podaj B - część urojona");
                while (!double.TryParse(Console.ReadLine(), out bi))
                {
                    Console.WriteLine("Nie poprawna wartość");
                }
            }
            string ComplexToString(ServiceReference1.Complex complex)
            {
                if (complex.Imag == 0.0)
                {
                    return complex.Real.ToString();
                }
                if (complex.Imag < 0.0)
                {
                    return complex.Real.ToString() + " - " + (complex.Imag * -1).ToString() + "i";
                }
                return complex.Real.ToString() + " + " + complex.Imag.ToString() + "i";
            }
        }
    }

}
