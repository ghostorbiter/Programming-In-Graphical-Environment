using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace prepLab2
{
    public partial class Form1 : Form
    {
        public Label usrName;
        public Label cpuName;
        public Label round;
        public Button next;

        private int roundsNum = 1;
        public int maxRounds = 0;

        public int cpuCount = 0;
        public int userCount = 0;

        public int rndCPU;
        public int rndUSR;

        public static Form1 instance;
        public Form1()
        {
            InitializeComponent();
            instance = this;
            usrName = usrNameINPT;
            cpuName = cpuNameINPT;
            round = rndINPT;
            next = nextRND;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            nextRND.Text = "Start";
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dig = MessageBox.Show("This is basically an app", "APP", MessageBoxButtons.OK);
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            newGameForm newGame = new newGameForm();
            newGame.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void nextRND_Click(object sender, EventArgs e)
        {
            nextRND.Text = "Next Round";
            if (roundsNum < maxRounds)
            {
                Random random = new Random();
                int rndCPU = random.Next() % 10 + 1;
                int rndUSR = random.Next() % 10 + 1;

                rndNumCPU.Text = $"{rndCPU}";
                rndNumUSR.Text = $"{rndUSR}";

                if (rndCPU > rndUSR)
                {
                    nextRND.BackColor = Color.Red;
                    cpuCount++;
                    cpuNum.Text = $"{cpuCount}";
                }
                else if (rndUSR > rndCPU)
                {
                    nextRND.BackColor = Color.Green;
                    userCount++;
                    usrNum.Text = $"{userCount}";
                }
                else
                {
                    nextRND.BackColor = Color.Orange;
                }

                roundsNum++;
                instance.rndINPT.Text = $"{roundsNum}";
            }
            else
            {
                if (cpuCount > userCount)
                    MessageBox.Show("CPU Win");
                else if (userCount > cpuCount)
                    MessageBox.Show("You Win");
                else
                    MessageBox.Show("DRAW");
                this.Close();
            }
                
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Close?", "Exit", MessageBoxButtons.YesNo) != DialogResult.Yes)
                e.Cancel = true;
        }
    }
}
