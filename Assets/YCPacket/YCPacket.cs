﻿using System;
using System.Collections.Generic;

namespace YC
{
    public interface IPacket_t
    {
        byte[] get_byte();
        void set_byte(byte[] row);
        int get_size();
    }
    public static class ioev
    {
        public static void Map<T>(int id)
        {
            T t = default(T);
            YCPacket.pakcet_mapping_id[t.GetType()] = id;
            YCPacket.pakcet_mapping_type[id] = t.GetType();
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
        public static Dictionary<int, Type> pakcet_mapping_type = new Dictionary<int, Type>();
        public static Dictionary<int, Action<object>> pevent = new Dictionary<int, Action<object>>();
        public static byte[] Get_YCPacket_Format(IPacket_t packet)
        {
            List<byte> bytes = new List<byte>();
            var data = packet.get_byte();
            int len = data.Length + sizeof(int) + sizeof(int);
            int mapping_id = pakcet_mapping_id[packet.GetType()];

            bytes.AddRange(BitConverter.GetBytes(len));
            bytes.AddRange(BitConverter.GetBytes(mapping_id));
            bytes.AddRange(data);

            return bytes.ToArray();
        }
        public static IPacket_t GetTypeObj(int id)
        {
            return Activator.CreateInstance(pakcet_mapping_type[id]) as IPacket_t;
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
                    var obj = GetTypeObj(ID);
                    obj.set_byte(packet_row);
                    pevent[ID](obj);
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
