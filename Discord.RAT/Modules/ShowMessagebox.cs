using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Discord.RAT.Modules
{
    public class ShowMessagebox : ModuleBase
    {
        [Command("messagebox")]
        public async Task SendMsgBox([Remainder] string text)
        {

            await ReplyAsync("Sent!");
            try
            {
                MessageBox.Show(text);
            }
            catch (Exception ex)
            {
                await ReplyAsync("Couldnt send message, reason: " + ex.Message);
            }
            await ReplyAsync("MessageBox read.");

        }
    }
}
