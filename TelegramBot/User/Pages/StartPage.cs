using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;
using TelegramBot.User.Pages.PageResults;

namespace TelegramBot.User.Pages
{
    public class StartPage : IPage
    {


        public PageResultBase View(Update update, UserState userState)
        {
            var text = "Приветственный текс";
            ReplyKeyboardMarkup replyMarkup = GetReplyKeyboard();
            return new PageResultBase(text, replyMarkup)
            {
                UpdateUserState = new UserState(this, userState.UserData)
            };
        }

        

        public PageResultBase Handle(Update update, UserState userState)
        {
            if (update.Message == null)
                return new PageResultBase("Нажмите на кнопки", GetReplyKeyboard());
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
