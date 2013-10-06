using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ClickBot
{
    public partial class Form1 : Form
    {
        private HotKey hotkey;
        private Point currentPosition;

        public Form1()
        {
            InitializeComponent();
            this.tmrMain.Interval = 10;

            // Checkbox change event
            this.cbxTopMost.CheckedChanged += (sender, e) =>
            {
                this.TopMost = ((CheckBox)sender).Checked;
            };

            // Timer tick event
            this.tmrMain.Tick += (sender, e) =>
            {
                if (!(Control.ModifierKeys == Keys.Alt))
                {
                    Program.LeftMouseClick(this.currentPosition.X, this.currentPosition.Y);
                }
            };
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.hotkey = new HotKey();
            this.hotkey.OwnerForm = this;
            this.hotkey.HotKeyPressed += (string hk) =>
            {
                switch (hk)
                {
                    case "position":
                        this.currentPosition = Cursor.Position;
                        tbxX.Text = this.currentPosition.X.ToString();
                        tbxY.Text = this.currentPosition.Y.ToString();
                        break;

                    case "terminate":
                        this.tmrMain.Stop();
                        break;

                    case "start":
                        this.tmrMain.Start();
                        break;
                }
            };

            this.hotkey.AddHotKey(Keys.P, HotKey.MODKEY.MOD_CONTROL, "position");
            this.hotkey.AddHotKey(Keys.T, HotKey.MODKEY.MOD_CONTROL, "terminate"); // or "stop"
            this.hotkey.AddHotKey(Keys.R, HotKey.MODKEY.MOD_CONTROL, "start"); // or "run"
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int x = Int32.Parse(tbxX.Text), y = Int32.Parse(tbxY.Text);
            this.currentPosition = new Point(x, y);
            this.tmrMain.Start();
        }
    }
}
