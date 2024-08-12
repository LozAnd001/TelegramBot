using Telegram.Bot.Types.ReplyMarkups;

namespace TelegramBot.User.Pages
{
    public class PageResult
    {
        public string Text { get; }

        public ReplyMarkupBase ReplyMarkup { get; }

        public UserState UpdateUserState { get; set; }

        public PageResult(string text, ReplyMarkupBase replyMarkup)
        {
            Text = text;
            ReplyMarkup = replyMarkup;
        }
        
    }
}