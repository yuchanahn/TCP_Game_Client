using YC;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

[Serializable]
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct vec2_t : IPacket_t {
public float x;
public float y;
public int get_size() {
return sizeof(float) + sizeof(float) + 0;}
public byte[] get_byte(){
List<byte> bytes = new List<byte>();
bytes.AddRange(BitConverter.GetBytes(x));
bytes.AddRange(BitConverter.GetBytes(y));
return bytes.ToArray();
}
public void set_byte(byte[] row) {
int idx = 0;
x = BitConverter.ToSingle(row, idx); idx += sizeof(float);
y = BitConverter.ToSingle(row, idx); idx += sizeof(float);
}
}