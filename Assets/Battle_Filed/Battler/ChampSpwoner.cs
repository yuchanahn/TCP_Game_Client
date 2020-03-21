using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YC;

public class ChampSpwoner : MonoBehaviour
{
    [SerializeField] GameObject champ_prefab;

    public static Dictionary<int, Champ> Champs = new Dictionary<int, Champ>();
    public static Dictionary<int, bool> Is_Created = new Dictionary<int, bool>();

    private void Start()
    {
        System.Action<player_t> set_champ = (player_t t) =>
        {
            Champs[t.user_id].server_pos = new Vector3(t.pos.x, 0, t.pos.y);
            Champs[t.user_id].target_pos = new Vector3(t.vel.x, 0, t.vel.y);
            Champs[t.user_id].speed = t.speed;
        };

        ioev.Signal((champ_ani_t t)=> {
            if (Champs.ContainsKey(t.user_id))
            {
                Champs[t.user_id].ani_id = t.ani_id;
                Champs[t.user_id].bAttack_ani = true;
                Champs[t.user_id].server_nomal_ani_t = t.ani_nomal_time;
            }
        });
        ioev.Signal((champ_hp_t t)=> {
            Debug.Log("Get hp data");
        });
        ioev.Signal((player_t t) =>
        {
            if (t.user_id == Login.user_id)
            {
                Player.main = t;
            }

            if (!Champs.ContainsKey(t.user_id))
            {
                if (!Is_Created.ContainsKey(t.user_id))
                {
                    Is_Created[t.user_id] = true;
                    TCP_Master.Inst.DoMain(() =>
                    {
                        Champs[t.user_id] = Instantiate(
                          champ_prefab,
                          new Vector3(t.pos.x, 0, t.pos.y),
                          Quaternion.identity).GetComponent<Champ>();
                        Champs[t.user_id].user_id = t.user_id;
                        set_champ(t);
                    });
                }
            }
            else
            {
                set_champ(t);
            }
        });
    }
}
