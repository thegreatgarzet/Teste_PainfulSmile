using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipBullet : MonoBehaviour
{
    
    public float bullet_Movespeed;
    public float bullet_Damage;
    public GameObject explosionPrefab;
    public Transform creator;
    
    public void SetBulletParam(Vector3 rot, Transform bullet_creator, float damage)
    {
        transform.rotation = Quaternion.Euler(rot);
        creator = bullet_creator;
        bullet_Damage = damage;
    }
    private void Update()
    {
        transform.Translate(Vector2.right * Time.deltaTime * bullet_Movespeed);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstacle") && collision.transform != creator)
        {

            Destroy(Instantiate(explosionPrefab, transform.position, Quaternion.identity), .3f);
            
            if (collision.TryGetComponent<Ship>(out Ship hitted_ship))
            {
                
                hitted_ship.ReceiveDamage(bullet_Damage);
                
            }
            Destroy(gameObject);
        }
    }
}
