using YC;
using System;
using System.Collections.Generic;
public struct champ_ani_t : IPacket_t {
public int user_id;
public int ani_id;
public float ani_nomal_time;
public int get_size() {
return sizeof(int) + sizeof(int) + sizeof(float) + 0;}
public byte[] get_byte(){
List<byte> bytes = new List<byte>();
bytes.AddRange(BitConverter.GetBytes(user_id));
bytes.AddRange(BitConverter.GetBytes(ani_id));
bytes.AddRange(BitConverter.GetBytes(ani_nomal_time));
return bytes.ToArray();
}
public void set_byte(byte[] row) {
int idx = 0;
user_id = BitConverter.ToInt32(row, idx); idx += sizeof(int);
ani_id = BitConverter.ToInt32(row, idx); idx += sizeof(int);
ani_nomal_time = BitConverter.ToSingle(row, idx); idx += sizeof(float);
}
}