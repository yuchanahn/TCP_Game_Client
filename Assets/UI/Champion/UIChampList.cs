using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using YC;

public class UIChampList : MonoBehaviour
{

    public static UIChampList Inst;

    private void Awake()
    {
        Inst = this;
    }

    void Start()
    {
        ioev.Signal((champ_list_t l) =>
        {
            if(!ChampList.list.ContainsKey(l.user_id))
            {
                TCP_Master.Inst.DoMain(() =>
                {
                    UI.ChampList.GetComponent<ChampList>().Init(l.user_id);
                    ChampList.list[l.user_id].Champ_list_self = l;

                    Debug.Log(l.count);
                });
            }
            else
            {
                ChampList.list[l.user_id].Champ_list_self = l;
            }
        });

        ioev.Signal((champ_gacha_r_t r) =>
        {
            TCP_Master.Inst.DoMain(() =>
            {
                champ_list_t new_champ_list = ChampList.list[Login.user_id].Champ_list_self;
                new_champ_list.champs[new_champ_list.count++] = ChampDB.get_champ_type(r.new_champ_code);
                ChampList.list[Login.user_id].Champ_list_self = new_champ_list;
            });
        });
    }
    public void req_champlist()
    {
        var r = new req_champ_list_t();
        r.user_id = Login.user_id;
        TCP_Master.Inst.Send(r);
    }

    public static GameObject CreateImage(GameObject fp, Sprite spr, Transform pr, champ_type_t type)
    {
        var o = Instantiate(fp, pr);
        o.GetComponent<Image>().sprite = spr;
        o.GetComponent<ChampSlot>().champ = type;
        return o;
    }
}
