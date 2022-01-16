using Discord.Commands;
using Discord.WebSocket;
using System.Reflection;
using System.Threading.Tasks;

namespace Project
{
    public class CommandHandler
    {
        private CommandService Commands { get; set; }

        private DiscordSocketClient Client { get; set; }

        public async Task Init(DiscordSocketClient client)
        {
            Client = client;
            Commands = new CommandService();

            await Commands.AddModulesAsync(Assembly.GetEntryAssembly(), null);
            Client.MessageReceived += HandleCommand;
        }

        private async Task HandleCommand(SocketMessage Msg)
        {
            var msg = Msg as SocketUserMessage;
            var message = new CommandContext(Client, msg);
            if (msg == null)
            {
                await message.Channel.SendMessageAsync("Message is null.");
            }

            int argPos = 0;
            if (!(msg.HasStringPrefix("!", ref argPos) || msg.HasMentionPrefix(Client.CurrentUser, ref argPos)))
            {
                return;
            }

            var context = new CommandContext(Client, msg);

            var result = Commands.ExecuteAsync(context, argPos, null);

            if (result.IsFaulted)
            {
                await context.Channel.SendMessageAsync("Failed to execute command.");
            }
        }
    }
}
