using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCtrl0 : MonoBehaviour
{
    public float speed;
    public int health;

    SpriteRenderer spriteRenderer;
    Rigidbody2D rigid;
    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rigid = GetComponent<Rigidbody2D>();
        rigid.velocity = Vector2.down * speed;
    }
    void OnHit(int dmg)
    {
        health -= dmg;
            
        if (health <= 0)
        {
            Genenrator.enemy0.Release(gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerBullet")
        {
            BulletCtrl bulletCtrl = collision.gameObject.GetComponent<BulletCtrl>();
            OnHit(bulletCtrl.dmg);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
