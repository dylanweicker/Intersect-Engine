﻿
using Intersect.Admin.Actions;

namespace Intersect.Network.Packets.Client
{
    public class AdminActionPacket : CerasPacket
    {
        public AdminAction Action { get; set; }

        public AdminActionPacket(AdminAction action)
        {
            Action = action;
        }
    }
}
