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
    public partial class MainForm : Form
    {
        private HotKey hotkey;
        private Point currentPosition;

        public MainForm()
        {
            InitializeComponent();

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
                    try
                    {
                        Program.LeftMouseClick(this.currentPosition.X, this.currentPosition.Y);
                    }
                    catch
                    {
                        ((Timer)sender).Stop();
                        MessageBox.Show("Something went wrong! Please check your positions and try it again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
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

        private void btnStart_Click(object sender, EventArgs e)
        {
            int x = 0, y = 0;
            bool _x = Int32.TryParse(tbxX.Text, out x), _y = Int32.TryParse(tbxY.Text, out y);

            if (_x && _y)
            {
                this.currentPosition = new Point(x, y);
                this.tmrMain.Start();
            }
            else
            {
                MessageBox.Show("One or both positions are invalid!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
