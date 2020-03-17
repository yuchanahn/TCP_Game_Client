using YC;
using System;
using System.Collections.Generic;
public struct login_r_t : IPacket_t {
public int r;
public int get_size() {
return sizeof(int) + 0;}
public byte[] get_byte(){
List<byte> bytes = new List<byte>();
bytes.AddRange(BitConverter.GetBytes(r));
return bytes.ToArray();
}
public void set_byte(byte[] row) {
int idx = 0;
r = BitConverter.ToInt32(row, idx); idx += sizeof(int);
}
}