using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormInterface
{

    public partial class SettingsForm : Form
    {
        MainForm main;
        public SettingsForm()
        {
            InitializeComponent();
            butBack.Click += ButBack_Click;
            numUpDownSetting.ValueChanged += numUpDownSetting_ValueChanged;
            trackBarSetting.ValueChanged += trackBarSetting_ValueChanged;
        }


        private void trackBarSetting_ValueChanged(object sender, EventArgs e)
        {
            main = this.Owner as MainForm;
            numUpDownSetting.Value = trackBarSetting.Value;
            if (main != null)
            {
                main.SystemBaseChangedSetting(trackBarSetting.Value);
            }
        }
        private void numUpDownSetting_ValueChanged(object sender, EventArgs e)
        {
            trackBarSetting.Value = Convert.ToInt32(numUpDownSetting.Value);
        }
        private void ButBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void ShowForm()
        {
            this.ShowDialog();
        }
    }
}
