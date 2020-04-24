using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VSOnEnable : VSBase
{
    private void OnEnable()
    {
        On.Invoke();
    }
}
