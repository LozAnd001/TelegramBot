using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types;
using TelegramBot.User.Pages.PageResults;

namespace TelegramBot.User.Pages
{
    public class NotStatePage : IPage
    {
        public PageResultBase Handle(Update update, UserState userState)
        {
            return new StartPage().View(update, userState);
        }

        public PageResultBase View(Update update, UserState userState)
        {
            return null;
        }
    }
}
