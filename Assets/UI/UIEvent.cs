using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using yc;
using YCEM;

public class UIEvent : MonoBehaviour
{
    [SerializeField] static public Action<Transform> on_unique_enable = (Transform o) => { };
    [SerializeField] static public Action<Transform> on_unique_disable = (Transform o) => { };

    Dictionary<Transform, bool> prev = new Dictionary<Transform, bool>();


    private void Start()
    {
        prev = UI.UniqueUIs.ToDictionary(x => x, x => x.gameObject.activeSelf);
    }
    private void Update()
    {
        var enable_now = UI.UniqueUIs.Where(x => !prev[x] && x.gameObject.activeSelf).ToList();
        var disable_now = UI.UniqueUIs.Where(x => prev[x] && !x.gameObject.activeSelf).ToList();

        prev = UI.UniqueUIs.ToDictionary(x => x, x => x.gameObject.activeSelf);

        if (enable_now.Count > 0) on_unique_enable(enable_now.Last());
        if (disable_now.Count > 0) on_unique_disable(disable_now.Last());
    }
}