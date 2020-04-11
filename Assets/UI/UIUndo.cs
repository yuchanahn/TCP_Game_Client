using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using yc;
using YCEM;

public class UIUndo : MonoBehaviour
{
    Stack<Transform> Undos = new Stack<Transform>();
    Transform last_undo = null;
    private void Awake()
    {
        UIEvent.on_unique_disable += disable_ui => (last_undo != disable_ui).Match(() => Undos.Push(disable_ui));
    }

    public void run()
    {
        if (Undos.Count > 0)
        {
            last_undo = UI.UIList.Where(x => x.gameObject.activeSelf).Last();
            Undos.Pop().gameObject.SetActive(true);
        }
    }
}