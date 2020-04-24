using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VSOnDisable : VSBase
{
    private void OnDisable()
    {
        On.Invoke();
    }
}
