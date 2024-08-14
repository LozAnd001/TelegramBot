using Telegram.Bot.Types.ReplyMarkups;

namespace TelegramBot.User.Pages
{
    public class PageResultBase
    {
        public string Text { get; }

        public IReplyMarkup ReplyMarkup { get; }

        public UserState UpdateUserState { get; set; }

        public PageResultBase(string text, IReplyMarkup replyMarkup)
        {
            Text = text;
            ReplyMarkup = replyMarkup;
        }
        
    }
}