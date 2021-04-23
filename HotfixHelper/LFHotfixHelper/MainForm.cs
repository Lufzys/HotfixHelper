using HotfixHelper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LFHotfixHelper
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        int currentFile = 0;
        public static string lolPath = string.Empty;
        public static WebClient wc = new WebClient();
        private void MainForm_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default["lolPath"] != string.Empty)
            {
                lolPath = Properties.Settings.Default["lolPath"].ToString();
            }
            else
            {
                MessageBox.Show("Lütfen League of Legends'in kurulu olduğu dizini seçiniz! (Örn : C:/Riot Games/League of Legends)", "Hotfix Helper", MessageBoxButtons.OK, MessageBoxIcon.Information);
                FolderBrowserDialog folderBrowser = new FolderBrowserDialog();
                if (folderBrowser.ShowDialog() == DialogResult.OK)
                {
                    lolPath = folderBrowser.SelectedPath;
                    Properties.Settings.Default["lolPath"] = lolPath;
                    Properties.Settings.Default.Save();
                }
            }

            if (Process.GetProcessesByName("LeagueClient").Length != 0)
            {
                Process.GetProcessesByName("LeagueClient").FirstOrDefault().Kill();
            }
            if (Process.GetProcessesByName("LeagueClientUx").Length != 0)
            {
                Process.GetProcessesByName("LeagueClientUx").FirstOrDefault().Kill();
            }

            rbConsole.WriteLine(Color.Magenta, "[HOTFIX] Github : https://github.com/Lufzys");
            if (CheckHotfix())
            {
                rbConsole.WriteLine(Color.Green, "[HOTFIX] Client starting...");
                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.FileName = lolPath + @"\LeagueClient.exe";
                startInfo.Arguments = "--allow-multiple-clients --legacy-SSL --no-proxy";
                Process.Start(startInfo);
                Environment.Exit(0);
            }
            else
            {
                plBottom.Visible = true;
                Application.DoEvents();
                wc.DownloadProgressChanged += wc_DownloadProgressChanged;
                wc.DownloadFileCompleted += wc_DownloadFileCompleted;
                lblName.Text = "File : LeagueClient.exe";
                wc.DownloadFileAsync(
                    // Param1 = Link of file
                    new System.Uri("https://raw.githubusercontent.com/Lufzys/LOL-Aram-Boost-Exploit/main/folder/LeagueClient.exe"),
                    // Param2 = Path to save
                    lolPath + @"\LeagueClient.exe"
                );
                rbConsole.WriteLine(Color.Green, "[HOTFIX] Downloading phase has been started...");
                rbConsole.WriteLine(Color.Green, "");
                Application.DoEvents();
            }
        }

        public static bool CheckHotfix()
        {
            string hash = MD5Hash.GetMD5HashFromFile(lolPath + @"\LeagueClientUx.exe");
            if (hash == "44F82D6EF65F513CD6539C195264DC7F")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void wc_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            currentFile++;
            if (currentFile == 1)
            {
                lblName.Text = "File : LeagueClientUx.exe";
                wc.DownloadFileAsync(
                        // Param1 = Link of file
                        new System.Uri("https://raw.githubusercontent.com/Lufzys/LOL-Aram-Boost-Exploit/main/folder/LeagueClientUx.exe"),
                        // Param2 = Path to save
                        lolPath + @"\LeagueClientUx.exe");
                rbConsole.WriteLine(Color.Green, "[HOTFIX] LeagueClient.exe has been downloaded.");
            }
            else if (currentFile == 2)
            {
                lblName.Text = "File : assets.wad";
                wc.DownloadFileAsync(
                        // Param1 = Link of file
                        new System.Uri("https://raw.githubusercontent.com/Lufzys/LOL-Aram-Boost-Exploit/main/folder/assets.wad"),
                        // Param2 = Path to save
                        lolPath + @"\Plugins\rcp-fe-lol-champ-select\assets.wad"
                    );
                rbConsole.WriteLine(Color.Green, "[HOTFIX] LeagueClientUx.exe has been downloaded.");
            }
            else if (currentFile == 3)
            {
                lblName.Text = "File : plugin-manifest.json";
                wc.DownloadFileAsync(
                    // Param1 = Link of file
                    new System.Uri("https://raw.githubusercontent.com/Lufzys/LOL-Aram-Boost-Exploit/main/folder/plugin-manifest.json"),
                     // Param2 = Path to save
                     lolPath + @"\Plugins\plugin-manifest.json"
                );
                rbConsole.WriteLine(Color.Green, "[HOTFIX] assets.wad has been downloaded.");
            }
            else if (currentFile == 4)
            {
                rbConsole.WriteLine(Color.Green, "[HOTFIX] plugin-manifest.json has been downloaded.");
                rbConsole.WriteLine(Color.Green, "[HOTFIX] Client starting...");
                lblName.Text = "Patcher : UxClient starting...";
                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.FileName = lolPath + @"\LeagueClient.exe";
                startInfo.Arguments = "--allow-multiple-clients --legacy-SSL --no-proxy";
                Process.Start(startInfo);
                Environment.Exit(0);
            }
        }

        void wc_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            pbProgress.Value = e.ProgressPercentage;
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
