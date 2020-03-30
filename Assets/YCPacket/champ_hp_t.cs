using YC;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

[Serializable]
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct champ_hp_t : IPacket_t {
public int user_id;
public float hp;
public float max_hp;
public int get_size() {
return sizeof(int) + sizeof(float) + sizeof(float) + 0;}
public byte[] get_byte(){
List<byte> bytes = new List<byte>();
bytes.AddRange(BitConverter.GetBytes(user_id));
bytes.AddRange(BitConverter.GetBytes(hp));
bytes.AddRange(BitConverter.GetBytes(max_hp));
return bytes.ToArray();
}
public void set_byte(byte[] row) {
int idx = 0;
user_id = BitConverter.ToInt32(row, idx); idx += sizeof(int);
hp = BitConverter.ToSingle(row, idx); idx += sizeof(float);
max_hp = BitConverter.ToSingle(row, idx); idx += sizeof(float);
}
}