using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCtrl : MonoBehaviour
{
public float speed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0,speed,0)*Time.deltaTime;
    }
    void OnEnavle()
    {

    }
    void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.tag == "Finish"){
            Shot.bullet.Release(gameObject);
            
            //Destroy(gameObject);
        }

    }
}
