using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    Rigidbody2D rigid;
    public int speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void OnEnable()
    {
        rigid = GetComponent<Rigidbody2D>();
        rigid.velocity = Vector2.down * speed;
    }
    // Update is called once per frame
    void Update()
    {
        if (transform.position.y <= -6)
        {
            Generator.EnemyBullet.Release(gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name=="Player")
        {
            var i = BoomG.boom1.Get();
            i.transform.position = transform.position;
            Generator.EnemyBullet.Release(gameObject);
        }
    }
}
