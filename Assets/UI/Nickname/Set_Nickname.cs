using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using YC;
using YCEM;

[System.Serializable][StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct set_name_r_t : IPacket_t
{
    public bool IsSuccess;
};

[System.Serializable][StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct get_name_t : IPacket_t
{
    public int user_id;
};

[System.Serializable][StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct set_name_t : IPacket_t
{
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 100)]
    public string name;
};


public class Set_Nickname : MonoBehaviour
{
    [SerializeField] UnityEvent on_rename;

    private void Start()
    {
        ioev.Signal((set_name_r_t t) =>
        {
            if (t.IsSuccess)
            {
                var g = new get_name_t();
                g.user_id = Login.user_id;
                TCP_Master.Inst.Send(g);
                TCP_Master.Inst.DoMain(() =>
                {
                    on_rename.Invoke();
                });
            }
        });
    }

    public void rename(InputField s)
    {
        set_name_t set_name = new set_name_t();
        set_name.name = s.text;
        TCP_Master.Inst.Send(set_name);
    }
}
