using System;
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
            var chatId = update.Message.Chat.Id;
            if (data[0] == "/buttons" && data.Length == 3)
            {
                var n = int.Parse(data[1]);
                var m = int.Parse(data[2]);
                var buttons = GetReplyButtons(n, m);
                var text = update.Message.Text;
                var messageId = update.Message.MessageId;
                await client.SendTextMessageAsync(
                    chatId: chatId,
                    text: text,
                    replyMarkup: new ReplyKeyboardMarkup(buttons)
                    {
                        ResizeKeyboard = true,

                    }
                    );
            }
            else if (data[0] == "/inline_buttons" && data.Length == 3)
            {
                var n = int.Parse(data[1]);
                var m = int.Parse(data[2]);
                var buttons = GetInlineButtons(n, m);
                var text = update.Message.Text;
                var messageId = update.Message.MessageId;
                await client.SendTextMessageAsync(
                    chatId: chatId,
                    text: text,
                    replyMarkup: new InlineKeyboardMarkup(buttons)
                    
                    );
            }
            else if (data[0] == "/photo")
            {
                if(data.Length == 2)
                {
                    var url = data[1];
                    await client.SendPhotoAsync(
                        chatId: chatId,
                        photo: InputFile.FromUri(url),
                        caption: "Вот ваша фотка"

                        );
                }
                else
                {
                    var imagesNames = new string[]
                    {
                        "im1.jpg",
                        "im2.jpg",
                        "im3.jpg",
                        "im4.jpg",
                    };
                    var random = new Random();
                    var imageIndex = random.Next(imagesNames.Length);
                    using (var file = new FileStream($@"images\{imagesNames[imageIndex]}", FileMode.Open, FileAccess.Read) )
                        await client.SendPhotoAsync(
                            chatId: chatId,
                            photo: InputFile.FromStream(file),
                            caption: imagesNames[imageIndex]

                            );

                }
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

    private static List<List<InlineKeyboardButton>> GetInlineButtons(int n, int m)
    {
        var buttons = new List<List<InlineKeyboardButton>>();
        var number = 1;
        for (int i = 0; i < n; ++i)
        {
            var row = new List<InlineKeyboardButton>();
            for (int j = 0; j < m; ++j)
            {
                row.Add(new InlineKeyboardButton(number.ToString())
                {
                    CallbackData = number.ToString()
                });
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