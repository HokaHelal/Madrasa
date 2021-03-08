using Madrasa.Dto.Classroom;
using Madrasa.Models;
using Madrasa.Service.Extenstions;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Madrasa.Service.SignalR
{
    public class PeerData
    {
        public string ConnectionId  { get; set; }
        public object Stream { get; set; }
    }

    public class ClassroomHub : Hub
    {
        private readonly PresenceTracker _presenceTracker;

        public ClassroomHub(PresenceTracker presenceTracker)
        {
            _presenceTracker = presenceTracker;
        }
        public async Task NewUser(UserClass user)
        {
            user.connectionId = Context.ConnectionId;
            var isOnline = await _presenceTracker.UserConnected(user);
            
            if (isOnline)
                await Clients.Others.SendAsync("NewUserArrived", user);

            var currentUsers = await _presenceTracker.GetOnlineUsers();
            await Clients.Caller.SendAsync("GetOnlineUsers", currentUsers);
            await Clients.Caller.SendAsync("GetMyConnectionId", Context.ConnectionId);
        }

        public async Task Stream(PeerData peerData)
        {
            await Clients.Others.SendAsync("Stream", peerData);
        }

        public async Task HelloUser(string userName, string user)
        {
            var userInfo = new UserInfo() { userName = userName, connectionId = Context.ConnectionId };
            await Clients.Client(user).SendAsync("UserSaidHello", JsonSerializer.Serialize(userInfo));
        }

        public async Task SendSignal(string signal, string user)
        {
            await Clients.Client(user).SendAsync("SendSignal", Context.ConnectionId, signal);
        }

        public override async Task OnDisconnectedAsync(System.Exception exception)
        {
            var isOffline = await _presenceTracker.UserDisconnected(Context.User.GetUserName(), Context.ConnectionId);

            //if (isOffline)
                await Clients.Others.SendAsync("UserDisconnect", Context.User.GetUserName(), Context.ConnectionId);

            var currentUsers = await _presenceTracker.GetOnlineUsers();
            await Clients.Others.SendAsync("GetOnlineUsers", currentUsers);

            await base.OnDisconnectedAsync(exception);
        }

    }
}
