using YC;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

[Serializable]
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct sign_up_t : IPacket_t {
char[] id_str__;
public char[] id_str{get { if (id_str__ is null) id_str__ = new char[20]; return id_str__; } }
char[] pass_str__;
public char[] pass_str{get { if (pass_str__ is null) pass_str__ = new char[20]; return pass_str__; } }
public int get_size() {
return sizeof(char) * 20 + sizeof(char) * 20 + 0;}
public byte[] get_byte(){
List<byte> bytes = new List<byte>();
foreach(var c in id_str)
{
bytes.AddRange(BitConverter.GetBytes(c));
}
foreach(var c in pass_str)
{
bytes.AddRange(BitConverter.GetBytes(c));
}
return bytes.ToArray();
}
public void set_byte(byte[] row) {
int idx = 0;
for(int i = 0; i < 20; i++)
{
id_str[i] = BitConverter.ToChar(row, idx); idx += sizeof(char);
}
for(int i = 0; i < 20; i++)
{
pass_str[i] = BitConverter.ToChar(row, idx); idx += sizeof(char);
}
}
}