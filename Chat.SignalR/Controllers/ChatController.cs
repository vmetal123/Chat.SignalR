using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chat.SignalR.Hubs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace Chat.SignalR.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatController : ControllerBase
    {
        private readonly IHubContext<ChatHub> hubContext;
        public ChatController(IHubContext<ChatHub> hubContext)
        {
            this.hubContext = hubContext;
        }
        
        public void SendMessage(string user, string message)
        {
            hubContext.Clients.All.SendAsync("ReceivedMessage", user, message);
        }
    }
}