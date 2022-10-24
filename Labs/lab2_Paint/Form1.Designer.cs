
namespace lab2prepPaint
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.brushTool = new System.Windows.Forms.ToolStripButton();
            this.square = new System.Windows.Forms.ToolStripButton();
            this.ellipse = new System.Windows.Forms.ToolStripButton();
            this.trash = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.fileLabel = new System.Windows.Forms.ToolStripLabel();
            this.save = new System.Windows.Forms.ToolStripButton();
            this.load = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.thickness = new System.Windows.Forms.ToolStripLabel();
            this.thicknessComboBox = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.choosenColor = new System.Windows.Forms.ToolStripLabel();
            this.toolStripButton6 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.language = new System.Windows.Forms.ToolStripLabel();
            this.english = new System.Windows.Forms.ToolStripButton();
            this.polish = new System.Windows.Forms.ToolStripButton();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.colorBox = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.drawArea = new System.Windows.Forms.PictureBox();
            this.toolStrip1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.colorBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.drawArea)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            resources.ApplyResources(this.toolStrip1, "toolStrip1");
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.brushTool,
            this.square,
            this.ellipse,
            this.trash,
            this.toolStripSeparator1,
            this.fileLabel,
            this.save,
            this.load,
            this.toolStripSeparator2,
            this.thickness,
            this.thicknessComboBox,
            this.toolStripSeparator3,
            this.choosenColor,
            this.toolStripButton6,
            this.toolStripSeparator4,
            this.language,
            this.english,
            this.polish});
            this.toolStrip1.Name = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            resources.ApplyResources(this.toolStripLabel1, "toolStripLabel1");
            this.toolStripLabel1.Name = "toolStripLabel1";
            // 
            // brushTool
            // 
            resources.ApplyResources(this.brushTool, "brushTool");
            this.brushTool.CheckOnClick = true;
            this.brushTool.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.brushTool.Name = "brushTool";
            this.brushTool.Click += new System.EventHandler(this.brushTool_Click_1);
            // 
            // square
            // 
            resources.ApplyResources(this.square, "square");
            this.square.CheckOnClick = true;
            this.square.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.square.Name = "square";
            this.square.Click += new System.EventHandler(this.square_Click);
            // 
            // ellipse
            // 
            resources.ApplyResources(this.ellipse, "ellipse");
            this.ellipse.CheckOnClick = true;
            this.ellipse.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ellipse.Name = "ellipse";
            this.ellipse.Click += new System.EventHandler(this.ellipse_Click);
            // 
            // trash
            // 
            resources.ApplyResources(this.trash, "trash");
            this.trash.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.trash.Name = "trash";
            this.trash.Click += new System.EventHandler(this.trash_Click);
            // 
            // toolStripSeparator1
            // 
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            // 
            // fileLabel
            // 
            resources.ApplyResources(this.fileLabel, "fileLabel");
            this.fileLabel.Name = "fileLabel";
            this.fileLabel.Click += new System.EventHandler(this.toolStripLabel2_Click);
            // 
            // save
            // 
            resources.ApplyResources(this.save, "save");
            this.save.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.save.Name = "save";
            this.save.Click += new System.EventHandler(this.save_Click);
            // 
            // load
            // 
            resources.ApplyResources(this.load, "load");
            this.load.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.load.Name = "load";
            this.load.Click += new System.EventHandler(this.load_Click);
            // 
            // toolStripSeparator2
            // 
            resources.ApplyResources(this.toolStripSeparator2, "toolStripSeparator2");
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            // 
            // thickness
            // 
            resources.ApplyResources(this.thickness, "thickness");
            this.thickness.Name = "thickness";
            // 
            // thicknessComboBox
            // 
            resources.ApplyResources(this.thicknessComboBox, "thicknessComboBox");
            this.thicknessComboBox.Name = "thicknessComboBox";
            this.thicknessComboBox.Click += new System.EventHandler(this.toolStripComboBox1_Click);
            // 
            // toolStripSeparator3
            // 
            resources.ApplyResources(this.toolStripSeparator3, "toolStripSeparator3");
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            // 
            // choosenColor
            // 
            resources.ApplyResources(this.choosenColor, "choosenColor");
            this.choosenColor.Name = "choosenColor";
            // 
            // toolStripButton6
            // 
            resources.ApplyResources(this.toolStripButton6, "toolStripButton6");
            this.toolStripButton6.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton6.ForeColor = System.Drawing.Color.Transparent;
            this.toolStripButton6.Name = "toolStripButton6";
            this.toolStripButton6.Paint += new System.Windows.Forms.PaintEventHandler(this.toolStripButton6_Paint);
            // 
            // toolStripSeparator4
            // 
            resources.ApplyResources(this.toolStripSeparator4, "toolStripSeparator4");
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            // 
            // language
            // 
            resources.ApplyResources(this.language, "language");
            this.language.Name = "language";
            // 
            // english
            // 
            resources.ApplyResources(this.english, "english");
            this.english.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.english.Name = "english";
            this.english.Click += new System.EventHandler(this.english_Click);
            // 
            // polish
            // 
            resources.ApplyResources(this.polish, "polish");
            this.polish.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.polish.Name = "polish";
            this.polish.Click += new System.EventHandler(this.polish_Click);
            // 
            // tableLayoutPanel1
            // 
            resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
            this.tableLayoutPanel1.BackColor = System.Drawing.SystemColors.Control;
            this.tableLayoutPanel1.Controls.Add(this.colorBox, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.drawArea, 0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            // 
            // colorBox
            // 
            resources.ApplyResources(this.colorBox, "colorBox");
            this.colorBox.BackColor = System.Drawing.SystemColors.Control;
            this.colorBox.Controls.Add(this.flowLayoutPanel);
            this.colorBox.Name = "colorBox";
            this.colorBox.TabStop = false;
            // 
            // flowLayoutPanel
            // 
            resources.ApplyResources(this.flowLayoutPanel, "flowLayoutPanel");
            this.flowLayoutPanel.Name = "flowLayoutPanel";
            // 
            // drawArea
            // 
            resources.ApplyResources(this.drawArea, "drawArea");
            this.drawArea.BackColor = System.Drawing.Color.White;
            this.drawArea.Name = "drawArea";
            this.drawArea.TabStop = false;
            this.drawArea.MouseDown += new System.Windows.Forms.MouseEventHandler(this.drawArea_MouseDown_1);
            this.drawArea.MouseMove += new System.Windows.Forms.MouseEventHandler(this.drawArea_MouseMove_1);
            this.drawArea.MouseUp += new System.Windows.Forms.MouseEventHandler(this.drawArea_MouseUp_1);
            this.drawArea.Resize += new System.EventHandler(this.drawArea_Resize);
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResizeEnd += new System.EventHandler(this.Form1_ResizeEnd);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.colorBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.drawArea)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripButton brushTool;
        private System.Windows.Forms.GroupBox colorBox;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel;
        private System.Windows.Forms.PictureBox drawArea;
        private System.Windows.Forms.ToolStripButton square;
        private System.Windows.Forms.ToolStripButton ellipse;
        private System.Windows.Forms.ToolStripButton trash;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel fileLabel;
        private System.Windows.Forms.ToolStripButton save;
        private System.Windows.Forms.ToolStripButton load;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripLabel thickness;
        private System.Windows.Forms.ToolStripComboBox thicknessComboBox;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripLabel choosenColor;
        private System.Windows.Forms.ToolStripButton toolStripButton6;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripLabel language;
        private System.Windows.Forms.ToolStripButton english;
        private System.Windows.Forms.ToolStripButton polish;
    }
}

