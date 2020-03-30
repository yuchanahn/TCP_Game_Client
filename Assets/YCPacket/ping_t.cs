using YC;
using System;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;

[Serializable]
[StructLayout(LayoutKind.Sequential, Pack=1)]
public struct ping_t : IPacket_t
{
    public long ping;

    public byte[] get_byte()
    {
        throw new NotImplementedException();
    }

    public int get_size()
    {
        return sizeof(long) + 0;
    }
    public void set_byte(byte[] row)
    {
        int idx = 0;
        ping = BitConverter.ToInt64(row, idx); idx += sizeof(long);
    }
}