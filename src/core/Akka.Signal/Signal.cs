﻿using System.Net;
using Akka.Actor;

namespace Akka.Signal
{
    public class Signal
    {
        public class Connected
        {
        }

        public class Reconnected
        {
        }

        public class Disconnected
        {
        }

        public class Connecting
        {
        }

        public class Reconnecting
        {
        }

        public class Join
        {
            public string HubName { get; private set; }

            public Join(string hubName)
            {
                HubName = hubName;
            }
        }

        public class Joined
        {
            public Joined(string client, string hubName)
            {
                Client = client;
                HubName = hubName;
            }

            public string Client { get; private set; }

            public string HubName { get; private set; }
        }

        public class NotFound
        {
            public NotFound(string hubName)
            {
                HubName = hubName;
            }

            public string HubName { get; private set; }
        }

        public class Leave
        {
            public Leave(string hubName)
            {
                HubName = hubName;
            }

            public string HubName { get; private set; }
        }

        public class Left
        {
            public Left(string client, string hub)
            {
                Client = client;
                Hub = hub;
            }

            public string Client { get; private set; }
            public string Hub { get; private set; }
        }

        public class Broadcast
        {
            public Broadcast(string hubName, object message)
            {
                HubName = hubName;
                Message = message;
            }

            public string HubName { get; private set; }
            public object Message { get; private set; }
        }

        public class StartHub
        {
            public StartHub(string hubName)
            {
                if (hubName.StartsWith(HubManager.ConnecteionPrefix))
                    throw new InvalidActorNameException("The name of a hub MUST not start with '~connection'.");

                HubName = hubName;
            }

            public string HubName { get; private set; }
        }

        public class HubStarted
        {
            public HubStarted(IActorRef hub)
            {
                Hub = hub;
            }

            public IActorRef Hub { get; private set; }
        }

        public class HubAlreadyExists
        {
            public HubAlreadyExists(string name, IActorRef hub)
            {
                Name = name;
                Hub = hub;
            }

            public string Name { get; private set; }

            public IActorRef Hub { get; private set; }
        }

        public class Bind
        {
            public Bind(int port) : this(new IPEndPoint(IPAddress.Any, port))
            {
            }

            public Bind(EndPoint endPoint)
            {
                EndPoint = endPoint;
            }

            public EndPoint EndPoint { get; private set; }
        }

        public class Bound
        {
            public Bound(EndPoint endPoint)
            {
                EndPoint = endPoint;
            }

            public EndPoint EndPoint { get; private set; }
        }

        public class BindingFailed
        {
            public BindingFailed(EndPoint endPoint, string reason)
            {
                EndPoint = endPoint;
                Reason = reason;
            }

            public EndPoint EndPoint { get; private set; }

            public string Reason { get; private set; }
        }

        public class RegisterClient
        {
            public RegisterClient(string hub)
            {
                Hub = hub;
            }

            public string Hub { get; private set; }
        }

        public class ClientRegistered
        {
            public ClientRegistered(IActorRef client, string hub)
            {
                Client = client;
                Hub = hub;
            }

            public IActorRef Client { get; private set; }

            public string Hub { get; private set; }
        }
    }
}
