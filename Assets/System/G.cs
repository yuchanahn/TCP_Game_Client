using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class G : MonoBehaviour
{
    [SerializeField] Transform UI_ObjectPool;
    public static Transform UIObjPool;
    [SerializeField] Camera Camera;
    public static Camera Cam;

    private void Awake()
    {
        UIObjPool = UI_ObjectPool;
        Cam = Camera;

    }
}
