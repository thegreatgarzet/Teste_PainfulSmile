using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipBullet : MonoBehaviour
{
    
    public float bullet_Movespeed;
    public float bullet_Damage;
    public GameObject explosionPrefab;
    public string collision_Tag;


    private void Start()
    {
        Destroy(gameObject, 3f);
    }
    private void Update()
    {
        transform.Translate(Vector2.right * Time.deltaTime * bullet_Movespeed);
    }
    
}
