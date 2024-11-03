using Caffeine_for_Windows.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Caffeine_for_Windows
{
    public partial class FormMain : Form
    {
        private bool CaffeineEnabled = false;
        private bool WhiteColor = true;

        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Shown(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.RestoreSleep();
        }

        private void enableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.CaffeineEnabled = true;
            this.enableToolStripMenuItem.Checked = true;
            this.disableToolStripMenuItem.Checked = false;
            this.notifyIconCup.Icon = this.WhiteColor ?
                Resources.white_on : Resources.black_on;
            this.PreventSleep();
        }

        private void disableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.CaffeineEnabled = false;
            this.enableToolStripMenuItem.Checked = false;
            this.disableToolStripMenuItem.Checked = true;
            this.notifyIconCup.Icon = this.WhiteColor ?
                Resources.white_off : Resources.black_off;
            this.RestoreSleep();
        }

        private void whiteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.WhiteColor = true;
            this.whiteToolStripMenuItem.Checked = true;
            this.blackToolStripMenuItem.Checked = false;
            this.notifyIconCup.Icon = this.CaffeineEnabled ? 
                Resources.white_on : Resources.white_off;
        }

        private void blackToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.WhiteColor = false;
            this.whiteToolStripMenuItem.Checked = false;
            this.blackToolStripMenuItem.Checked = true;
            this.notifyIconCup.Icon = this.CaffeineEnabled ?
                Resources.black_on : Resources.black_off;
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/TheRake66/Caffeine-for-Windows");
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void PreventSleep()
        {
            WindowsAPI.SetThreadExecutionState(
                WindowsAPI.ES_CONTINUOUS | 
                WindowsAPI.ES_SYSTEM_REQUIRED | 
                WindowsAPI.ES_DISPLAY_REQUIRED);
        }

        private void RestoreSleep()
        {
            WindowsAPI.SetThreadExecutionState(WindowsAPI.ES_CONTINUOUS);
        }
    }
}
