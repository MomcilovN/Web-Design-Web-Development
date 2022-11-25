using System;
using System.Collections.Generic;
using System.Text;

namespace CalcTest
{
    class Calculator
    {
        public static string WriteText(string text)
        {
            return text;
        }

        public static string WriteNumber(int x, int y)
        {
            int number = x + y;
            return Convert.ToString(number);
        }
    }
}

