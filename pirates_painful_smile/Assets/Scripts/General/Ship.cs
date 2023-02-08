using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{

    public float shipHp;
    public float shipSpeed;
    public float rotationSpeed;

    public ShipBullet BulletPrefab;
    public Transform[] SideShotPositions;

    public float timeBetweenNormalShots, timeBetweenSideShots;
    public bool canShot;

    public Transform hpBar;
    Sprite[] flags, body;

    private void Start()
    {
        hpBar.transform.SetParent(null);
    }
    public virtual void Update()
    {
        hpBar.position = (Vector2)transform.position + Vector2.up * 3;
    }
    public void ShootBullet()
    {
        if (!canShot)
        {
            return;
        }
        Instantiate(BulletPrefab, SideShotPositions[0].position, Quaternion.identity).SetBulletParam(transform.rotation.eulerAngles);
        StartCoroutine(ShotCoolDown(timeBetweenNormalShots));
    }
    public void ShootSideBullets()
    {
        if (!canShot)
        {
            return;
        }
        foreach (Transform spawn_point in SideShotPositions)
        {
            Instantiate(BulletPrefab, spawn_point.position, Quaternion.identity).SetBulletParam(transform.rotation.eulerAngles + new Vector3(0, 0, 90f));
            Instantiate(BulletPrefab, spawn_point.position, Quaternion.identity).SetBulletParam(transform.rotation.eulerAngles + new Vector3(0, 0, -90f));
        }
        StartCoroutine(ShotCoolDown(timeBetweenSideShots));
    }

    IEnumerator ShotCoolDown(float cooldownTimer)
    {
        canShot = false;
        yield return new WaitForSeconds(cooldownTimer);
        canShot = true;
    }
}
