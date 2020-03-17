using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YC;

public class Player : MonoBehaviour
{
    void Start()
    {
        ioev.Signal((player_t t) =>
        {
            transform.position = new Vector3(t.pos.x, transform.position.y, t.pos.y);
        });
    }
}
