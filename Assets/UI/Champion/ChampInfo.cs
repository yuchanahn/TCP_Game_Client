using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;

public class ChampInfo : MonoBehaviour
{
    [SerializeField] Text op;
    [SerializeField] Text dp;
    [SerializeField] Text sp;

    [SerializeField] Image item1;
    [SerializeField] Image item2;
    [SerializeField] Image item3;
    [SerializeField] Image item4;
    [SerializeField] Image item5;
    [SerializeField] Image item6;


    public void open_champInfo(champ_type_t champ)
    {
        var cd = ChampDB.get(champ.code).defult_stats;
        var cg = ChampDB.get(champ.code).growth_stats;

        op.text = (cd.op * champ.star + cg.op * champ.lv).ToString();
        dp.text = (cd.dp * champ.star + cg.dp * champ.lv).ToString();
        sp.text = (cd.sp * champ.star + cg.sp * champ.lv).ToString();
    }
}
