using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipStatus : MonoBehaviour
{
    Ship _ship;
    private void Start()
    {
        _ship = GetComponent<Ship>();
    }

    public void SetShipStatus(float current_hp)
    {
        Color32 hpBar_newColor = _ship.shipData.HealthBarColors[0];
        Sprite new_BodySprite = _ship.body[0];
        Sprite new_FlagSprite = _ship.flags[0];

        _ship.hpBar_Renderer.size = new(current_hp / 100f, 1f);

        if (current_hp < 75f)
        {
            hpBar_newColor = _ship.shipData.HealthBarColors[1];
            new_FlagSprite = _ship.flags[1];
        }
        if (current_hp < 50f)
        {
            hpBar_newColor = _ship.shipData.HealthBarColors[2];
            new_FlagSprite = _ship.flags[2];
            new_BodySprite = _ship.body[1];
        }
        if (current_hp < 25f)
        {
            hpBar_newColor = _ship.shipData.HealthBarColors[3];
            new_FlagSprite = null;
            new_BodySprite = _ship.body[2];
        }

        if (current_hp < 0f)
        {
            _ship.hpBar_Renderer.size = Vector2.up;
        }

        _ship.hpBar_Renderer.color = hpBar_newColor;
        _ship.body_Renderer.sprite = new_BodySprite;
        _ship.flag_Renderer.sprite = new_FlagSprite; 
    }
}
