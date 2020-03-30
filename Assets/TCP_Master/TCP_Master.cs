﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using YC;

public class TCP_Master : MonoBehaviour
{
    public static TCP_Master Inst;

    [SerializeField] string ip; 
    [SerializeField] int port; 

    YC_TCP_Master tcp;

    private void OnDestroy()
    {
        tcp.SocketDisconnet();
    }

    private void Awake()
    {
        Inst = this;

        ioev.Map<test_t>            (0);
        ioev.Map<ping_t>            (1);
        ioev.Map<sign_in_t>         (2);
        ioev.Map<sign_up_t>         (3);
        ioev.Map<login_r_t>         (4);
        ioev.Map<set_name_t>        (5);
        ioev.Map<set_name_r_t>      (6);
        ioev.Map<get_name_t>        (7);
        ioev.Map<get_name_r_t>      (8);
        ioev.Map<vec2_t>            (9);
        ioev.Map<player_t>         (10);
        ioev.Map<champ_hp_t>       (11);
        ioev.Map<champ_ani_t>      (12);

        tcp = new YC_TCP_Master(ip, port);
    }

    public void DoMain(Action a)
    {
        tcp.DoMainThread(a);
    }

    private void Update()
    {
        tcp.run();
    }

    public void Send(IPacket_t p)
    {
        tcp.send(p);
    }
}
