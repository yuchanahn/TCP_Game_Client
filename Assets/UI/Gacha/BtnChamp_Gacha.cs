using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using YC;

[Serializable]
[StructLayout(LayoutKind.Sequential, Pack = 1)]
struct champ_gacha_t : IPacket_t
{
    public int gacha_type;
};
[Serializable]
[StructLayout(LayoutKind.Sequential, Pack = 1)]
struct champ_gacha_r_t : IPacket_t
{
    public int new_champ_code;
};

public class BtnChamp_Gacha : MonoBehaviour
{
    [SerializeField] champ_gacha_t option;

    public void start_gacha()
    {
        TCP_Master.Inst.Send(option);
    }
}
