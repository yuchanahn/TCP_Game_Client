using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow_Player : MonoBehaviour
{
    public Transform target;          
    public float dist = 10.0f;       
    public float height = 5.0f;      
    public float dampRotate = 5.0f;  
    private Transform tr;            

    private void Start()
    {
        tr = GetComponent<Camera>().transform;
    }

    void LateUpdate()
    {
        float cur_Y_Angle = Mathf.LerpAngle(tr.eulerAngles.y, target.eulerAngles.y, dampRotate * Time.deltaTime);
        Quaternion rot = Quaternion.Euler(0, cur_Y_Angle, 0);
        tr.position = target.position - (rot * Vector3.forward * dist) + (Vector3.up * height);
        tr.LookAt(target);
    }
}
