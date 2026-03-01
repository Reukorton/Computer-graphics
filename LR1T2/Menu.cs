using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LR1T2
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void LabWork1_Button_Click(object sender, EventArgs e)
        {
            using (Form1 form1 = new Form1())
            {
                this.Hide();
                form1.ShowDialog();
                this.Show();
            }
        }

        private void LabWork2_Button_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "Нет тут пока ничего. Надеемся, что хотя бы в этом семестре добавим.",
                "Отсутствует",
                MessageBoxButtons.OK
                );
        }

        private void LabWork3_Button_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "Нет тут пока ничего. Надеемся, что хотя бы в этом семестре добавим.",
                "Отсутствует",
                MessageBoxButtons.OK
                );
        }

        private void LabWork4_Button_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "Нет тут пока ничего. Надеемся, что хотя бы в этом семестре добавим.",
                "Отсутствует",
                MessageBoxButtons.OK
                );
        }
    }
}
