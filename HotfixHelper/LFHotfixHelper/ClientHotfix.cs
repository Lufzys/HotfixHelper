using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace HotfixHelper
{
    public class ClientHotfix
    {
        public static bool OnDownloading = false;
        public static int CurrentFileIndex = 0;
        public static int DownloadPercentage = 0;
        public static string LOLPath = @"C:\Riot Games\League of Legends"; // Default LOL Path
        private static WebClient wc = new WebClient();
        public static HotfixResult Hotfix()
        {
            try
            {
                if (CheckHotfix())
                {
                    return HotfixResult.AlreadyHotfix;
                }
                else
                {
                    #region Kill All Clients
                    if (Process.GetProcessesByName("LeagueClient").Length != 0)
                    {
                        Process.GetProcessesByName("LeagueClient").FirstOrDefault().Kill();
                    }
                    if (Process.GetProcessesByName("LeagueClientUx").Length != 0)
                    {
                        Process.GetProcessesByName("LeagueClientUx").FirstOrDefault().Kill();
                    }
                    #endregion

                    wc.DownloadProgressChanged += wc_DownloadProgressChanged;
                    wc.DownloadFileCompleted += wc_DownloadFileCompleted;
                    wc.DownloadFileAsync(
                        // Param1 = Link of file
                        new System.Uri("https://raw.githubusercontent.com/Lufzys/LOL-Aram-Boost-Exploit/main/folder/LeagueClient.exe"),
                       // Param2 = Path to save
                       LOLPath + @"\LeagueClient.exe"
                    );
                    return HotfixResult.Succesfully;
                }
            }
            catch { return HotfixResult.Error; }
        }

        private static void wc_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            CurrentFileIndex++;
            if (CurrentFileIndex == 1)
            {
                wc.DownloadFileAsync(
                        // Param1 = Link of file
                        new System.Uri("https://raw.githubusercontent.com/Lufzys/LOL-Aram-Boost-Exploit/main/folder/LeagueClientUx.exe"),
                        // Param2 = Path to save
                        LOLPath + @"\LeagueClientUx.exe");
            }
            else if (CurrentFileIndex == 2)
            {
                wc.DownloadFileAsync(
                        // Param1 = Link of file
                        new System.Uri("https://raw.githubusercontent.com/Lufzys/LOL-Aram-Boost-Exploit/main/folder/assets.wad"),
                        // Param2 = Path to save
                        LOLPath + @"\Plugins\rcp-fe-lol-champ-select\assets.wad"
                    );
            }
            else if (CurrentFileIndex == 3)
            {
                wc.DownloadFileAsync(
                    // Param1 = Link of file
                    new System.Uri("https://raw.githubusercontent.com/Lufzys/LOL-Aram-Boost-Exploit/main/folder/plugin-manifest.json"),
                     // Param2 = Path to save
                     LOLPath + @"\Plugins\plugin-manifest.json"
                );
            }
            else if (CurrentFileIndex == 4) // START
            {
                OnDownloading = false;
                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.FileName = LOLPath + @"\LeagueClient.exe";
                startInfo.Arguments = "--allow-multiple-clients --legacy-SSL --no-proxy";
                Process.Start(startInfo);
                CurrentFileIndex = 0;
            }
        }

        private static void wc_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            OnDownloading = true;
            DownloadPercentage = e.ProgressPercentage;
        }

        public static bool StartHotfixClient()
        {
            if (CheckHotfix())
            {
                #region Kill All Clients
                if (Process.GetProcessesByName("LeagueClient").Length != 0)
                {
                    Process.GetProcessesByName("LeagueClient").FirstOrDefault().Kill();
                }
                if (Process.GetProcessesByName("LeagueClientUx").Length != 0)
                {
                    Process.GetProcessesByName("LeagueClientUx").FirstOrDefault().Kill();
                }
                #endregion
                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.FileName = LOLPath + @"\LeagueClient.exe";
                startInfo.Arguments = "--allow-multiple-clients --legacy-SSL --no-proxy";
                Process.Start(startInfo);
                CurrentFileIndex = 0;
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool CheckHotfix()
        {
            string hash = MD5Hash.GetMD5HashFromFile(@"C:\Riot Games\League of Legends\LeagueClientUx.exe");
            if (hash == "44F82D6EF65F513CD6539C195264DC7F")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public enum HotfixResult
        {
            AlreadyHotfix,
            Succesfully,
            Error
        }
    }
}
