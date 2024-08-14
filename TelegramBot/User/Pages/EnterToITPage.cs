using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;
using TelegramBot.User.Pages.PageResults;

namespace TelegramBot.User.Pages
{
    public class EnterToITPage : IPage
    {
        public PageResultBase View(Update update, UserState userState)
        {
            var text = "Войти в IT";
            var photoUrl = "https://disk.yandex.ru/i/h1R4Yq-q3-3xSw";
            var videoUrl = "https://disk.yandex.ru/i/F877ybYOjn5Xjw";
            var markup = GetMarkup();
            return new VideoPageResult(InputFile.FromUri(videoUrl), text, markup)
            {
                UpdateUserState = new UserState(this, userState.UserData) 
            };
        }

        private IReplyMarkup GetMarkup()
        {
            return new InlineKeyboardMarkup(
                [
                    [
                        InlineKeyboardButton.WithUrl("ПОДРОБНЕЕ", "https://disk.yandex.ru/i/h1R4Yq-q3-3xSw")
                    ]
                ]
                );
        }

        public PageResultBase Handle(Update update, UserState userState)
        {
            throw new NotImplementedException();
        }


    }
}
