﻿using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace TelegramBot.User.Pages
{
    public class MozgokachalkaPage : IPage
    {
        public PageResult View(Update update, UserState userState)
        {
            var text = "Чтобы научиться программировать нужно программировать";
            var replyMarkup = GetReplyMarkup();
            return new PageResult(text, replyMarkup)
            {
                UpdateUserState = new UserState(this , userState.UserData)
            };
        }

        public PageResult Handle(Update update, UserState userState)
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
