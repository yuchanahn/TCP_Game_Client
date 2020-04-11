using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using YCEM;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    public static Transform[] UIList;
    public static UIEvent Event;


    private void Awake()
    {
        UIList = YC_EM.FindObjectsOfTypeAll<UIUnique>().Select(x => x.transform).ToArray();
        Event = FindObjectOfType<UIEvent>();
    }
}
