using YC;
using System;
using System.Collections.Generic;
public struct ping_t : IPacket_t
{
    public long ping;
    public int get_size()
    {
        return sizeof(long) + 0;
    }
    public byte[] get_byte()
    {
        List<byte> bytes = new List<byte>();
        bytes.AddRange(BitConverter.GetBytes(ping));
        return bytes.ToArray();
    }
    public void set_byte(byte[] row)
    {
        int idx = 0;
        ping = BitConverter.ToInt64(row, idx); idx += sizeof(long);
    }
}