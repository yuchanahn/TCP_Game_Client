using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using YC;

public class TCP_Master : MonoBehaviour
{
    public static TCP_Master Inst;

    YC_TCP_Master tcp;

    private void Awake()
    {
        Inst = this;

        ioev.Map<test_t>(0);

        tcp = new YC_TCP_Master("127.0.0.1", 51234);
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
