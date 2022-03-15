using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class NpcCtrl : MonoBehaviour
{
    Rigidbody2D rigid;
    public Gauge gauge;
    public Score score;
    public float speed;
    public static IObjectPool<GameObject>[] item; 
    public int hp;
    public int health;
    string n;
    int i;
    // Start is called before the first frame update

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        gauge = FindObjectOfType<Gauge>();
        score = FindObjectOfType<Score>();
        n = gameObject.name;
    }

    void Start()
    {
        item =new IObjectPool<GameObject>[]{ NGenerator.Item0, NGenerator.Item1, NGenerator.Item2, NGenerator.Item3 };
    }
    void OnEnable()
    {
        rigid.velocity = Vector2.down * speed;
        health = hp;
        i = Random.Range(0, 4);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y <= -6)
        {
            Release();
        }
        Debug.Log(n);
        if (score.isClear==true)
        {
            Release();
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
            if (n== "rbc(Clone)")
            {
                gauge.pain += 1;
            }
        }
    }
    void Release()
    {
        switch (n)
        {
            case "leukocyte(Clone)":
                Generator.enemy3.Release(gameObject);
                var j = item[i].Get();
                j.transform.position = transform.position;
                /*switch (i)
                {
                    case 0:
                        var j = NGenerator.Item0.Get();
                        j.transform.position = transform.position;
                        break;
                    case 1:
                        var a = NGenerator.Item1.Get();
                        a.transform.position = transform.position;
                        break;
                    case 2:
                        var b = NGenerator.Item2.Get();
                        b.transform.position = transform.position;
                        break;
                    case 3:
                        var c = NGenerator.Item3.Get();
                        c.transform.position = transform.position;
                        break;
                }*/
                break;
            case "rbc(Clone)":
                Generator.enemy4.Release(gameObject);
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
