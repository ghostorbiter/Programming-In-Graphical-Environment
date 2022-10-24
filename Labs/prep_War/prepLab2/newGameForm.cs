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

namespace prepLab2
{
    public partial class newGameForm : Form
    {
        public newGameForm()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            if (textBox1.Text.Length == 0 || !textBox1.Text.All(char.IsLetterOrDigit) || textBox1.Text.Length > 8)
            {
                userNameERR.SetError(userName, "Invalid User Name data");
                e.Cancel = true;
                return;
            }
            userNameERR.SetError(userName, string.Empty);
            e.Cancel = false;
        }

        private void textBox2_Validating(object sender, CancelEventArgs e)
        {
            if (textBox2.Text.Length == 0 || !textBox2.Text.All(char.IsLetterOrDigit) || textBox2.Text.Length > 8)
            {
                cpuNameERR.SetError(cpuName, "Invalid CPU Name data");
                e.Cancel = true;
                return;
            }
            cpuNameERR.SetError(cpuName, string.Empty);
            e.Cancel = false;
        }

        private void textBox3_Validating(object sender, CancelEventArgs e)
        {
            if (textBox3.Text.Length == 0 || !textBox3.Text.All(char.IsDigit) || textBox3.Text.Length > 2)
            {
                roundsERR.SetError(rounds, "Invalid Rounds data");
                e.Cancel = true;
                return;
            }
            roundsERR.SetError(rounds, string.Empty);
            e.Cancel = false;
        }

        private void newGameButton_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren())
            {
                Form1.instance.cpuCount = 0;
                Form1.instance.userCount = 0;
                Form1.instance.maxRounds = 0;

                Form1.instance.rndCPU = 0;
                Form1.instance.rndUSR = 0;

                Form1.instance.next.BackColor = Color.Orange;

                Form1.instance.usrName.Text = textBox1.Text;
                Form1.instance.cpuName.Text = textBox2.Text;
                Form1.instance.maxRounds = int.Parse(textBox3.Text);                

                this.Close();
            }
        }
    }
}
