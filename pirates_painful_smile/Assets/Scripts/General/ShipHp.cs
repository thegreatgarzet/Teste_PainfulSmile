using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipHp : MonoBehaviour
{
    Ship _ship;
    private void Start()
    {
        _ship = GetComponent<Ship>();
    }

    void SetColorAndSprite()
    {
        Color32 hp_bar_new_color = _ship.ShipData.HealthBarColors[0];

        if(_ship.hp_bar_Renderer.size.x < .75)
        {
            hp_bar_new_color = _ship.ShipData.HealthBarColors[1];
            _ship.flag_renderer.sprite = _ship.flags[1];
        }
        if (_ship.hp_bar_Renderer.size.x < .5)
        {
            hp_bar_new_color = _ship.ShipData.HealthBarColors[2];
            _ship.flag_renderer.sprite = _ship.flags[2];
            _ship.ship_renderer.sprite = _ship.body[1];
        }
        if (_ship.hp_bar_Renderer.size.x < .25)
        {
            hp_bar_new_color = _ship.ShipData.HealthBarColors[3];
            _ship.ship_renderer.sprite = _ship.body[2];
            _ship.flag_renderer.sprite = null;
        }
        _ship.hp_bar_Renderer.color = hp_bar_new_color;
    }

    public void UpdateShip(float dmg)
    {
        _ship.hp_bar_Renderer.size = (Vector2.right * dmg)/100f;
        if (_ship.hp_bar_Renderer.size.x <0)
        {
            _ship.hp_bar_Renderer.size = Vector2.up;
        }
        SetColorAndSprite();
    }
}
