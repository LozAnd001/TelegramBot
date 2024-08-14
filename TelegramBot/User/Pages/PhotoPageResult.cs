using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace TelegramBot.User.Pages
{
    public class PhotoPageResult : PageResultBase
    {
        public InputFile Photo { get; set; }
        public PhotoPageResult(InputFile photo, string text, IReplyMarkup replyMarkup) : base(text, replyMarkup)
        {
            Photo = photo; 
        }
    }
}