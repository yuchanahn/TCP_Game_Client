using YC;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

[Serializable]
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct test_t1 : IPacket_t {
char[] c__;
public char[] c{get { if (c__ is null) c__ = new char[100]; return c__; } }
public int get_size() {
return sizeof(char) * 100 + 0;}
public byte[] get_byte(){
List<byte> bytes = new List<byte>();
foreach(var c in c)
{
bytes.AddRange(BitConverter.GetBytes(c));
}
return bytes.ToArray();
}
public void set_byte(byte[] row) {
int idx = 0;
for(int i = 0; i < 100; i++)
{
c[i] = BitConverter.ToChar(row, idx); idx += sizeof(char);
}
}
}