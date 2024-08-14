using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;
using TelegramBot.User.Pages.PageResults;

namespace TelegramBot.User.Pages
{
    public class MozgokachalkaPage : IPage
    {
        public PageResultBase View(Update update, UserState userState)
        {
            var text = "Чтобы научиться программировать нужно программировать";
            var replyMarkup = GetReplyMarkup();
            var photoUrl = "https://disk.yandex.ru/i/h1R4Yq-q3-3xSw";
            return new PhotoPageResult(InputFile.FromUri(photoUrl), text, replyMarkup)
            {
                UpdateUserState = new UserState(this , userState.UserData)
            };
        }

        public PageResultBase Handle(Update update, UserState userState)
        {
            throw new NotImplementedException();
        }

        private ReplyMarkupBase GetReplyMarkup()
        {
            return new ReplyKeyboardMarkup(
                [
                    [
                        new KeyboardButton("ПОДРОБНЕЕ"),
                        new KeyboardButton("СМОТРЕТЬ ЭФИР")
                    ],
                    [
                        new KeyboardButton("ВСТУПИТЬ")
                    ],
                    [
                        new KeyboardButton("НАЗАД")
                    ]
                ])
            {
                ResizeKeyboard = true
            };
        }


    }
}
