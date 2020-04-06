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
    public partial class InfoForm : Form
    {
        public InfoForm()
        {
            InitializeComponent();
            
        }

        public void ShowArtists()
        {
            this.Text = "Авторы";
            textBox.Text = @"
Татаринцев Артем
Подвойский Кирилл
Колесов Михаил
Группа: ПМИ-71";
            this.Show();
        }
        public void ShowAbout()
        {
            this.Text = "О программе";
            textBox.Text = @"
Калькулятор р-ичных чисел

Калькулятор обеспечивает работу с числами в 
системах счисления с основанием в диапазоне от 2 до 16

Основание системы счисления – настраиваемый параметр.";
            this.Show();
        }
    }
}
