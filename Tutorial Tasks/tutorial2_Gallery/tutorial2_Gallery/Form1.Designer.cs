
namespace tutorial2_Gallery
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
            this.galleryLayoutpanel = new System.Windows.Forms.TableLayoutPanel();
            this.imageButton = new System.Windows.Forms.Button();
            this.colorButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.galleryLayoutpanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // galleryLayoutpanel
            // 
            this.galleryLayoutpanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.galleryLayoutpanel.ColumnCount = 2;
            this.galleryLayoutpanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75F));
            this.galleryLayoutpanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.galleryLayoutpanel.Controls.Add(this.imageButton, 1, 0);
            this.galleryLayoutpanel.Controls.Add(this.colorButton, 1, 1);
            this.galleryLayoutpanel.Controls.Add(this.label1, 0, 1);
            this.galleryLayoutpanel.Controls.Add(this.label2, 0, 0);
            this.galleryLayoutpanel.Location = new System.Drawing.Point(12, 12);
            this.galleryLayoutpanel.Name = "galleryLayoutpanel";
            this.galleryLayoutpanel.RowCount = 2;
            this.galleryLayoutpanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.galleryLayoutpanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.galleryLayoutpanel.Size = new System.Drawing.Size(760, 437);
            this.galleryLayoutpanel.TabIndex = 0;
            this.galleryLayoutpanel.Paint += new System.Windows.Forms.PaintEventHandler(this.galleryLayoutpanel_Paint);
            // 
            // imageButton
            // 
            this.imageButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imageButton.Location = new System.Drawing.Point(573, 3);
            this.imageButton.Name = "imageButton";
            this.imageButton.Size = new System.Drawing.Size(184, 212);
            this.imageButton.TabIndex = 0;
            this.imageButton.Text = "Choose Image";
            this.imageButton.UseVisualStyleBackColor = true;
            this.imageButton.Click += new System.EventHandler(this.imageButton_Click);
            // 
            // colorButton
            // 
            this.colorButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.colorButton.Location = new System.Drawing.Point(573, 221);
            this.colorButton.Name = "colorButton";
            this.colorButton.Size = new System.Drawing.Size(184, 213);
            this.colorButton.TabIndex = 1;
            this.colorButton.Text = "Choose Color";
            this.colorButton.UseVisualStyleBackColor = true;
            this.colorButton.Click += new System.EventHandler(this.colorButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 218);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(564, 219);
            this.label1.TabIndex = 2;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(564, 218);
            this.label2.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.galleryLayoutpanel);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.galleryLayoutpanel.ResumeLayout(false);
            this.galleryLayoutpanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel galleryLayoutpanel;
        private System.Windows.Forms.Button imageButton;
        private System.Windows.Forms.Button colorButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

