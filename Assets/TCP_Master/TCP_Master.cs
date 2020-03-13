using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using YC;

public class TCP_Master : MonoBehaviour
{
    public string input_chat;

    private void Start()
    {
        ioev.Map<test_t>(0);

        ioev.Signal((test_t t) =>
        {
            Debug.Log(t.chat_data);
        });

        YC_TCP_Master tcp = new YC_TCP_Master("127.0.0.1", 51234);

        Thread t1 = new Thread(new ThreadStart(() => { while (true) tcp.run(); }));
        t1.Start();

        while (true)
        {
            var input = input_chat;

            test_t t = new test_t();
            var b = input.ToCharArray();

            if (b.Length >= 100)
            {
                Debug.Log("100자 이상의 문자는 전송할 수 없습니다.");
                continue;
            }
            Array.Copy(b, 0, t.chat_data, 0, b.Length);

            for (int i = 0; i < 1000; i++)
            {
                Thread.Sleep(10);
                tcp.send(t);
            }
        }
    }
}
