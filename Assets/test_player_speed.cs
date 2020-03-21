using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test_player_speed : MonoBehaviour
{
    public void up()
    {
        Player.main.speed += 1;
    }
    public void down()
    {
        Player.main.speed -= 1;
    }
    public void send_speed()
    {
        TCP_Master.Inst.Send(Player.main);
    }
}
