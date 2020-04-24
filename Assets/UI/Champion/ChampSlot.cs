using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChampSlot : MonoBehaviour
{
    public champ_type_t champ;

    public void get_info()
    {
        UI.ChampInfo.open_champInfo(champ);
        UI.ChampInfo.gameObject.SetActive(true);
    }
}
