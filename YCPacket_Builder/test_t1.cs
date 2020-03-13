using YC;
using System;
using System.Collections.Generic;
public struct test_t1 : IPacket_t {
byte[] c__;
public byte[] c{get { if (c__ is null) c__ = new byte[100]; return c__; } }
public int get_size() {
return sizeof(byte) * 100 + 0;}
public byte[] get_byte(){
List<byte> bytes = new List<byte>();
foreach(var c in c)
{
bytes.Add(c);
}
return bytes.ToArray();
}
public void set_byte(byte[] row) {
int idx = 0;
Array.Copy(row, idx, c, 0, c.Length); idx += sizeof(byte) * 100;
}
}