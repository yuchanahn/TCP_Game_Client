using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YCNetObj<T> : MonoBehaviour
{
    public static Dictionary<int, T> list = new Dictionary<int, T>();
}
