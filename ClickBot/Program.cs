using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;

namespace ClickBot
{
    static class Program
    {
        const int THRESHOLD = 5;

        // This is a replacement for Cursor.Position in WinForms
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool SetCursorPos(int x, int y);

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern void mouse_event(int dwFlags, int dx, int dy, int cButtons, int dwExtraInfo);

        public const int MOUSEEVENTF_LEFTDOWN = 0x02;
        public const int MOUSEEVENTF_LEFTUP = 0x04;

        // This simulates a left mouse click
        public static void LeftMouseClick(int xpos, int ypos)
        {
            Point pt = Cursor.Position;
            int minX = xpos - THRESHOLD,
                maxX = xpos + THRESHOLD,
                minY = ypos - THRESHOLD,
                maxY = ypos + THRESHOLD;

            // Provide some "buffer space" (so that the program doesn't need to reset the mouse on every tick)
            if (minX > pt.X || maxX < pt.X || minY > pt.Y || maxY < pt.Y)
            {
                SetCursorPos(xpos, ypos);
            }

            mouse_event(MOUSEEVENTF_LEFTDOWN, xpos, ypos, 0, 0);
            mouse_event(MOUSEEVENTF_LEFTUP, xpos, ypos, 0, 0);
        }

        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
