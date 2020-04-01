using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class TProc
    {
        public enum TOprtn
        {
            None = 1,
            Add,
            Sub,
            Mul,
            Dvd
        }
        public enum TFunc
        {
            Rev = 1,
            Sqr,
            None
        }
        TOprtn Operation;
        TFunc Function;
        TPNumber Lop_Res, Rop;
        public TProc()
        {
            Operation = TOprtn.None;
            Function = TFunc.None;
            Lop_Res = new TPNumber();
            Rop = new TPNumber();
        }
        public void ResetProcessor()
        {
            OperationReset();
            FunctionReset();
            Lop_Res.Reset();
            Rop.Reset();
        }
        public void OperationReset()
        {
            Operation = TOprtn.None;
        }
        public void FunctionReset()
        {
            Function = TFunc.None;
        }
        public void ExecuteOperation()
        {
            switch(Operation)
            {
                case TOprtn.Add:
                    Lop_Res = Lop_Res.Add(Rop);
                    break;
                case TOprtn.Sub:
                    Lop_Res = Lop_Res.Subtract(Rop);
                    break;
                case TOprtn.Mul:
                    Lop_Res = Lop_Res.Multiply(Rop);
                    break;
                case TOprtn.Dvd:
                    Lop_Res = Lop_Res.Divide(Rop);
                    break;
                default:
                    break;
            }
        }
        public void ExecuteFunction()
        {
            switch (Function)
            {
                case TFunc.Rev:
                    Rop = Rop.Invert(Rop);
                    break;
                case TFunc.Sqr:
                    Rop = Rop.Square(Rop);
                    break;
                default:
                    break;
            }
        }
        public TPNumber ReadLeftOperand()
        {
            return Lop_Res.Copy();
        }
        public void WriteLeftOperand(TPNumber Operand)
        {
            Lop_Res = Operand.Copy();
        }
        public TPNumber ReadRightOperand()
        {
            return Rop.Copy();
        }
        public void WriteRightOperand(TPNumber Operand)
        {
            Rop = Operand.Copy();
        }
        public TOprtn ReadOperation()
        {
            return Operation;
        }
        public void WriteOperation(TOprtn Oprtn)
        {
            Operation = Oprtn;
        }
        public TFunc ReadFunction()
        {
            return Function;
        }
        public void WriteFunction(TFunc Func)
        {
            Function = Func;
        }
    }
}
