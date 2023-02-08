using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipHp : MonoBehaviour
{
    SpriteRenderer _hp_bar_Renderer;
    SpriteRenderer ship_renderer;
    SpriteRenderer flag_renderer;

    Ship _ship;

    [SerializeField] ShipSettings ShipData;
    private void Start()
    {
        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            ReceiveDamage(10);
        }
        
    }

    void SetColorAndSprite()
    {
        Color32 hp_bar_new_color = ShipData.HealthBarColors[0];

        if(_hp_bar_Renderer.size.x < .75)
        {
            hp_bar_new_color = ShipData.HealthBarColors[1];
            flag_renderer.sprite = _ship.flags[1];
        }
        if (_hp_bar_Renderer.size.x < .5)
        {
            hp_bar_new_color = ShipData.HealthBarColors[2];
            flag_renderer.sprite = _ship.flags[2];
            ship_renderer.sprite = _ship.body[1];
        }
        if (_hp_bar_Renderer.size.x < .25)
        {
            hp_bar_new_color = ShipData.HealthBarColors[3];
            ship_renderer.sprite = _ship.body[2];
            flag_renderer.sprite = null;
        }
        _hp_bar_Renderer.color = hp_bar_new_color;
    }

    public void ReceiveDamage(int dmg)
    {
        _hp_bar_Renderer.size -= (Vector2.right * dmg)/100f;
        print("Teste");
        if (_hp_bar_Renderer.size.x <0)
        {
            _hp_bar_Renderer.size = Vector2.up;
        }
        SetColorAndSprite();
    }
}
