using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace TelegramBot.User.Pages.PageResults
{
    public class DocumentPageResult : PageResultBase
    {
        public InputFile Document { get; set; }
        public DocumentPageResult(InputFile document, string text, IReplyMarkup replyMarkup) : base(text, replyMarkup)
        {
            Document = document;
        }
    }
}