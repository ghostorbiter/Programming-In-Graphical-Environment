using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tutorial2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        //private void goButton_Click(object sender, EventArgs e)
        //{
        //    //MessageBox.Show("Hello to you too stranger\nI am " + nameBox.Text);
        //    if (this.ValidateChildren())
        //        MessageBox.Show("Hello to you too stranger\nI am " + nameBox.Text);
        //}

        private void nameBox_TextChanged(object sender, EventArgs e)
        {

        }

        //private void nameBox_Validating(object sender, CancelEventArgs e)
        //{
        //    if(nameBox.Text.Length == 0 || nameBox.Text.Length>6)
        //    {
        //        nameErrorprovider.SetError(nameBox, "Fuck U!");
        //        e.Cancel = true;
        //        return;
        //    }
        //    nameErrorprovider.SetError(nameBox, string.Empty);
        //    e.Cancel = false;
        //}
        private void ExitContextMenu_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            notifyIconContextMenuStrip.Items.Add("Exit", null, ExitContextMenu_Click);
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void splitContainer_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void calendarListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            removeButton.Enabled = calendarListView.SelectedItems.Count > 0;
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            string date = monthCalendar.SelectionStart.ToShortDateString();
            string note = textBox.Text;
            ListViewItem newItem = new ListViewItem(new[] { date, note });
            calendarListView.Items.Add(newItem);
            textBox.Text = "";
            notifyIcon.ShowBalloonTip(1000, "Item Added", "Added New Event", ToolTipIcon.Info);
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in calendarListView.SelectedItems)
                calendarListView.Items.Remove(item);
        }
    }
}
