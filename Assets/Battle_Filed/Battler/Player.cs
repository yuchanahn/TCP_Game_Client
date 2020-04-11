using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using yc;
using YC;

[System.Serializable][StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct player_t : IPacket_t
{
    public int user_id;
    public int speed;
    public vec2_t pos;
    public vec2_t vel;
    public vec2_t dir;
};

public class Player : MonoBehaviour
{
    public static player_t main;
    public static GameObject main_obj => ChampSpwoner.Champs[Login.user_id].gameObject;

    bool once_f = false;

    private void Update()
    {   
        if(!once_f && Login.user_id != -1)
        {
            if (ChampSpwoner.Champs.ContainsKey(Login.user_id))
            {
                FindObjectOfType<Follow_Player>().target = main_obj.transform;
                once_f = true;
            }
        }
    }
}
