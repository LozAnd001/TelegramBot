using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace TelegramBot.User.Pages
{
    public interface IPage
    {
        PageResult View(Update update, UserState userState)

    }

    
}
