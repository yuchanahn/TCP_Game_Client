using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using YC;

public class YC_Ping : MonoBehaviour
{
    [SerializeField] Text ping_text;
    [SerializeField] float send_rate;
    static int ms;
    private void Start()
    {
        ioev.Signal((ping_t t) =>
        {
            ms = ((int)((DateTime.Now - DateTime.FromBinary(t.ping)).TotalSeconds * 1000));
        });
        
        StartCoroutine(send_ping());
    }

    private void Update()
    {
        ping_text.text = ms.ToString();
    }

    IEnumerator send_ping()
    {
        while (true)
        {
            ping_t t;
            t.ping = DateTime.Now.ToBinary();
            TCP_Master.Inst.Send(t);
            yield return new WaitForSeconds(send_rate);
        }
    }
}
