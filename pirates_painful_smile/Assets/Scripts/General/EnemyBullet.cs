using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : ShipBullet
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(Instantiate(explosionPrefab, transform.position, Quaternion.identity), .3f);
        if (collision.TryGetComponent<PlayerShip>(out PlayerShip hitted_ship))
        {
            hitted_ship.ReceiveDamage(bullet_Damage);
        }
        Destroy(gameObject);
    }
}
