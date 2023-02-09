using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaserShip : EnemyShip
{
    
    public override void Start()
    {
        body = shipData.ship_body;
        flags = shipData.chaser_flags;
        base.Start();
        
    }
    public override void Update()
    {
        base.Update();
        if (!canReceiveInput)
        {
            return;
        }
        Vector3 dir = playerReference.transform.position - transform.position; float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * rotationSpeed);

        transform.Translate(Vector2.right * Time.deltaTime * shipSpeed);
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<PlayerShip>(out PlayerShip hitted_ship))
        {
            hitted_ship.ReceiveDamage(bulletDamage);
            StartCoroutine(DeathRoutine());
        }
    }
}
