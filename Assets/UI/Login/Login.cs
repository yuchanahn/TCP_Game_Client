using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using YC;
using YCEM;
using System.Runtime.InteropServices;

[System.Serializable][StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct login_r_t : IPacket_t
{
    public int r;
}

[System.Serializable][StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct sign_in_t : IPacket_t
{
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 40)] public string id_str;
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 40)] public string pass_str;
};

[System.Serializable][StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct sign_up_t : IPacket_t
{
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 40)] public string id_str;
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 40)] public string pass_str;
};



public class Login : MonoBehaviour
{
    [SerializeField] InputField id;
    [SerializeField] InputField pass;
    [SerializeField] Text state;
    [SerializeField] string state_;
    [SerializeField] UnityEvent on_login_success;
    [SerializeField] UnityEvent on_signup_success;
    [SerializeField] bool IsSignin = false;
    public static int user_id = -1;

    void Start()
    {
        ioev.Signal((login_r_t t) =>
        {
            state_ = t.r != -1 ? "로그인/회원가입 성공!" : "로그인/회원가입 실패!";
            user_id = t.r;
            if (t.r != -1) 
            {
                if (IsSignin)
                {
                    TCP_Master.Inst.DoMain( () => { on_login_success.Invoke(); });
                }
                else
                {
                    TCP_Master.Inst.DoMain(() => { on_signup_success.Invoke(); });
                }
            }
        });
    }

    private void Update()
    {
        state.text = state_;
    }

    public void Signin()
    {
        IsSignin = true;
        sign_in_t t = new sign_in_t();
        t.id_str = id.text;
        t.pass_str = pass.text;
        TCP_Master.Inst.Send(t);
    }
    public void Signup()
    {
        IsSignin = false;
        sign_up_t t = new sign_up_t();
        t.id_str = id.text;
        t.pass_str = pass.text;
        TCP_Master.Inst.Send(t);
    }
}
