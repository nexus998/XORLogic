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
            binNumber = binNumber.PadLeft(4, '0');
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
            string ans = "";
            for (int i = 0; i < bin1.Length; i++)
            {
                ans += Convert.ToInt32(Convert.ToBoolean(int.Parse(bin1.ToCharArray()[i].ToString())) && Convert.ToBoolean(int.Parse(bin2.ToCharArray()[i].ToString())));
            }
            return ans;

        }
        public static string OR(string bin1, string bin2)
        {
            string ans = "";
            for (int i = 0; i < bin1.Length; i++)
            {
                ans += Convert.ToInt32(Convert.ToBoolean(int.Parse(bin1[i].ToString())) || Convert.ToBoolean(int.Parse(bin2[i].ToString())));
            }
            return ans;
        }
        public static string NAND(string bin1, string bin2)
        {
            string ans = "";
            for (int i = 0; i < bin1.Length; i++)
            {
                ans += Convert.ToInt32(!(Convert.ToBoolean(int.Parse(bin1[i].ToString())) && Convert.ToBoolean(int.Parse(bin2[i].ToString()))));
            }
            return ans;
        }
    }
}
