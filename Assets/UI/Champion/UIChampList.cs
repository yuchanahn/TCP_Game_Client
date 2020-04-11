using System.Collections;
using System.Collections.Generic;
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

    void test_champ_list_update(champ_list_t l)
    {
        var o = GM.ChampSlot.GetComponent<IUser>();
        o.Init(l.user_id);

        (o as ChampList).Champ_list_self = l;
    }

    void Start()
    {
        var c = new champ_list_t();
        c.user_id = 0;
        c.count = 1;
        c.champs = new champ_type_t[1];
        c.champs[0] = ChampDB.get_champ_type(0);

        test_champ_list_update(c);


        ioev.Signal((champ_list_t l) =>
        {
            var o = ChampList.list[l.user_id];

            o.Champ_list_self = l;
        });


        ioev.Signal((champ_gacha_r_t r) =>
        {
            var o = ChampList.list[Login.user_id].Champ_list_self;
            o.champs[o.count] = ChampDB.get_champ_type(r.new_champ_code);
            o.count++;
        });
    }
    public void req_champlist()
    {
        var r = new req_champ_list_t();
        r.user_id = Login.user_id;
        TCP_Master.Inst.Send(r);
    }

    public static GameObject CreateImage(GameObject fp, Sprite spr, Transform pr)
    {
        var o = Instantiate(fp, pr);
        o.GetComponent<Image>().sprite = spr;
        return o;
    }
}
