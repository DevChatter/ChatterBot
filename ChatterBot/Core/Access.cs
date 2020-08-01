using System;

namespace ChatterBot.Core
{
    [Flags]
    public enum Access : uint
    {
        Everyone = 1,
        Followers = 2,
        Subscribers = 4,
        VIPs = 8,
        Moderators = 16,
        Streamer = 32,
    }
}