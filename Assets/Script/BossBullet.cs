using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBullet : MonoBehaviour
{
    public int speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        if (transform.position.y <= -6)
        {

            Generator.BossBullet.Release(gameObject);

        }
       
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            var i = BoomG.boom1.Get();
            i.transform.position = transform.position;
            Generator.BossBullet.Release(gameObject);
        }
    }
}
