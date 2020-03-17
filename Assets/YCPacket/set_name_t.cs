using YC;
using System;
using System.Collections.Generic;
public struct set_name_t : IPacket_t {
char[] name__;
public char[] name{get { if (name__ is null) name__ = new char[50]; return name__; } }
public int get_size() {
return sizeof(char) * 50 + 0;}
public byte[] get_byte(){
List<byte> bytes = new List<byte>();
foreach(var c in name)
{
bytes.AddRange(BitConverter.GetBytes(c));
}
return bytes.ToArray();
}
public void set_byte(byte[] row) {
int idx = 0;
for(int i = 0; i < 50; i++)
{
name[i] = BitConverter.ToChar(row, idx); idx += sizeof(char);
}
}
}