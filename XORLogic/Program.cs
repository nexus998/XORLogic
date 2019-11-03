using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XORLogic
{
    class Program
    {
        static void Main(string[] args)
        {
            if(args.Length == 2)
            {
                int first, second;
                if (!int.TryParse(args[0], out first) || !int.TryParse(args[1], out second))
                {
                    Console.WriteLine("Invalid arguments. Press any key to continue...");
                    Console.ReadKey();
                    Init();
                    return;
                }
                LogicGateWorker.CalculateGateWithAllMethods(Convert.ToString(first, 2), Convert.ToString(second, 2));
            }
            else
            {
                if (args.Length == 0)
                {
                    Init();
                    return;
                }
                else
                {
                    Console.WriteLine("Invalid arguments. Press any key to continue...");
                    Console.ReadKey();
                    Init();
                    return;
                }
            }
        }
        public static void Init()
        {
            ProgramSettings.GetProgramFunctions().Clear();
            var x = new LogicGateWorker();
            var e = new ExitFunction();
            DoWelcomeScreen();
        }
        static bool correctSelection = false;
        public static void DoWelcomeScreen()
        {
            correctSelection = false;
            Console.Clear();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("XOR Logical Operations");
            Console.WriteLine("(made by Mindaugas Morkunas)");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();

            LoadPrograms();

            while (!correctSelection)
            {
                var input = Console.ReadKey();
                char res = '0';
                try
                {
                    string inp = input.Key.ToString();
                    if (inp.StartsWith("NumPad") || inp.StartsWith("D"))
                    {
                        res = inp.Last();
                    }
                    var selectedFunction = ProgramSettings.GetProgramFunction(int.Parse(res.ToString()) - 1);
                    selectedFunction.RunProgram();
                    correctSelection = true;
                    Console.Clear();
                }
                catch
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(" - Command not found. Press try again...");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
        }
        static void LoadPrograms()
        {
            for (int i = 0; i < ProgramSettings.GetProgramFunctions().Count; i++)
            {
                Console.WriteLine((i + 1) + ". " + ProgramSettings.GetProgramFunctions()[i].GetName());
            }
        }
    }
}
