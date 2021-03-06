﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPBar : MonoBehaviour, yc.IPObject<HPBar>
{
    [SerializeField] Transform target = null;
    [SerializeField] Slider hp_bar;

    public void set_target(Transform target_object)
    {
        target = target_object;
        
    }

    public void on_start()
    {
    }

    private void Update()
    {
        if (target)
        {
            transform.GetComponent<RectTransform>().position = G.Cam.WorldToScreenPoint(target.position + Vector3.up * 2);
            hp_bar.maxValue = target.GetComponent<Champ>().stat.max_hp;
            hp_bar.value = target.GetComponent<Champ>().stat.hp;
        }
    }

    public void on_destroy()
    {
        Debug.Log("destroy");
    }
}
