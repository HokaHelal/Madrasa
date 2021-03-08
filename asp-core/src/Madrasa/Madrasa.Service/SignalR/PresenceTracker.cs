using Madrasa.Dto.Classroom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Madrasa.Service.SignalR
{
    public class PresenceTracker
    {
        private static readonly List<UserClass> _onlineUsers = new List<UserClass>();

        public Task<bool> UserConnected(UserClass user)
        {
            bool isOnline = false;
            lock (_onlineUsers)
            {
                _onlineUsers.Add(user);
                isOnline = true;               
            }

            return Task.FromResult(isOnline);
        }

        public Task<bool> UserDisconnected(string username, string connectionId)
        {
            bool isOffline = false;
            lock (_onlineUsers)
            {
                if (!_onlineUsers.Exists(x=> x.username == username)) return Task.FromResult(isOffline);

               var sameConnectioIdUsers = _onlineUsers.FindAll(x => x.username == username 
                                           && x.connectionId == connectionId);

                foreach (var sameConnectionIdUser in sameConnectioIdUsers)
                {
                    _onlineUsers.Remove(sameConnectionIdUser);
                }

                if (!_onlineUsers.Exists(x => x.username == username))
                {
                    isOffline = true;
                }
            }

            return Task.FromResult(isOffline);
        }

        public Task<UserClass[]> GetOnlineUsers()
        {
            UserClass[] onlineUser;
            lock (_onlineUsers)
            {
                onlineUser = _onlineUsers.OrderBy(k => k.username).ToArray();
            }

            return Task.FromResult(onlineUser);
        }      
    }
}
