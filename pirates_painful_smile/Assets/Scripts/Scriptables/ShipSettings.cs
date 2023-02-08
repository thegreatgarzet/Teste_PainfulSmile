using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ShipSettings : ScriptableObject
{
    [Header("Colors for health bar")]
    public Color[] HealthBarColors;

    [Header("Ship parts")]
    public Sprite[] ship_body;

    public Sprite[] shooter_flags;

    public Sprite[] chaser_flags;

    public Sprite[] player_flags;
}
