﻿namespace Intersect.Network.Packets
{
    public abstract class SlotSwapPacket : CerasPacket
    {
        public int Slot1 { get; set; }

        public int Slot2 { get; set; }

        protected SlotSwapPacket(int slot1, int slot2)
        {
            Slot1 = slot1;
            Slot2 = slot2;
        }

        public override bool IsValid => Slot1 != Slot2 && Slot1 >= 0 && Slot2 >= 0;
    }
}
