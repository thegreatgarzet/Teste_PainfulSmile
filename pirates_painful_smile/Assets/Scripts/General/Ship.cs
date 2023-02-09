using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{

    public float Hp;
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
    public Vector2 shipHpBar_Position = new(0,1.6f);

    public GameManager manager;

    public virtual void Start()
    {
        body_Renderer.sprite = body[0];
        flag_Renderer.sprite = flags[0];
        shipHpBar_Transform.transform.SetParent(null);
        shipHpBar_Transform.rotation = Quaternion.Euler(Vector3.zero);
        transform.localScale = Vector2.one * .1f;
        StartCoroutine(SpawnRoutine());
    }
    public virtual void Update()
    {
        if (shipHpBar_Transform != null)
        {
            shipHpBar_Transform.position = (Vector2)transform.position + shipHpBar_Position;
        }
        
    }
    public void ShootBullet()
    {
        if (!canShot)
        {
            return;
        }
        Instantiate(bulletPrefab, sideShotPositions[0].position, Quaternion.identity).transform.rotation = transform.rotation;
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
            Instantiate(bulletPrefab, spawn_point.position, Quaternion.identity).transform.rotation = transform.rotation; ;
            Instantiate(bulletPrefab, spawn_point.position, Quaternion.identity).transform.rotation = transform.rotation;
        }
        StartCoroutine(ShotCoolDown(timeBetweenSideShots));
    }
    public float ReceiveDamage(float dmg_value)
    {
        Hp -= dmg_value;
        if (Hp <= 0)
        {
            Hp = 0;
            canReceiveInput = false;            
        }
        _shipStatus.SetShipStatus(Hp);
        CheckHP();
        return Hp;
    }
    public virtual void CheckHP()
    {
        if (Hp > 0)
        {
            return;
        }
        StopAllCoroutines();
        StartCoroutine(DeathRoutine());
    }
    IEnumerator ShotCoolDown(float cooldownTimer)
    {
        canShot = false;
        yield return new WaitForSeconds(cooldownTimer);
        canShot = true;
    }

    IEnumerator SpawnRoutine()
    {
        while (transform.localScale.magnitude < Vector3.one.magnitude)
        {
            transform.localScale += Vector3.one * Time.deltaTime;
            yield return null;
        }
        canReceiveInput = true;
        yield return null;
    }

    public IEnumerator DeathRoutine()
    {
        GetComponent<Collider2D>().enabled = false;
        canShot = false;
        canReceiveInput = false;
        Destroy(shipHpBar_Transform.gameObject);
        while (transform.localScale.magnitude > (Vector3.one * .1f).magnitude)
        {
            transform.Rotate(new Vector3(0, 0, 360 * Time.deltaTime));
            transform.localScale -= Vector3.one * Time.deltaTime;
            yield return null;
        }
        Destroy(gameObject);
    }
}
