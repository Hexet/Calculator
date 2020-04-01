using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class TEditior
    {
        public string number { get; set; }

        const string delim = ".";
        const string zero = "0";
        
        public TEditior()
        {
            number = zero;
        }
        public bool NumberIsZero()
        {
            return number == zero;
        }
        public string AddSign()
        {
            if (!NumberIsZero())
                if (number[0] != '-')
                    number = '-' + number;
                else number = number.Substring(1);
            return number;
        }
        public string AddDigit(string n)
        {
            if (NumberIsZero())
                number = Convert.ToString(n);
            else
                number += Convert.ToString(n);
            return number;
        }
        public string AddZero()
        {
            if (!NumberIsZero())
                number += zero;
            return number;
        }

        public string AddDelim()
        {
            if(!number.Contains(delim))
                number += delim;
            return number;
        }
        public string DeleteSymbol()
        {
            if (!NumberIsZero())
                if (number.Length > 1)
                    number = number.Substring(0, number.Length - 1);
                else number = zero;
            return number;
        }
        public string Clear()
        {
            number = zero;
            return number;
        }
        
    }
}
