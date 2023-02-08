using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipHp : MonoBehaviour
{
    SpriteRenderer _hpRenderer;
    [SerializeField] ShipHealthColor HealthBarColorData;
    private void Start()
    {
        _hpRenderer = GetComponentsInChildren<SpriteRenderer>()[1];
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            ReceiveDamage(10);
        }
        
    }

    void SetHealthBarColor()
    {
        Color32 new_color = HealthBarColorData.HealthBarColors[0];

        if(_hpRenderer.size.x < .75)
        {
            new_color = HealthBarColorData.HealthBarColors[1];
        }
        if (_hpRenderer.size.x < .5)
        {
            new_color = HealthBarColorData.HealthBarColors[2];
        }
        if (_hpRenderer.size.x < .25)
        {
            new_color = HealthBarColorData.HealthBarColors[3];
        }
        _hpRenderer.color = new_color;
    }

    public void ReceiveDamage(int dmg)
    {
        _hpRenderer.size -= (Vector2.right * dmg)/100f;
        print("Teste");
        if (_hpRenderer.size.x <0)
        {
            _hpRenderer.size = Vector2.up;
        }
        SetHealthBarColor();
    }
}
