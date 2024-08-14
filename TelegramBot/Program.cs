using System;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;
using TelegramBot.Storage;
using TelegramBot.User;
using TelegramBot.User.Pages;
using TelegramBot.User.Pages.PageResults;

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
        Console.WriteLine($"update_id = {update.Id}, current_userState = {userState}");
        var result = userState!.Page.Handle(update, userState);
        Console.WriteLine($"update_id = {update.Id}, send_text = {result.Text}, updated_UserState = {result.UpdateUserState}");

        switch(result)
        {
            case PhotoPageResult photoPageResult:
                await client.SendPhotoAsync(
                    chatId: telegramUserId,
                    photo: photoPageResult.Photo,
                    caption: photoPageResult.Text,
                    replyMarkup: photoPageResult.ReplyMarkup);
                break;
            case VideoPageResult videoPageResult:
                await client.SendVideoAsync(
                    chatId: telegramUserId,
                    video: videoPageResult.Video,
                    caption: videoPageResult.Text,
                    replyMarkup: videoPageResult.ReplyMarkup);
                break;
            default:
                await client.SendTextMessageAsync(
                    chatId: telegramUserId,
                    text: result.Text,
                    replyMarkup: result.ReplyMarkup);
                break;
                    
        }
        storage.AddOrUpdate(telegramUserId, result.UpdateUserState);
    }

    private static async Task HandlePoolingError(ITelegramBotClient client, Exception exception, CancellationToken token)
    {

        Console.WriteLine(exception.Message);
    }
}