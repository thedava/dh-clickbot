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
            this.timer1.Interval = 10;
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
                        this.timer1.Stop();
                        break;

                    case "start":
                        this.timer1.Start();
                        break;
                }
            };

            this.hotkey.AddHotKey(Keys.P, HotKey.MODKEY.MOD_CONTROL, "position");
            this.hotkey.AddHotKey(Keys.T, HotKey.MODKEY.MOD_CONTROL, "terminate");
            this.hotkey.AddHotKey(Keys.R, HotKey.MODKEY.MOD_CONTROL, "start");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!(Control.ModifierKeys == Keys.Alt))
            {
                Program.LeftMouseClick(this.currentPosition.X, this.currentPosition.Y);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int x = Int32.Parse(tbxX.Text), y = Int32.Parse(tbxY.Text);
            this.currentPosition = new Point(x, y);
            this.timer1.Start();
        }
    }
}
