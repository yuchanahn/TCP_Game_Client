using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using YCEM;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    public static Transform[] UniqueUIs;
    public static UIEvent Event;
    [SerializeField] GameObject champ_list;
    public static GameObject ChampList;
    [SerializeField] GameObject champ_slot;
    public static GameObject ChampSlotPrefab;
    [SerializeField] ChampInfo champ_info;
    public static ChampInfo ChampInfo;

    private void Awake()
    {
        UniqueUIs = YC_EM.FindObjectsOfTypeAll<UIUnique>().Select(x => x.transform).ToArray();
        Event = FindObjectOfType<UIEvent>();
        ChampList = champ_list;
        ChampSlotPrefab = champ_slot;
        ChampInfo = champ_info;
    }
}
