using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
using static XORLogic.LogicGates;

namespace XORLogic
{
    public class LogicGateWorker
    {
        public LogicGateWorker()
        {
            var x = new ProgramFunction("Calculate XOR Gate", EnterNumbers);
        }

        void EnterNumbers()
        {
            Console.Clear();
            int first=0;
            int second=0;
            Console.WriteLine("Enter two decimal numbers, seperated with a space:");
            while (true)
            {
                string res = Console.ReadLine();
                //first = res.Split(' ')[0];
                //second = res.Split(' ')[1];
                if (!int.TryParse(res.Split(' ')[0], out first) || !int.TryParse(res.Split(' ')[1], out second))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid arguments.");
                    Console.ForegroundColor = ConsoleColor.White;
                    continue;
                }
                CalculateGateWithAllMethods(Convert.ToString(first, 2), Convert.ToString(second, 2));
                break;
            }
        }

        public static void CalculateGateWithAllMethods(string bin1, string bin2)
        {
            List<string> l = new List<string>() { bin1, bin2 };
            string first = l.OrderByDescending(s => s.Length).First();

            Console.Clear();
            PrintInitialValue(bin1,bin2);
            Console.WriteLine("---First method result---");
            Console.WriteLine("Binary value: " + CalculateGateWithFirstMethod(bin1, bin2, first.Length));
            Console.WriteLine("Decimal value: " + Convert.ToInt32(CalculateGateWithFirstMethod(bin1, bin2, first.Length), 2).ToString());
            Console.WriteLine("-------------------------");
            Console.WriteLine();
            Console.WriteLine("---Second method result--");
            Console.WriteLine("Binary value: " + CalculateGateWithSecondMethod(bin1, bin2, first.Length));
            Console.WriteLine("Decimal value: " + Convert.ToInt32(CalculateGateWithSecondMethod(bin1, bin2, first.Length), 2).ToString());
            Console.WriteLine("-------------------------");
            Console.WriteLine();
            Console.WriteLine("---Third method result---");
            Console.WriteLine("Binary value: " + CalculateGateWithThirdMethod(bin1, bin2, first.Length));
            Console.WriteLine("Decimal value: " + Convert.ToInt32(CalculateGateWithThirdMethod(bin1, bin2, first.Length), 2).ToString());
            Console.WriteLine("-------------------------");
            Console.WriteLine();
            Console.WriteLine("---Fourth method result--");
            Console.WriteLine("Binary value: " + CalculateGateWithFourthMethod(bin1, bin2, first.Length));
            Console.WriteLine("Decimal value: " + Convert.ToInt32(CalculateGateWithFourthMethod(bin1, bin2, first.Length), 2).ToString());
            Console.WriteLine("-------------------------");
            Console.WriteLine();
            PrintToCSVFile(bin1, bin2);
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Program.Init();
        }

        static void PrintToCSVFile(string bin1, string bin2)
        {
            List<string> l = new List<string>() { bin1, bin2 };
            string first = l.OrderByDescending(s => s.Length).First();
            using (StreamWriter file = new StreamWriter(Directory.GetCurrentDirectory() + "\\output.csv"))
            {
                file.WriteLine("Mindaugas Morkunas PRIF-18/3");
                file.WriteLine(Convert.ToInt32(bin1, 2).ToString() + "," + Convert.ToInt32(bin2, 2).ToString());
                file.WriteLine("OR(AND(NOT(A);B);AND(NOT(A);B),NAND(NAND(A;NAND(A;B));NAND(B;NAND(A;B))),AND(OR(A;B);NOT(AND(A;B))),AND(OR(A;B);OR(NOT(A);NOT(B)))");
                file.WriteLine(Convert.ToInt32(CalculateGateWithFirstMethod(bin1, bin2, first.Length), 2).ToString() + "," + Convert.ToInt32(CalculateGateWithSecondMethod(bin1, bin2, first.Length), 2).ToString() + "," +
                    Convert.ToInt32(CalculateGateWithThirdMethod(bin1, bin2, first.Length), 2).ToString() + "," + Convert.ToInt32(CalculateGateWithFourthMethod(bin1, bin2, first.Length), 2).ToString());
            }
        }

        public static string CalculateGateWithFirstMethod(string binA, string binB, int dist)
        {
            binA = binA.PadLeft(dist, '0');
            binB = binB.PadLeft(dist, '0');
            return OR(AND(NOT(binA), binB), AND(NOT(binB), binA));
        }

        public static string CalculateGateWithSecondMethod(string binA, string binB, int dist)
        {
            binA = binA.PadLeft(dist, '0');
            binB = binB.PadLeft(dist, '0');
            return NAND(NAND(binA, NAND(binA, binB)), NAND(binB, NAND(binA, binB)));
        }

        public static string CalculateGateWithThirdMethod(string binA, string binB, int dist)
        {
            binA = binA.PadLeft(dist, '0');
            binB = binB.PadLeft(dist, '0');
            return AND(OR(binA, binB), NOT(AND(binA, binB)));
        }

        public static string CalculateGateWithFourthMethod(string binA, string binB, int dist)
        {
            binA = binA.PadLeft(dist, '0');
            binB = binB.PadLeft(dist, '0');
            return AND(OR(binA, binB), OR(NOT(binA), NOT(binB)));
        }

        static void PrintInitialValue(string a, string b)
        {
            Console.WriteLine("Initial values: " + Convert.ToInt32(a, 2).ToString() + " and " + Convert.ToInt32(b, 2).ToString());
            Console.WriteLine();
        }
    }
}
