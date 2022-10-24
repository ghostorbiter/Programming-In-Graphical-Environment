
namespace prepLab2
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.gameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.usrNameINPT = new System.Windows.Forms.Label();
            this.cpuNameINPT = new System.Windows.Forms.Label();
            this.rndINPT = new System.Windows.Forms.Label();
            this.nextRND = new System.Windows.Forms.Button();
            this.cpuNum = new System.Windows.Forms.Label();
            this.usrNum = new System.Windows.Forms.Label();
            this.rndNumCPU = new System.Windows.Forms.Label();
            this.rndNumUSR = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gameToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(784, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // gameToolStripMenuItem
            // 
            this.gameToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newGameToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.gameToolStripMenuItem.Name = "gameToolStripMenuItem";
            this.gameToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.gameToolStripMenuItem.Text = "Game";
            // 
            // newGameToolStripMenuItem
            // 
            this.newGameToolStripMenuItem.Name = "newGameToolStripMenuItem";
            this.newGameToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.newGameToolStripMenuItem.Text = "New Game";
            this.newGameToolStripMenuItem.Click += new System.EventHandler(this.newGameToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // splitter1
            // 
            this.splitter1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.splitter1.Location = new System.Drawing.Point(0, 24);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(156, 437);
            this.splitter1.TabIndex = 1;
            this.splitter1.TabStop = false;
            // 
            // usrNameINPT
            // 
            this.usrNameINPT.AutoSize = true;
            this.usrNameINPT.Location = new System.Drawing.Point(13, 43);
            this.usrNameINPT.Name = "usrNameINPT";
            this.usrNameINPT.Size = new System.Drawing.Size(71, 15);
            this.usrNameINPT.TabIndex = 2;
            this.usrNameINPT.Text = "USER NAME";
            // 
            // cpuNameINPT
            // 
            this.cpuNameINPT.AutoSize = true;
            this.cpuNameINPT.Location = new System.Drawing.Point(13, 72);
            this.cpuNameINPT.Name = "cpuNameINPT";
            this.cpuNameINPT.Size = new System.Drawing.Size(67, 15);
            this.cpuNameINPT.TabIndex = 3;
            this.cpuNameINPT.Text = "CPU NAME";
            // 
            // rndINPT
            // 
            this.rndINPT.AutoSize = true;
            this.rndINPT.Location = new System.Drawing.Point(13, 102);
            this.rndINPT.Name = "rndINPT";
            this.rndINPT.Size = new System.Drawing.Size(13, 15);
            this.rndINPT.TabIndex = 4;
            this.rndINPT.Text = "0";
            // 
            // nextRND
            // 
            this.nextRND.BackColor = System.Drawing.Color.Orange;
            this.nextRND.Location = new System.Drawing.Point(13, 426);
            this.nextRND.Name = "nextRND";
            this.nextRND.Size = new System.Drawing.Size(125, 23);
            this.nextRND.TabIndex = 5;
            this.nextRND.Text = "Next Round";
            this.nextRND.UseVisualStyleBackColor = false;
            this.nextRND.Click += new System.EventHandler(this.nextRND_Click);
            // 
            // cpuNum
            // 
            this.cpuNum.AutoSize = true;
            this.cpuNum.Location = new System.Drawing.Point(125, 72);
            this.cpuNum.Name = "cpuNum";
            this.cpuNum.Size = new System.Drawing.Size(13, 15);
            this.cpuNum.TabIndex = 6;
            this.cpuNum.Text = "0";
            // 
            // usrNum
            // 
            this.usrNum.AutoSize = true;
            this.usrNum.Location = new System.Drawing.Point(125, 43);
            this.usrNum.Name = "usrNum";
            this.usrNum.Size = new System.Drawing.Size(13, 15);
            this.usrNum.TabIndex = 7;
            this.usrNum.Text = "0";
            // 
            // rndNumCPU
            // 
            this.rndNumCPU.AutoSize = true;
            this.rndNumCPU.Location = new System.Drawing.Point(447, 43);
            this.rndNumCPU.Name = "rndNumCPU";
            this.rndNumCPU.Size = new System.Drawing.Size(13, 15);
            this.rndNumCPU.TabIndex = 8;
            this.rndNumCPU.Text = "0";
            // 
            // rndNumUSR
            // 
            this.rndNumUSR.AutoSize = true;
            this.rndNumUSR.Location = new System.Drawing.Point(447, 426);
            this.rndNumUSR.Name = "rndNumUSR";
            this.rndNumUSR.Size = new System.Drawing.Size(13, 15);
            this.rndNumUSR.TabIndex = 9;
            this.rndNumUSR.Text = "0";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.rndNumUSR);
            this.Controls.Add(this.rndNumCPU);
            this.Controls.Add(this.usrNum);
            this.Controls.Add(this.cpuNum);
            this.Controls.Add(this.nextRND);
            this.Controls.Add(this.rndINPT);
            this.Controls.Add(this.cpuNameINPT);
            this.Controls.Add(this.usrNameINPT);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem gameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newGameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Label usrNameINPT;
        private System.Windows.Forms.Label cpuNameINPT;
        private System.Windows.Forms.Label rndINPT;
        private System.Windows.Forms.Button nextRND;
        private System.Windows.Forms.Label cpuNum;
        private System.Windows.Forms.Label usrNum;
        private System.Windows.Forms.Label rndNumCPU;
        private System.Windows.Forms.Label rndNumUSR;
    }
}

