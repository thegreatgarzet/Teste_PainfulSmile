using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipBullet : MonoBehaviour
{
    public GameObject explosionPrefab, smokePrefab;

    public float bullet_Movespeed;
    public float bullet_Damage;
    public string collision_Tag;

    private void Start()
    {
        Destroy(Instantiate(smokePrefab, transform.position, Quaternion.identity), .3f);
    }

    private void Update()
    {
        transform.Translate(Vector2.right * Time.deltaTime * bullet_Movespeed);
    }
    
}
