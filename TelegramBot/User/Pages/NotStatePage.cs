using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace TelegramBot.User.Pages
{
    public class NotStatePage : IPage
    {
        public PageResult Handle(Update update, UserState userState)
        {
            return new StartPage().View(update, userState);
        }

        public PageResult View(Update update, UserState userState)
        {
            return null;
        }
    }
}
