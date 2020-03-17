using YC;
using System;
using System.Collections.Generic;
public struct get_name_t : IPacket_t {
public int user_id;
public int get_size() {
return sizeof(int) + 0;}
public byte[] get_byte(){
List<byte> bytes = new List<byte>();
bytes.AddRange(BitConverter.GetBytes(user_id));
return bytes.ToArray();
}
public void set_byte(byte[] row) {
int idx = 0;
user_id = BitConverter.ToInt32(row, idx); idx += sizeof(int);
}
}