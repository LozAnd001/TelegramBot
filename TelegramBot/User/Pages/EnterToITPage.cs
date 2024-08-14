using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace TelegramBot.User.Pages
{
    public class EnterToITPage : IPage
    {
        public PageResultBase View(Update update, UserState userState)
        {
            var text = "Войти в IT";
            var photoUrl = "https://disk.yandex.ru/i/h1R4Yq-q3-3xSw";
            var markup = GetMarkup();
            return new PhotoPageResult(InputFile.FromUri(photoUrl), text, markup)
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
