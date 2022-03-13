using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCtrl : MonoBehaviour
{
    public float speed;
    public int dmg;
    string n;
    void Start()
    {
        n = gameObject.name;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0, speed, 0) * Time.deltaTime;
    }
    void OnEnable()
    {

    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "MaxBullet")
        {
            Release();
        }
        else if (collision.gameObject.tag == "enemy" || collision.gameObject.tag == "Npc")
        {
            EnemyCtrl0 enemyCtrl = collision.gameObject.GetComponent<EnemyCtrl0>();
            if (enemyCtrl.health>dmg)
            {
                var i = BoomG.boom1.Get();
                i.transform.position = transform.position;
            }
            Release();
        }
    }
    void Release()
    {
        switch (n)
        {
            case "Player Bullet 0(Clone)":
                Shot.bullet1.Release(gameObject);
                break;
            case "Player Bullet 1(Clone)":
                Shot.bullet.Release(gameObject);
                break;
            case "Follower Bullet(Clone)":
                Shot.bullet2.Release(gameObject);
                break;
        }
    }
}
