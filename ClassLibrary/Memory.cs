using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class TMemory
    {
        TPNumber FNumber;
        public enum MState
        {
            _On = 1,
            _Off
        }
        MState FState;
        public TMemory()
        {
            FNumber = new TPNumber();
            FState = MState._Off;
        }
        public void Write(TPNumber E)
        {
            FNumber = E.Copy();
            FState = MState._On;
        }
        public void Add(TPNumber E)
        {
            FNumber = FNumber.Add(E);
        }
        public void Clear()
        {
            FNumber.Reset();
            FState = MState._Off;
        }
        public string ReadStatusMemory()
        {
            return FState.ToString();
        }
        public TPNumber ReadNumber()
        {
            return FNumber.Copy();
        }
    }
}
