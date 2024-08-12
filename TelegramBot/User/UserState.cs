using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.User.Pages;

namespace TelegramBot.User
{
    public record class UserState(IPage Page, UserData UserData);
    
}
