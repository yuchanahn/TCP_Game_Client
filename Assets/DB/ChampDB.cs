using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using YC;

[Serializable][StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct champ_type_t : IPacket_t
{
    public int code;
    public int star;
    public int lv;
    public int item1;
    public int item2;
    public int item3;
    public int item4;
    public int item5;
    public int item6;
    public int value1;
}

[Serializable][StructLayout(LayoutKind.Sequential, Pack = 1)]
struct champ_list_t : IPacket_t
{
    public int user_id;
    public int count;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
    public champ_type_t[] champs;
}

[Serializable][StructLayout(LayoutKind.Sequential, Pack = 1)]
struct req_champ_list_t : IPacket_t
{
    public int user_id;
}

[Serializable]
public struct champ_data
{
    public string name;
    public Sprite spr;
    public champ_stat_t defult_stats;
    public champ_stat_t growth_stats;
}

[Serializable]
public struct champ_stat_t
{
    public float op;
    public float dp;
    public float sp;
}

public class ChampDB : MonoBehaviour
{
    [SerializeField] champ_data[] db;

    static ChampDB Inst;
    private void Awake()
    {
        Inst = this;
    }

    public static champ_data get(int champ_code)
    {
        return Inst.db[champ_code];
    }

    public static champ_type_t get_champ_type(int champ_code)
    {
        var r = new champ_type_t();
        r.code = champ_code;
        r.lv = 1;
        r.star = 1;
        r.item1 = -1;
        r.item2 = -1;
        r.item3 = -1;
        r.item4 = -1;
        r.item5 = -1;
        r.item6 = -1;
        r.value1 = -1;

        return r;
    }
}
