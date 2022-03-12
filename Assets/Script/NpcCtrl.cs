using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcCtrl : MonoBehaviour
{
    Rigidbody2D rigid;
    public float speed;
    public int hp;
    public int health;
    string n;
    // Start is called before the first frame update

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

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y <= -6)
        {
            Release();
        }
        Debug.Log(n);
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
    void Release()
    {
        switch (n)
        {
            case "leukocyte(Clone)":
                Genenrator.enemy3.Release(gameObject);
                break;
            case "rbc(Clone)":
                Genenrator.enemy4.Release(gameObject);
                break;
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
}
