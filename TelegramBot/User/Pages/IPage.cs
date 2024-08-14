using Telegram.Bot.Types;

namespace TelegramBot.User.Pages
{
    public interface IPage
    {
        PageResultBase View(Update update, UserState userState);

        PageResultBase Handle(Update update, UserState userState);

    }

    
}
