using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using YC;

public class YC_Chat : MonoBehaviour
{
    [SerializeField] InputField input_filed;
    [SerializeField] Text text_area;
    string buf = "";
    void Start()
    {
        ioev.Signal((test_t t) =>
        {
            buf += "\n" + new string((from c in t.chat_data
                                      where c != '\0'
                                      select c).ToArray());
            text_area.text = $"{buf}";
        });
    }

    void SendMessage()
    {
        var input = input_filed.text;
        if (input == "") return;

        input_filed.text = "";
        test_t t = new test_t();
        var b = input.ToCharArray();

        if (b.Length >= 100)
        {
            Debug.Log("100자 이상의 문자는 전송할 수 없습니다.");
            return;
        }
        Array.Copy(b, 0, t.chat_data, 0, b.Length);

        TCP_Master.Inst.Send(t);
    }

    void Update()
    {
        
        if(Input.GetKeyDown(KeyCode.Return))
        {
            if (input_filed.IsActive()) 
                SendMessage();

            input_filed.Select();
        }
    }
}
