using System;
using Telegram.Bot;
using Telegram.Bot.Types;


class Program
{
    static async Task Main(string[] args)
    {
        var telegramBotClient = new TelegramBotClient("7443678080:AAE7igiOsuAUUYX4ud0-cTAeZbcIvCyMhEg");
        var user = await telegramBotClient.GetMeAsync();
        telegramBotClient.StartReceiving(updateHandler: HandleUpdate, pollingErrorHandler: HandlePoolingError);
        Console.WriteLine($"Начали слушать апдейты с {user.Username}");
        Console.ReadLine();
    }
    private static async Task HandleUpdate(ITelegramBotClient client, Update update, CancellationToken token)
    {
        if(update.Message?.Text != null)
        {
            var chatId = update.Message.Chat.Id;
            var text = update.Message.Text;
            var messageId = update.Message.MessageId;
            await client.SendTextMessageAsync(chatId: chatId, $"Вы прислали: \n {text}");
            await client.SendTextMessageAsync(
                chatId: chatId, 
                $"Вы прислали: \n {text}",
                replyToMessageId: messageId);
        }
    }
    private static async Task HandlePoolingError(ITelegramBotClient client, Exception exception, CancellationToken token)
    {
        
        Console.WriteLine(exception.Message);
    }

    
}

