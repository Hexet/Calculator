using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics.Contracts;

namespace ClassLibrary
{
    public class TPNumber
    {
        const int DefaultAccuracy = 5;
        const string StrDefaultAccur = "5";
        public double number { get; set; }
        public int systemBase { get; set; }
        public int accuracy { get; set; }

        public TPNumber()
        {
            number = 0;
            systemBase = 0;
            accuracy = DefaultAccuracy;
        }
        public TPNumber(double a, int b, int c = DefaultAccuracy)
        {
            number = a;
            systemBase = b;
            accuracy = c;
        }
        public TPNumber(string a, string b, string c = StrDefaultAccur)
        {
            number = Convert.ToDouble(a);
            systemBase = Convert.ToInt32(b);
            accuracy = Convert.ToInt32(c);
        }
        public TPNumber Reset()
        {
            number = 0;
            accuracy = DefaultAccuracy;
            return this;
        }
        public TPNumber Copy()
        {
            return new TPNumber(number, systemBase, accuracy);
        }
        public TPNumber Add(TPNumber d)
        {
            return new TPNumber(number + d.number, systemBase, accuracy);
        }
        public TPNumber Multiply(TPNumber d)
        {
            return new TPNumber(number * d.number, systemBase, accuracy);
        }
        public TPNumber Subtract(TPNumber d)
        {
            return new TPNumber(number - d.number, systemBase, accuracy);
        }
        public TPNumber Divide(TPNumber d)
        {
            if (d.number == 0)
                return null;
            return new TPNumber(number / d.number, systemBase, accuracy);
        }
        public TPNumber Invert(TPNumber d)
        {
            if (number == 0)
                return null;
            return new TPNumber(1 / number, systemBase, accuracy);
        }
        public TPNumber Square(TPNumber d)
        {
            return new TPNumber(number * number, systemBase, accuracy);
        }
        public string GetNumberString()
        {
            return Convert.ToString(number);
        }
        public string GetBaseString()
        {
            return Convert.ToString(systemBase);
        }
        public string GetAccuracyString()
        {
            return Convert.ToString(accuracy);
        }
        public void SetBaseString(string _base)
        {
            systemBase = Convert.ToInt32(_base);
        }
        public void SetAccuracyString(string _accur)
        {
            accuracy = Convert.ToInt32(_accur);
        }
    }
}
