using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using yc;
using YCEM;

public class UniqueActiveTrueList : MonoBehaviour
{
    private void Awake()
    {
        UIEvent.on_unique_enable += u => UI.UIList.Where(x => x != u)
                                                  .for_each(x => x.gameObject.SetActive(false));
    }
}
