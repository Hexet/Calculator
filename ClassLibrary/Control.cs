using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class TCtrl
    {
        Action activeState;
        bool clear = false, oneRepeat = true;
        public enum EditCommand
        {
            addDigit = 1,
            backspace,
            clear,
            addSign,
            addDelim
        }
        public enum CalculatorCommand
        {
            add = 1,
            subtract,
            multiply,
            divide,
            square,
            reverse
        }
        public enum MemoryCommand
        {
            clear = 1,
            write,
            add,
            read,
            sub
        }
        public TCtrl()
        {
            SetInitialStateCalculator();
        }
        public TEditior editor = new TEditior();
        public TProc processor = new TProc();
        public TPNumber number = new TPNumber();
        public TMemory memory = new TMemory();
        public Converter converter = new Converter();
        public string Clear()
        {
            processor.ResetProcessor();
            SetInitialStateCalculator();
            number.Reset();
            clear = false;
            return editor.Clear();
        }
        public void SetUpEditor()
        {
            if (clear)
                editor.Clear();
        }
        public string ExecuteEditorCommand(EditCommand type, string n = "")
        {
            clear = false;
            switch (type)
            {
                case EditCommand.addDigit:
                    if (n == "0")
                        return editor.AddZero();
                    else
                        return editor.AddDigit(n);

                case EditCommand.backspace:
                    return editor.DeleteSymbol();

                case EditCommand.clear:
                    return editor.Clear();

                case EditCommand.addSign:
                    return editor.AddSign();

                case EditCommand.addDelim:
                    return editor.AddDelim();

                default:
                    return editor.number;
            }
        }
        public string ExecuteCalculatorCommand(CalculatorCommand cmd)
        {
            clear = true; oneRepeat = true;
            switch (cmd)
            {
                case CalculatorCommand.add:
                    ExecuteOperation(TProc.TOprtn.Add);
                    break;
                case CalculatorCommand.subtract:
                    ExecuteOperation(TProc.TOprtn.Sub);
                    break;
                case CalculatorCommand.multiply:
                    ExecuteOperation(TProc.TOprtn.Mul);
                    break;
                case CalculatorCommand.divide:
                    ExecuteOperation(TProc.TOprtn.Dvd);
                    break;
                case CalculatorCommand.square:
                    ExecuteFunction(TProc.TFunc.Sqr);
                    break;
                case CalculatorCommand.reverse:
                    ExecuteFunction(TProc.TFunc.Rev);
                    break;
                default:
                    break;
            }
            return editor.number;
        }
        public void SetInitialStateCalculator()
        {
            setState(FirstOperand);
        }
        public void setState(Action state)
        {
            activeState = state;
        }
        public void update()
        {
            activeState();
        }
        public string GetResult()
        {
            if (oneRepeat)
            {
                number = converter.ConvertBaseTo10(number.systemBase, editor.number);
                oneRepeat = false;
            }

            update();
            setState(SecondOperand);
            return editor.number;
        }
        void ExecuteOperation(TProc.TOprtn oprtn)
        {
            update();
            processor.WriteOperation(oprtn);
        }
        void ExecuteFunction(TProc.TFunc func)
        {
            number = converter.ConvertBaseTo10(number.systemBase, editor.number);
            processor.WriteRightOperand(number);
            
            processor.WriteFunction(func);
            processor.ExecuteFunction();
            if (activeState == FirstOperand)
            {
                processor.WriteLeftOperand(processor.ReadRightOperand());
                setState(SecondOperand);
            }

            editor.number = converter.Convert10ToBase(number.systemBase, processor.ReadRightOperand().number.ToString());
        }
        void FirstOperand()
        {
            number = converter.ConvertBaseTo10(number.systemBase, editor.number);
            processor.WriteLeftOperand(number);
            setState(SecondOperand);
        }
        void SecondOperand()
        {
            if (oneRepeat)
                number = converter.ConvertBaseTo10(number.systemBase, editor.number);
            processor.WriteRightOperand(number);
            processor.ExecuteOperation();
            editor.number = converter.Convert10ToBase(number.systemBase, processor.ReadLeftOperand().number.ToString());
            setState(SecondOperand);
        }
        public string ChangeSystemBase(int _base)
        {
            number = converter.ConvertBaseTo10(number.systemBase, editor.number);
            number.systemBase = _base;
            editor.number = converter.Convert10ToBase(number.systemBase, number.GetNumberString());
            return editor.number;
        }
        public string ExecuteMemoryCommand(MemoryCommand cmd)
        {
            number = converter.ConvertBaseTo10(number.systemBase, editor.number);
            switch (cmd)
            {
                case MemoryCommand.add:
                    memory.Add(number);
                    break;
                case MemoryCommand.sub:
                    memory.Sub(number);
                    break;
                case MemoryCommand.clear:
                    memory.Clear(number);
                    break;
                case MemoryCommand.read:
                    number = memory.ReadNumber(number);
                    break;
                case MemoryCommand.write:
                    memory.Write(number);
                    break;
                default:
                    break;
            }
            editor.number = converter.Convert10ToBase(number.systemBase, number.GetNumberString());
            return editor.number;
        }

    }
}
