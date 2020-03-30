using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GM : MonoBehaviour
{
    [SerializeField] Transform UI_ObjectPool;
    public static Transform UI;
    [SerializeField] Camera Camera;
    public static Camera Cam;


    private void Awake()
    {
        UI = UI_ObjectPool;
        Cam = Camera;
    }
}
