using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using YC;
using YCEM;

public class Set_Nickname : MonoBehaviour
{
    [SerializeField] UnityEvent on_rename;

    private void Start()
    {
        ioev.Signal((set_name_r_t t) =>
        {
            if(t.IsSuccess)
            {
                var g = new get_name_t();
                g.user_id = Login.user_id;
                TCP_Master.Inst.Send(g);
                on_rename.Invoke();
            }
        });
    }

    public void rename(InputField s)
    {
        set_name_t set_name = new set_name_t();
        set_name.name.CopyFrom(s.text);
        TCP_Master.Inst.Send(set_name);
    }
}
