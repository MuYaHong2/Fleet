using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    public float speed;
    public Animator anim;
    public int health;

    
    float side;
    float updown;

    void Update()
    {  
        
        var t=transform.position;
        var hInput = Input.GetAxisRaw("Horizontal");
        //var vInput = Input.GetAxisRaw("Vertical");
        if (Input.GetKey(KeyCode.A))
        {
           side -= speed * 0.7f * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            side += speed * 0.7f * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            updown -= speed * 0.7f * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.W))
        {
            updown += speed* 0.7f * Time.deltaTime;
        }
        side = Mathf.Clamp(side, -10, 10);
        updown = Mathf.Clamp(updown, -10, 10);
        Vector3 curPos = transform.position;
        Vector3 nextPosY = Vector3.up * updown * Time.deltaTime;
        Vector3 nextPosX = Vector3.right * side * Time.deltaTime;
        transform.position = curPos + nextPosX + nextPosY;
        //transform.position += new Vector3(side, updown, 0)* Time.deltaTime;
        anim.SetFloat("Side",hInput);

        
    
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "enemy")
        {
            health -= 5;
        }
    }
}
