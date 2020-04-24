using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;
using YC;
using YCEM;


[System.Serializable][StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode, Pack = 1)]
public struct get_name_r_t
{
    public int user_id;
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 50)]
    public string name;
}


public class Get_Nickname : MonoBehaviour
{
    [SerializeField] Text nickname;
    [SerializeField] string nickname_;
    void Start()
    {
        ioev.Signal((get_name_r_t t) =>
        {
            Debug.Log(t.name);

            nickname_ = t.name;
        });
    }

    private void Update()
    {
        nickname.text = nickname_;
    }
}
