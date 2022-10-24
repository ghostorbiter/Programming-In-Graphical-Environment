
namespace prepLab2
{
    partial class newGameForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.userName = new System.Windows.Forms.Label();
            this.cpuName = new System.Windows.Forms.Label();
            this.rounds = new System.Windows.Forms.Label();
            this.newGameButton = new System.Windows.Forms.Button();
            this.userNameERR = new System.Windows.Forms.ErrorProvider(this.components);
            this.cpuNameERR = new System.Windows.Forms.ErrorProvider(this.components);
            this.roundsERR = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.userNameERR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cpuNameERR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.roundsERR)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 27);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(138, 23);
            this.textBox1.TabIndex = 0;
            this.textBox1.Validating += new System.ComponentModel.CancelEventHandler(this.textBox1_Validating);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(12, 91);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(138, 23);
            this.textBox2.TabIndex = 1;
            this.textBox2.Validating += new System.ComponentModel.CancelEventHandler(this.textBox2_Validating);
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(12, 153);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(138, 23);
            this.textBox3.TabIndex = 2;
            this.textBox3.Validating += new System.ComponentModel.CancelEventHandler(this.textBox3_Validating);
            // 
            // userName
            // 
            this.userName.AutoSize = true;
            this.userName.Location = new System.Drawing.Point(12, 6);
            this.userName.Name = "userName";
            this.userName.Size = new System.Drawing.Size(71, 15);
            this.userName.TabIndex = 3;
            this.userName.Text = "USER NAME";
            this.userName.Click += new System.EventHandler(this.label1_Click);
            // 
            // cpuName
            // 
            this.cpuName.AutoSize = true;
            this.cpuName.Location = new System.Drawing.Point(12, 73);
            this.cpuName.Name = "cpuName";
            this.cpuName.Size = new System.Drawing.Size(67, 15);
            this.cpuName.TabIndex = 4;
            this.cpuName.Text = "CPU NAME";
            // 
            // rounds
            // 
            this.rounds.AutoSize = true;
            this.rounds.Location = new System.Drawing.Point(12, 135);
            this.rounds.Name = "rounds";
            this.rounds.Size = new System.Drawing.Size(123, 15);
            this.rounds.TabIndex = 5;
            this.rounds.Text = "NUMBER OF ROUNDS";
            // 
            // newGameButton
            // 
            this.newGameButton.Location = new System.Drawing.Point(50, 200);
            this.newGameButton.Name = "newGameButton";
            this.newGameButton.Size = new System.Drawing.Size(100, 25);
            this.newGameButton.TabIndex = 6;
            this.newGameButton.Text = "OK";
            this.newGameButton.UseVisualStyleBackColor = true;
            this.newGameButton.Click += new System.EventHandler(this.newGameButton_Click);
            // 
            // userNameERR
            // 
            this.userNameERR.ContainerControl = this;
            // 
            // cpuNameERR
            // 
            this.cpuNameERR.ContainerControl = this;
            // 
            // roundsERR
            // 
            this.roundsERR.ContainerControl = this;
            // 
            // newGameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.ClientSize = new System.Drawing.Size(184, 241);
            this.Controls.Add(this.newGameButton);
            this.Controls.Add(this.rounds);
            this.Controls.Add(this.cpuName);
            this.Controls.Add(this.userName);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "newGameForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "newGameForm";
            ((System.ComponentModel.ISupportInitialize)(this.userNameERR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cpuNameERR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.roundsERR)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label userName;
        private System.Windows.Forms.Label cpuName;
        private System.Windows.Forms.Label rounds;
        private System.Windows.Forms.Button newGameButton;
        private System.Windows.Forms.ErrorProvider userNameERR;
        private System.Windows.Forms.ErrorProvider cpuNameERR;
        private System.Windows.Forms.ErrorProvider roundsERR;
    }
}