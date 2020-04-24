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
    Transform last_pop = null;
    private void Awake()
    {
        UIEvent.on_unique_disable += disable_ui => (last_undo != disable_ui).Match(() => Undos.Push(disable_ui));
        UIEvent.on_unique_enable += enable_ui => (last_pop != enable_ui).Match(() => last_undo = null);
    }

    public void run()
    {
        if (Undos.Count > 0)
        {
            last_undo = UI.UniqueUIs.Where(x => x.gameObject.activeSelf).Last();
            (last_pop = Undos.Pop()).gameObject.SetActive(true);
        }
    }
}