using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class YC_PACKET : MonoBehaviour
{

    public static byte[] RawSerialize(object ShmStruct, int size)
    {
        IntPtr buffer = Marshal.AllocHGlobal(size);
        Marshal.StructureToPtr(ShmStruct, buffer, false);
        byte[] RawData = new byte[size];
        Marshal.Copy(buffer, RawData, 0, size);
        Marshal.FreeHGlobal(buffer);
        return RawData;
    }

    public static object RawDeSerialize(byte[] RawData, Type ShmData)
    {
        int RawSize = Marshal.SizeOf(ShmData);

        //Size Over
        if (RawSize > RawData.Length)
        {
            return null;
        }

        IntPtr buffer = Marshal.AllocHGlobal(RawSize);
        Marshal.Copy(RawData, 0, buffer, RawSize);
        object retobj = Marshal.PtrToStructure(buffer, ShmData);
        Marshal.FreeHGlobal(buffer);
        return retobj;
    }
}
