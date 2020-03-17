using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using YC;
using YCEM;

public class Get_Nickname : MonoBehaviour
{
    [SerializeField] Text nickname;

    void Start()
    {
        ioev.Signal((get_name_r_t t) =>
        {
            nickname.text = t.name.get_string();
        });
    }
}
