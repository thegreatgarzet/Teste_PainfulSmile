using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShip : Ship
{
    public override void Start()
    {
        body = shipData.ship_body;
        flags = shipData.player_flags;
        base.Start();
    }

    public override void Update()
    {
        PlayerMovement();
        PlayerAttackInputs();
        base.Update();
    }

    Vector2 GetPlayerInput()
    {
        if (!canReceiveInput)
        {
            return Vector2.zero;
        }
        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        if(input.y < 0)
        {
            input.y = 0;
        }

        return input;
    }

    void PlayerMovement()
    {
        Vector2 playerInput = GetPlayerInput();
        transform.Rotate(new Vector3(0, 0, rotationSpeed * -playerInput.x * Time.deltaTime));
        transform.Translate(Vector2.right * playerInput.y * Time.deltaTime * shipSpeed);
    }

    void PlayerAttackInputs()
    {
        if (canShot)
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                ShootBullet();
            }
            if (Input.GetKeyDown(KeyCode.X))
            {
                ShootSideBullets();
            }
        }
        
    }
}
