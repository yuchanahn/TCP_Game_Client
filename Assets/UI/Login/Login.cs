using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using YC;
using YCEM;

public class Login : MonoBehaviour
{
    [SerializeField] InputField id;
    [SerializeField] InputField pass;
    [SerializeField] Text state;
    [SerializeField] UnityEvent on_login_success;
    [SerializeField] UnityEvent on_signup_success;
    [SerializeField] bool IsSignin = false;
    public static int user_id = -1;

    void Start()
    {
        ioev.Signal((login_r_t t) =>
        {
            state.text = t.r != -1 ? "로그인/회원가입 성공!" : "로그인/회원가입 실패!";
            user_id = t.r;
            if (t.r != -1) 
            {
                if (IsSignin)
                {
                    on_login_success.Invoke();
                }
                else
                {
                    on_signup_success.Invoke();
                }
            }
        });
    }

    public void Signin()
    {
        IsSignin = true;
        sign_in_t t = new sign_in_t();
        t.id_str.CopyFrom(id.text);
        t.pass_str.CopyFrom(pass.text);
        TCP_Master.Inst.Send(t);
    }
    public void Signup()
    {
        IsSignin = false;
        sign_up_t t = new sign_up_t();
        t.id_str.CopyFrom(id.text);
        t.pass_str.CopyFrom(pass.text);
        TCP_Master.Inst.Send(t);
    }
}
