using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

class Program
{
    static async Task Main(string[] args)
    {
        var telegramBotClient = new TelegramBotClient("7325936984:AAHkxwlIXZ9v6qJP0CbRgF4KNRp2CBYRubg");
        var user = await telegramBotClient.GetMeAsync();
        Console.WriteLine($"Начали слушать апдейты с {user.Username}");
        telegramBotClient.StartReceiving(updateHandler: HandleUpdate, pollingErrorHandler: HandlePoolingError);
        Console.ReadLine();
    }

    private static async Task HandleUpdate(ITelegramBotClient client, Update update, CancellationToken token)
    {
        if (update.Message?.Text != null)
        {
            var data = update.Message.Text.Split();
            if (data[0] == "/buttons" && data.Length == 3)
            {
                var n = int.Parse(data[1]);
                var m = int.Parse(data[2]);
                var buttons = GetReplyButtons(n, m);
                var charId = update.Message.Chat.Id;
                var text = update.Message.Text;
                var messageId = update.Message.MessageId;
                await client.SendTextMessageAsync(
                    chatId: charId,
                    text: text,
                    replyMarkup: new ReplyKeyboardMarkup(buttons)
                    {
                        ResizeKeyboard = true,

                    }
                    );
            }
            
        }
    }

    private static List<List<KeyboardButton>> GetReplyButtons(int n, int m)
    {
        var buttons = new List<List<KeyboardButton>>();
        var number = 1;
        for (int i = 0; i < n; ++i)
        {
            var row = new List<KeyboardButton>();
            for (int j = 0; j < m; ++j)
            {
                row.Add(new KeyboardButton(number.ToString()));
                number++;
            }
            buttons.Add(row);
        }
        return buttons;
    }

    private static async Task HandlePoolingError(ITelegramBotClient client, Exception exception, CancellationToken token)
    {

        Console.WriteLine(exception.Message);
    }
}