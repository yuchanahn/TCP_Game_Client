using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Champ : MonoBehaviour
{
    public int user_id = -1;
    public Vector3 target_pos;
    public Vector3 server_pos;
    public Vector3 dir;
    public float speed;
    private Rigidbody rigid;
    public int ani_id = -1;
    public float server_nomal_ani_t = -1;
    public bool bAttack_ani = false;
    string[] atk_anis;

    public YCStat stat = null;
    
    [SerializeField] GameObject hp_bar_prefab;


    void Awake()
    {
        rigid = GetComponent<Rigidbody>();
        atk_anis = new string[2];
        atk_anis[0] = "Attack";
        atk_anis[1] = "Skill";
    }

    public bool Run(Vector3 targetPos)
    {
        if (targetPos == Vector3.zero) return false;

        transform.localPosition = Vector3.MoveTowards(transform.position, transform.position + (targetPos * 10f), speed * Time.deltaTime);
        if ((transform.position - server_pos + targetPos * YC_Ping.ms).sqrMagnitude <= 0.01f)
        {
            Debug.Log("TP!");
            transform.localPosition = server_pos;
        }
        return true;
    }

    public void Turn(Vector3 dir)
    {
        if (dir == Vector3.zero) return;
        rigid.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(dir), 550.0f * Time.deltaTime);
    }

    bool hpbar = false;
    void Update2()
    {
        if(!hpbar && stat != null)
        {
            yc.YCObjectPool.Instantiate(hp_bar_prefab, GM.UI).GetComponent<HPBar>().set_target(transform);
            hpbar = true;
        }

        if (bAttack_ani)
        {
            var ani_info = GetComponent<Animator>().GetCurrentAnimatorStateInfo(0);
            if (ani_info.nameHash != Animator.StringToHash("Base Layer.Attack"))
                GetComponent<Animator>().Play("Attack", 0, server_nomal_ani_t + (server_nomal_ani_t * YC_Ping.ms));
            bAttack_ani = false;
            return;
        }
        Turn(dir);
        if (Run(target_pos))
        {
            GetComponent<Animator>().SetFloat("Blend", Mathf.Clamp01(speed));
        }
        else
        {
            GetComponent<Animator>().SetFloat("Blend", 0);
        }
    }

    private void Update()
    {
        Update2();
    }
}
