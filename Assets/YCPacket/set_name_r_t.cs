using YC;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

[Serializable]
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct set_name_r_t : IPacket_t {
public bool IsSuccess;
public int get_size() {
return sizeof(bool) + 0;}
public byte[] get_byte(){
List<byte> bytes = new List<byte>();
bytes.AddRange(BitConverter.GetBytes(IsSuccess));
return bytes.ToArray();
}
public void set_byte(byte[] row) {
int idx = 0;
IsSuccess = BitConverter.ToBoolean(row, idx); idx += sizeof(bool);
}
}