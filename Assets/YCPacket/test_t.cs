using YC;
using System;
using System.Collections.Generic;
public struct test_t : IPacket_t
{
    char[] chat_data__;
    public char[] chat_data { get { if (chat_data__ is null) chat_data__ = new char[100]; return chat_data__; } }
    public int get_size()
    {
        return sizeof(char) * 100 + 0;
    }
    public byte[] get_byte()
    {
        List<byte> bytes = new List<byte>();
        foreach (var c in chat_data)
        {
            bytes.AddRange(BitConverter.GetBytes(c));
        }
        return bytes.ToArray();
    }
    public void set_byte(byte[] row)
    {
        int idx = 0;
        for (int i = 0; i < 100; i++)
        {
            chat_data[i] = BitConverter.ToChar(row, idx); idx += sizeof(char);
        }
    }
}