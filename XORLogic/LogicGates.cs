using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XORLogic
{
    public static class LogicGates
    {
        public static string NOT(string binNumber)
        {
            string ans = "";
            foreach (char val in binNumber)
            {
                if (val == '1') ans += '0';
                if (val == '0') ans += '1';
            }
            return ans;
        }
        public static string AND(string bin1, string bin2)
        {
            List<string> l = new List<string>() { bin1, bin2 };
            string first = l.OrderByDescending(s => s.Length).First();
            string second = l.OrderByDescending(s => s.Length).Last();
            second = second.PadLeft(first.Length, '0');
            //Console.ForegroundColor = ConsoleColor.Blue;

            //Console.ForegroundColor = ConsoleColor.White;

            string ans = "";
            for (int i = 0; i < first.Length; i++)
            {
                ans += Convert.ToInt32(Convert.ToBoolean(int.Parse(first.ToCharArray()[i].ToString())) && Convert.ToBoolean(int.Parse(second.ToCharArray()[i].ToString())));
            }
            return ans;

        }
        public static string OR(string bin1, string bin2)
        {
            List<string> l = new List<string>() { bin1, bin2 };
            string first = l.OrderByDescending(s => s.Length).First();
            string second = l.OrderByDescending(s => s.Length).Last();
            second = second.PadLeft(first.Length, '0');

            string ans = "";
            for (int i = 0; i < first.Length; i++)
            {
                ans += Convert.ToInt32(Convert.ToBoolean(int.Parse(first[i].ToString())) || Convert.ToBoolean(int.Parse(second[i].ToString())));
            }
            return ans;
        }
        public static string NAND(string bin1, string bin2)
        {
            List<string> l = new List<string>() { bin1, bin2 };
            string first = l.OrderByDescending(s => s.Length).First();
            string second = l.OrderByDescending(s => s.Length).Last();
            second = second.PadLeft(first.Length, '0');

            string ans = "";
            for (int i = 0; i < first.Length; i++)
            {
                ans += Convert.ToInt32(!(Convert.ToBoolean(int.Parse(first[i].ToString())) && Convert.ToBoolean(int.Parse(second[i].ToString()))));
            }
            return ans;
        }
    }
}
