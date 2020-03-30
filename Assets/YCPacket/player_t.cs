using YC;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

[Serializable]
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct player_t : IPacket_t {
public int user_id;
public int speed;
public vec2_t pos;
public vec2_t vel;
public vec2_t dir;
public int get_size() {
return sizeof(int) + sizeof(int) + pos.get_size() + vel.get_size() + dir.get_size() + 0;}
public byte[] get_byte(){
List<byte> bytes = new List<byte>();
bytes.AddRange(BitConverter.GetBytes(user_id));
bytes.AddRange(BitConverter.GetBytes(speed));
bytes.AddRange(pos.get_byte());
bytes.AddRange(vel.get_byte());
bytes.AddRange(dir.get_byte());
return bytes.ToArray();
}
public void set_byte(byte[] row) {
int idx = 0;
user_id = BitConverter.ToInt32(row, idx); idx += sizeof(int);
speed = BitConverter.ToInt32(row, idx); idx += sizeof(int);
byte[] pos_byte = new byte[pos.get_size()];
Array.Copy(row, idx, pos_byte, 0, pos_byte.Length);
pos.set_byte(pos_byte); idx += pos_byte.Length;
byte[] vel_byte = new byte[vel.get_size()];
Array.Copy(row, idx, vel_byte, 0, vel_byte.Length);
vel.set_byte(vel_byte); idx += vel_byte.Length;
byte[] dir_byte = new byte[dir.get_size()];
Array.Copy(row, idx, dir_byte, 0, dir_byte.Length);
dir.set_byte(dir_byte); idx += dir_byte.Length;
}
}