using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using YC;

[System.Serializable]
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct cmd_game_start_t : IPacket_t
{
    public int f;
};

public class BattleMgr : MonoBehaviour
{
    public void start_battle()
    {
        var game_start = new cmd_game_start_t();
        game_start.f = 1;
        TCP_Master.Inst.Send(game_start);
    }
}
