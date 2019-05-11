using System;
using System.IO;
using System.Windows.Forms;

namespace Lvq
{
    public partial class MainForm : Form
    {      
        public MainForm()
        {
            InitializeComponent();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            progressBar1.Value = 0;
            panel1.Enabled = false;
            bool flag = true;           
            if (radioButton1.Checked) flag = false;
            Functions f = new Functions();
            f.Run(Convert.ToInt16(tbTrainCount.Text), Convert.ToInt16(tbTestCount.Text), Convert.ToInt16(tbCodebookCount.Text), Convert.ToInt16(tbTourCount.Text), Convert.ToDouble(tbW.Text), Convert.ToDouble(tbAlfa.Text), Convert.ToDouble(tbEpsilon.Text), flag,progressBar1,checkBox1.Checked, Convert.ToInt16(tbMK.Text));
            panel1.Enabled = true;           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FileInfo fi = new FileInfo("sonuclar.xlsx");
            if (fi.Exists)
            {
                System.Diagnostics.Process.Start("sonuclar.xlsx");
            }
            else
            {
                MessageBox.Show("Daha önce hiç bir kayıt oluşturulmadı.");
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if(radioButton1.Checked)
                tbEpsilon.Enabled = false;
            else
                tbEpsilon.Enabled = true;
        }
    }
}
