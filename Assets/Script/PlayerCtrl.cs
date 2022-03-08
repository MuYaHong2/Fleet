using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    public float speed;
    public Animator anim;

    float shotTime;

    async void Update()
    {  
        shotTime+=Time.deltaTime;
        var t=transform.position;
        var hInput = Input.GetAxisRaw("Horizontal");
        var vInput = Input.GetAxisRaw("Vertical");
        transform.position += new Vector3(hInput, vInput, 0).normalized * speed * Time.deltaTime;
        anim.SetFloat("Side",hInput);

        if(Input.GetMouseButton(0))
        {
            if(shotTime>=0.2f){
                var i = Shot.bullet.Get();
                i.transform.position=transform.position;
                shotTime=0;
            }
            
        }
    
    }
}
