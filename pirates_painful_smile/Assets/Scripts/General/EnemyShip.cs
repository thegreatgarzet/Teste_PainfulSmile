using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShip : Ship
{
    public Transform playerReference;
    public override void CheckHP()
    {
        base.CheckHP();
        if (Hp <= 0)
        {
            manager.AddPoints(1);
        }
    }
}
