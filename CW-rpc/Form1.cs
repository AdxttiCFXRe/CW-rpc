using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DiscordRpcDemo;


namespace CW_rpc
{

    public partial class Form1 : Form
    {

        private DiscordRpc.EventHandlers handlers;
        private DiscordRpc.RichPresence presence;

        public Form1()
        {
            InitializeComponent();
        }

        async Task DetectCWProcess()
        {
            for (;;)
            {
                Process[] processes = Process.GetProcessesByName("CodeWalker");
                if (processes.Length == 0)
                {
                    MessageBox.Show("CodeWalker is not running! Launch it to use CW-rpc without any issues.", "CW-rpc", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }
                else
                {
                    //to-do: Elapsed Time
                    //Stopwatch stopWatch = new Stopwatch();
                    //stopWatch.Start();
                    this.handlers = default(DiscordRpc.EventHandlers);
                    DiscordRpc.Initialize("958026542959697981", ref this.handlers, true, null);
                    this.handlers = default(DiscordRpc.EventHandlers);
                    DiscordRpc.Initialize("958026542959697981", ref this.handlers, true, null);
                    //var ts = stopWatch.Elapsed;
                    //string elapsedTime = $"{ts.Hours}:{ts.Minutes}:{ts.Seconds}.{ts.Milliseconds / 10}";
                    this.presence.details = "CodeWalker by dexyfex";
                    //this.presence.state = "using CW-rpc by AdxttiCFXRe";
                    this.presence.largeImageKey = "cw4";
                    //this.presence.smallImageKey = "image";
                    DiscordRpc.UpdatePresence(ref this.presence);
                }
            }
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            await Task.Run(DetectCWProcess);   
        }

        private void joinDiscordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://discord.gg/37hFAydgAY");
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("CodeWalker/CW is a GTA V 3D Map Editor created by dexyfex.");
        }

        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("CW-rpc is a CodeWalker Discord Rich Presence using msciotti's discord-rpc.");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void launchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(@"CodeWalker.exe");
            }
            catch
            {
                MessageBox.Show("Please place CW-rpc in your CodeWalker directory!", "CW-rpc", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process[] processes = Process.GetProcessesByName("CodeWalker");
            if (processes.Length == 0)
            {
                MessageBox.Show("CodeWalker is not running!", "CW-rpc", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                processes[0].CloseMainWindow();
            }
        }

        private void documentationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/dexyfex/CodeWalker");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
