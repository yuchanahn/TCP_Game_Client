using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace yc
{

    interface IPObject<T> : YCI
    {

    }


    public class YCObjectPool : MonoBehaviour
    {
        static Dictionary<System.Type, Stack<GameObject>> stack = new Dictionary<System.Type, Stack<GameObject>>();

        public static GameObject Instantiate(GameObject ori)
        {
            System.Type t = ori.GetComponent<YCI>().GetType();
            if (!stack.ContainsKey(t) || stack[t].Count == 0)
            {
                if (!stack.ContainsKey(t)) stack[t] = new Stack<GameObject>();
                var o = Object.Instantiate(ori, Vector3.zero, Quaternion.identity);
                o.transform.position = Vector3.zero;
                stack[t].Push(o);
            }
            var r = stack[t].Peek();
            stack[t].Pop();
            r.SetActive(true);
            return r;
        }
        public static GameObject Instantiate(GameObject o, Vector3 v, Quaternion q)
        {
            var r = Instantiate(o);
            r.transform.position = v;
            r.transform.rotation = q;
            return r;
        }
        public static GameObject Instantiate(GameObject o, Transform pr)
        {
            var r = Instantiate(o);
            r.transform.SetParent(pr);
            r.transform.localPosition = Vector3.zero;
            return r;
        }

        public static void Destroy(GameObject o)
        {
            o.GetComponent<YCI>().on_destroy();
            o.SetActive(false);
            stack[o.GetComponent<YCI>().GetType()].Push(o);
        }
    }
}