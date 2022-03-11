using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCtrl : MonoBehaviour
{
    public float speed;
    public int dmg;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0,speed,0)*Time.deltaTime;
    }
    void OnEnable()
    {

    }
    void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.name == "MaxBullet"||collision.gameObject.tag=="enemy")
        {
            Shot.bullet.Release(gameObject);
        }


    }
}
