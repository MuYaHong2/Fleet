using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCtrl0 : MonoBehaviour
{
    public float speed;
    public int hp;
    int health;

    //int health;

    Rigidbody2D rigid;
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();

    }
    void OnEnable()
    {
        rigid.velocity = Vector2.down * speed;
        health = hp;
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerBullet")
        {
            BulletCtrl bulletCtrl = collision.gameObject.GetComponent<BulletCtrl>();
            OnHit(bulletCtrl.dmg);
        }
    }
    void OnHit(int dmg)
    {
        health -= dmg;
        if (health <= 0)
        {
            var i = BoomG.boom.Get();
            i.transform.position = transform.position;
            Genenrator.enemy0.Release(gameObject);
        }
    }
   

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y<=-6)
        {
            Genenrator.enemy0.Release(gameObject);
        }

    }
}
