using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Hubs
{
    public class UserHub : Hub
    {
        private static int _count;

        public async Task Join()
        {
            _count++;
            await Clients.All.SendAsync("Join", _count);
        }

        public async Task Leave()
        {
            _count--;
            await Clients.All.SendAsync("Leave", _count);
        }
    }
}
