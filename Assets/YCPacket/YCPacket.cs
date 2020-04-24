using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

namespace YC
{
    public interface IPacket_t
    { 
    }
    public static class ioev
    {
        public static void Map<T>(int id)
        {
            T t = default(T);
            YCPacket.pakcet_mapping_id[t.GetType()] = id;
            YCPacket.packet_mapping_type[id] = t.GetType();
        }

        public static void Signal<T>(Action<T> ev)
        {
            T t = default(T);
            if(YCPacket.pevent.ContainsKey(YCPacket.pakcet_mapping_id[t.GetType()]))
            {
                YCPacket.pevent[YCPacket.pakcet_mapping_id[t.GetType()]] += (object o) => { ev((T)o); };
            }
            else
            {
                YCPacket.pevent[YCPacket.pakcet_mapping_id[t.GetType()]] = (object o) => { ev((T)o); };
            }
        }
    }
    public static class YCPacket
    {
        public static Dictionary<Type, int> pakcet_mapping_id = new Dictionary<Type, int>();
        public static Dictionary<int, Type> packet_mapping_type = new Dictionary<int, Type>();
        public static Dictionary<int, Action<object>> pevent = new Dictionary<int, Action<object>>();
        public static byte[] Get_YCPacket_Format(IPacket_t packet)
        {
            List<byte> bytes = new List<byte>();
            var data = YC_PACKET.RawSerialize(packet, Marshal.SizeOf(packet.GetType()));
            int len = data.Length + sizeof(int) + sizeof(int);
            int mapping_id = pakcet_mapping_id[packet.GetType()];

            bytes.AddRange(BitConverter.GetBytes(len));
            bytes.AddRange(BitConverter.GetBytes(mapping_id));
            bytes.AddRange(data);

            return bytes.ToArray();
        }
        public static IPacket_t GetTypeObj(int id)
        {
            return Activator.CreateInstance(packet_mapping_type[id]) as IPacket_t;
        }
        static List<byte> buf = new List<byte>();
        public static void read(byte[] bytes, int length)
        {
            buf.AddRange(bytes);

            Start_Packet_Read:

            var in_packet = buf.ToArray();

            if (in_packet.Length <= sizeof(int) + sizeof(int))
            {
                return;
            }
            else
            {
                int Size = BitConverter.ToInt32(in_packet, 0);
                int ID = BitConverter.ToInt32(in_packet, sizeof(int));

                if (in_packet.Length >= Size)
                {
                    var packet_row = new byte[Size - sizeof(int) - sizeof(int)];
                    Array.Copy(bytes, sizeof(int) + sizeof(int), packet_row, 0, packet_row.Length);
                    //var obj = GetTypeObj(ID);
                    //obj.set_byte(packet_row);
                    try
                    {
                        pevent[ID](YC_PACKET.RawDeSerialize(packet_row, packet_mapping_type[ID]));
                    }
                    catch(Exception e)
                    {
                        Debug.Log(e);
                        Debug.Log(packet_mapping_type[ID]);
                    }

                    //pevent[ID](YC_PACKET.RawDeSerialize(packet_row, pakcet_mapping_type[ID]));
                    buf.RemoveRange(0, Size);
                    if (buf.Count > 8)
                    {
                        goto Start_Packet_Read;
                    }
                }
            }
        }
    }
}
