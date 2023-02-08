using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{

    public float Hp;
    public float contactDamage;
    public float bulletDamage;
    public float shipSpeed;
    public float rotationSpeed;

    public ShipBullet bulletPrefab;
    public Transform[] sideShotPositions;

    public float timeBetweenNormalShots, timeBetweenSideShots;
    public bool canShot;

    public Transform shipHpBar_Transform;
    public Sprite[] flags, body;
    public ShipSettings shipData;
    public ShipStatus _shipStatus;

    public SpriteRenderer hpBar_Renderer;
    public SpriteRenderer body_Renderer;
    public SpriteRenderer flag_Renderer;

    public bool canReceiveInput;

    public virtual void Start()
    {
        shipHpBar_Transform.transform.SetParent(null);
    }
    public virtual void Update()
    {
        shipHpBar_Transform.position = (Vector2)transform.position + Vector2.up * 3;
        if (Input.GetKeyDown(KeyCode.H))
        {
            ReceiveDamage(10);
        }
    }
    public void ShootBullet()
    {
        if (!canShot)
        {
            return;
        }
        Instantiate(bulletPrefab, sideShotPositions[0].position, Quaternion.identity).SetBulletParam(transform.rotation.eulerAngles, transform, bulletDamage);
        StartCoroutine(ShotCoolDown(timeBetweenNormalShots));
    }
    public void ShootSideBullets()
    {
        if (!canShot)
        {
            return;
        }
        foreach (Transform spawn_point in sideShotPositions)
        {
            Instantiate(bulletPrefab, spawn_point.position, Quaternion.identity).SetBulletParam(transform.rotation.eulerAngles + new Vector3(0, 0, 90f), transform, bulletDamage);
            Instantiate(bulletPrefab, spawn_point.position, Quaternion.identity).SetBulletParam(transform.rotation.eulerAngles + new Vector3(0, 0, -90f), transform, bulletDamage);
        }
        StartCoroutine(ShotCoolDown(timeBetweenSideShots));
    }
    


    public void ReceiveDamage(float dmg_value)
    {
        Hp -= dmg_value;
        if (Hp <= 0)
        {
            Hp = 0;
            canReceiveInput = false;
        }
        _shipStatus.SetShipStatus(Hp);
        
    }

    

    IEnumerator ShotCoolDown(float cooldownTimer)
    {
        canShot = false;
        yield return new WaitForSeconds(cooldownTimer);
        canShot = true;
    }

    IEnumerator SpawnRoutine()
    {
        yield return null;
    }

    IEnumerator DeathRoutine()
    {
        yield return null;
    }
}
