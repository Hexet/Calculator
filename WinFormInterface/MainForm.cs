using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using ClassLibrary;

namespace WinFormInterface
{
    public partial class MainForm : Form
    {
        public TCtrl control = new TCtrl();
        public MainForm()
        {
            InitializeComponent();
            KeyDown += Interface_KeyDown;
            trackBar.ValueChanged += TrackBar_ValueChanged;
            numUpDown.ValueChanged += NumUpDown_ValueChanged;
            control.number.systemBase = trackBar.Value;
            Enabled_Num();
            but0.Click += But_Click;
            but1.Click += But_Click;
            but2.Click += But_Click;
            but3.Click += But_Click;
            but4.Click += But_Click;
            but5.Click += But_Click;
            but6.Click += But_Click;
            but7.Click += But_Click;
            but8.Click += But_Click;
            but9.Click += But_Click;
            butA.Click += But_Click;
            butB.Click += But_Click;
            butC.Click += But_Click;
            butD.Click += But_Click;
            butE.Click += But_Click;
            butF.Click += But_Click;
            butPoint.Click += ButPoint_Click;
            butPM.Click += ButPM_Click;
            butCE.Click += ButCE_Click;
            butBack.Click += ButBack_Click;
            butPlus.Click += ButPlus_Click;
            butMinus.Click += ButMinus_Click;
            butMul.Click += ButMul_Click;
            butDiv.Click += ButDiv_Click;
            butSquare.Click += ButSquare_Click;
            butInvert.Click += ButInvert_Click;
            butClear.Click += ButClear_Click;
            butRes.Click += ButRes_Click;
        }

        private void ButRes_Click(object sender, EventArgs e)
        {
            textBox.Text = control.GetResult();
        }

        private void ButClear_Click(object sender, EventArgs e)
        {
            textBox.Text = control.Clear();
        }

        private void ButInvert_Click(object sender, EventArgs e)
        {
            textBox.Text = control.ExecuteCalculatorCommand(TCtrl.CalculatorCommand.reverse);
        }

        private void ButSquare_Click(object sender, EventArgs e)
        {
            textBox.Text = control.ExecuteCalculatorCommand(TCtrl.CalculatorCommand.square);
        }

        private void ButDiv_Click(object sender, EventArgs e)
        {
            textBox.Text = control.ExecuteCalculatorCommand(TCtrl.CalculatorCommand.divide);
        }

        private void ButMul_Click(object sender, EventArgs e)
        {
            textBox.Text = control.ExecuteCalculatorCommand(TCtrl.CalculatorCommand.multiply);
        }

        private void ButMinus_Click(object sender, EventArgs e)
        {
            textBox.Text = control.ExecuteCalculatorCommand(TCtrl.CalculatorCommand.subtract);
        }

        private void ButPlus_Click(object sender, EventArgs e)
        {
            textBox.Text = control.ExecuteCalculatorCommand(TCtrl.CalculatorCommand.add);
        }

        private void ButBack_Click(object sender, EventArgs e)
        {
            textBox.Text = control.ExecuteEditorCommand(TCtrl.EditCommand.backspace);
        }

        private void ButCE_Click(object sender, EventArgs e)
        {
            textBox.Text = control.ExecuteEditorCommand(TCtrl.EditCommand.clear);
        }

        private void ButPM_Click(object sender, EventArgs e)
        {
            textBox.Text = control.ExecuteEditorCommand(TCtrl.EditCommand.addSign);
        }

        private void ButPoint_Click(object sender, EventArgs e)
        {
            textBox.Text = control.ExecuteEditorCommand(TCtrl.EditCommand.addDelim);
        }

        private void But_Click(object sender, EventArgs e)
        {
            control.SetUpEditor();
            textBox.Text = control.ExecuteEditorCommand(TCtrl.EditCommand.addDigit, (sender as Button).Text);
        }
        private void NumUpDown_ValueChanged(object sender, EventArgs e)
        {
            trackBar.Value = Convert.ToInt32(numUpDown.Value);
            control.number.systemBase = Convert.ToInt32(numUpDown.Value); ;
            Enabled_Num();
        }
        private void TrackBar_ValueChanged(object sender, EventArgs e)
        {
            numUpDown.Value = trackBar.Value;
            control.number.systemBase = trackBar.Value;
            Enabled_Num();
        }
        private void Enabled_Num()
        {
            var numberRegex = new Regex(@"[2-9]");
            var symbolRegex = new Regex(@"^[A-F]$");
            foreach (Button b in this.Controls.OfType<Button>())
            {
                if (numberRegex.IsMatch(b.Text) && b.Text.Length == 1)
                    b.Enabled = trackBar.Value > b.Text[0] - 48;

                else if (symbolRegex.IsMatch(b.Text) && b.Name.Length == 4)
                    b.Enabled = trackBar.Value > b.Text[0] - 55;
            }
        }
        private void Interface_KeyDown(object sender, KeyEventArgs e)
        {
            control.SetUpEditor();
            switch (e.KeyData)
            {
                case Keys key when (key >= Keys.D0 && key <= Keys.D9 && control.number.systemBase > e.KeyValue - 48):
                    textBox.Text = control.ExecuteEditorCommand(TCtrl.EditCommand.addDigit, (e.KeyValue - 48).ToString());
                    break;

                case Keys key when (key >= Keys.NumPad0 && key <= Keys.NumPad9 && control.number.systemBase > e.KeyValue - 96):
                    textBox.Text = control.ExecuteEditorCommand(TCtrl.EditCommand.addDigit, (e.KeyValue - 96).ToString());
                    break;

                case Keys key when (key >= Keys.A && key <= Keys.F && control.number.systemBase > e.KeyValue - 55):
                    textBox.Text = control.ExecuteEditorCommand(TCtrl.EditCommand.addDigit, (key.ToString()));
                    break;

                case Keys.Back:
                case Keys.Delete:
                    textBox.Text = control.ExecuteEditorCommand(TCtrl.EditCommand.backspace);
                    break;

                case Keys.OemPeriod:
                case Keys.Decimal:
                    textBox.Text = control.ExecuteEditorCommand(TCtrl.EditCommand.addDelim);
                    break;

                default:
                    return;
            }

        }
    }
}
