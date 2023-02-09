using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll_Quad : MonoBehaviour
{
    public float x_speed, y_speed;
    public bool use_delta_time;
    Vector2 offset;
    MeshRenderer _renderer;
    private void Awake() {
        _renderer = GetComponent<MeshRenderer>();
        if(!use_delta_time){
            x_speed /= 1000f;
            y_speed /= 1000f;
        }
        
    }
    void Update()
    {
        if(use_delta_time){
            offset.x +=  x_speed * Time.deltaTime;
            offset.y +=  y_speed * Time.deltaTime;
        }else{
            offset.x +=  x_speed;
            offset.y +=  y_speed;
        }
        
        
        _renderer.material.mainTextureOffset = offset;
        
        
    }
}
