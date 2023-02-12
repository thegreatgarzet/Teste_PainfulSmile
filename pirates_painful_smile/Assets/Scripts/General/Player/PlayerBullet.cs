using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : ShipBullet
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(collision_Tag) && collision.TryGetComponent<EnemyShip>(out EnemyShip hitted_ship))
        {
            Destroy(Instantiate(explosionPrefab, transform.position, Quaternion.identity), .3f);
            hitted_ship.ReceiveDamage(bullet_Damage);
            Destroy(gameObject);
        }
    }
}
