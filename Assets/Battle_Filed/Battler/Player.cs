using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YC;

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
