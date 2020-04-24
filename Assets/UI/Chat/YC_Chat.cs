using System;
using UnityEngine;
using UnityEngine.UI;
using YC;
using YCEM;
using System.Runtime.InteropServices;

[System.Serializable][StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode, Pack = 1)]
public struct test_t : IPacket_t
{
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 100)]
    public string chat_data;
}


public class YC_Chat : MonoBehaviour
{
    [SerializeField] InputField input_filed;
    [SerializeField] Text text_area;
    string buf = "";
    void Start()
    {
        ioev.Signal((test_t t) =>
        {
            buf += "\n" + t.chat_data;
            TCP_Master.Inst.DoMain(()=>text_area.text = $"{buf}");
        });
    }

    void SendMessage()
    {
        var input = input_filed.text;
        if (input == "") return;

        input_filed.text = "";
        test_t t = new test_t();

        if (input.Length >= 100)
        {
            Debug.Log("100자 이상의 문자는 전송할 수 없습니다.");
            return;
        }
        t.chat_data = input;

        TCP_Master.Inst.Send(t);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return))
        {
            if (input_filed.IsActive())
            {
                SendMessage();
            }
            
            input_filed.Select();
        }
    }
}
