using System;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;
using TelegramBot.Storage;
using TelegramBot.User;
using TelegramBot.User.Pages;

class Program
{
    static UserStateStorage storage = new UserStateStorage();
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
        if (update.Message?.Text == null)
        {
            return;
        }
        var telegramUserId = update.Message.From.Id;
        Console.WriteLine($"update_id = {update.Id}, telegramUserId = {telegramUserId}");
        var isExistUserState = storage.TryGet(telegramUserId, out var userState);
        if(!isExistUserState)
        {
            userState = new UserState(new NotStatePage(), new UserData()); 
        }
        Console.WriteLine($"update_id = {update.Id}, telegramUserId = {userState}");
        var result = userState!.Page.View(update, userState);

        var data = update.Message.Text.Split();
        var chatId = update.Message.Chat.Id;

        await client.SendTextMessageAsync(
            chatId: telegramUserId,
            text: result.Text,
            replyMarkup: result.ReplyMarkup);
        storage.AddOrUpdate(telegramUserId, result.UpdateUserState);
            
        
            
        
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