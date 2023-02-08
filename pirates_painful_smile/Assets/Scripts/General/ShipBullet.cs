using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipBullet : MonoBehaviour
{
    
    public float bullet_Movespeed;
    
    public void SetBulletParam(Vector3 rot)
    {
        transform.rotation = Quaternion.Euler(rot);

        //moves using forward
    }
    private void Update()
    {
        transform.Translate(Vector2.right * Time.deltaTime * bullet_Movespeed);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //toca animação de explosão
            //causa dano
        }
    }
}
