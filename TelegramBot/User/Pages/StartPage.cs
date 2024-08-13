using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace TelegramBot.User.Pages
{
    public class StartPage : IPage
    {


        public PageResult View(Update update, UserState userState)
        {
            var text = "Приветственный текс";
            ReplyKeyboardMarkup replyMarkup = GetReplyKeyboard();
            return new PageResult(text, replyMarkup)
            {
                UpdateUserState = new UserState(this, userState.UserData)
            };
        }

        

        public PageResult Handle(Update update, UserState userState)
        {
            if (update.Message == null)
                return new PageResult("Нажмите на кнопки", GetReplyKeyboard());
            if(update.Message.Text == "МОЗГОКАЧАЛКА")
            {
                return new MozgokachalkaPage().View(update, userState);
            }
            if (update.Message.Text == "ВОЙТИ В IT")
            {
                return new EnterToITPage().View(update, userState);
            }
            return null;
        }

        private static ReplyKeyboardMarkup GetReplyKeyboard()
        {
            return new ReplyKeyboardMarkup(
                [
                    [
                        new KeyboardButton("МОЗГОКАЧАЛКА")
                    ],
                    [
                        new KeyboardButton("ВОЙТИ В IT")
                    ]
                ])
            {
                ResizeKeyboard = true
            };
        }


    }
}
