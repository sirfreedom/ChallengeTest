using System;
using System.Collections.Generic;

namespace WinFormDisegnPattern.LoadBalancer
{
    public class LoadBalancerPattern
    {

        // Static members are 'eagerly initialized', that is, 
        // immediately when class is loaded for the first time.
        // .NET guarantees thread safety for static initialization
        private static readonly LoadBalancerPattern instance = new LoadBalancerPattern();
        private readonly List<Server> servers;
        private readonly Random random = new Random();



        // Note: constructor is 'private'
        private LoadBalancerPattern()
        {
            // Load list of available servers
            servers = new List<Server>
                {
                  new Server{ Name = "ServerI", IP = "120.14.220.18" },
                  new Server{ Name = "ServerII", IP = "120.14.220.19" },
                  new Server{ Name = "ServerIII", IP = "120.14.220.20" },
                  new Server{ Name = "ServerIV", IP = "120.14.220.21" },
                  new Server{ Name = "ServerV", IP = "120.14.220.22" },
                };
        }


        public static LoadBalancerPattern GetLoadBalancer()
        {
            return instance;
        }

        // Simple, but effective load balancer
        public Server NextServer
        {
            get
            {
                int r = random.Next(servers.Count);
                return servers[r];
            }
        }


    }
}
