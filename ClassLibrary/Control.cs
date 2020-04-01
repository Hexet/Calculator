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
        bool clear = false;
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
            clear = true;
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
            setState(Start);
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
            update();
            SetInitialStateCalculator();
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
            editor.number = processor.ReadRightOperand().number.ToString();
        }
        public void ExecuteMemoryCommand()
        {

        }
        void Start()
        {
            number = converter.ConvertBaseTo10(number.systemBase, editor.number);
            processor.WriteLeftOperand(number);
            setState(Editing);
        }
        void Editing()
        {
            number = converter.ConvertBaseTo10(number.systemBase, editor.number);
            processor.WriteRightOperand(number);
            processor.ExecuteOperation();
            editor.number = processor.ReadLeftOperand().number.ToString();
            setState(Editing);
        }
        void FunDone()
        {

        }
        void ValDone()
        {

        }
        void ExpDone()
        {

        }
        void OpChange()
        {

        }
        void Error()
        {

        }
    }
}
