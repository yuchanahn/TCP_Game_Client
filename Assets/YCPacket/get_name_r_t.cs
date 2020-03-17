using YC;
using System;
using System.Collections.Generic;
public struct get_name_r_t : IPacket_t
{
    public int user_id;
    char[] name__;
    public char[] name { get { if (name__ is null) name__ = new char[50]; return name__; } }
    public int get_size()
    {
        return sizeof(int) + sizeof(char) * 50 + 0;
    }
    public byte[] get_byte()
    {
        List<byte> bytes = new List<byte>();
        bytes.AddRange(BitConverter.GetBytes(user_id));
        foreach (var c in name)
        {
            bytes.AddRange(BitConverter.GetBytes(c));
        }
        return bytes.ToArray();
    }
    public void set_byte(byte[] row)
    {
        int idx = 0;
        user_id = BitConverter.ToInt32(row, idx); idx += sizeof(int);
        for (int i = 0; i < 50; i++)
        {
            name[i] = BitConverter.ToChar(row, idx); idx += sizeof(char);
        }
    }
}