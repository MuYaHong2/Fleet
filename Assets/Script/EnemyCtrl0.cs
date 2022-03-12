using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCtrl0 : MonoBehaviour
{
    public float speed;
    public int hp;
    public int health;
    string n;

    //int health;

    Rigidbody2D rigid;
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        n = gameObject.name;
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
            Release();
        }
    }
   

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y<=-6)
        {
            Release();
            Debug.Log(n);
        }
    }
    void Release()
    {
        switch (n)
        {
            case "Enemy A(Clone)":
                Genenrator.enemy2.Release(gameObject);
                break;
            case "Enemy B(Clone)":
                Genenrator.enemy1.Release(gameObject);
                break;
            case "Enemy C(Clone)":
                Genenrator.enemy0.Release(gameObject);
                break;
        }
    }
}
