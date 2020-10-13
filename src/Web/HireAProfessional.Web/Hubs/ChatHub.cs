namespace HireAProfessional.Hubs
{
    using System.Threading.Tasks;

    using HireAProfessional.Web.ViewModels.Chat;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.SignalR;

    [Authorize]
    public class ChatHub : Hub
    {
        public async Task Send(string message)
        {
            await this.Clients.All.SendAsync(
                "NewMessage",
                new Message { UserName = this.Context.User.Identity.Name, Content = message, });
        }
    }
}
