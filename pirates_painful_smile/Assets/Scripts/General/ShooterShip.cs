using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterShip : EnemyShip
{
    public Transform player;
    public float raycastDistance;
    public LayerMask layerMask;
    public override void Start()
    {
        body = shipData.ship_body;
        flags = shipData.shooter_flags;
        base.Start();
    }

    public override void Update()
    {
        base.Update();
        if (!canReceiveInput)
        {
            return;
        }
        CheckPlayerNearby();
    }

    void CheckPlayerNearby()
    {
        if (Physics2D.Raycast(sideShotPositions[0].position, transform.right, raycastDistance, layerMask))
        {
            ShootBullet();
            return;
        }
        
        if (Physics2D.Raycast(sideShotPositions[1].position, transform.up, raycastDistance, layerMask) || Physics2D.Raycast(sideShotPositions[1].position, -transform.up, raycastDistance, layerMask))
        {
            ShootSideBullets();
            return;
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(sideShotPositions[0].position, transform.right * raycastDistance);
        Gizmos.DrawRay(sideShotPositions[1].position, transform.up * raycastDistance);
        Gizmos.DrawRay(sideShotPositions[1].position, -transform.up * raycastDistance);
    }
}
