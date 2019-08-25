using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace ArcaneEyeBot.Services
{
    public interface IUpdateService
    {
        Task HandleUpdate(Update update);
    }
}
