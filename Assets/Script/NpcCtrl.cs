using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class NpcCtrl : MonoBehaviour
{
    Rigidbody2D rigid;
    public Gauge gauge;
    public scoreCtrl score;
    public Generator generator;
    public float speed;
    public static IObjectPool<GameObject>[] item; 
    public int hp;
    public int health;
    public string[] itemObjs;

    string n;
    int i;
    // Start is called before the first frame update

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        gauge = FindObjectOfType<Gauge>();
        score = FindObjectOfType<scoreCtrl>();
        generator = FindObjectOfType<Generator>();
        n = gameObject.name;
    }

    void Start()
    {
        itemObjs = new string[] { "itemA", "itemB", "itemC", "itemD" };

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
            gameObject.SetActive(false);
        }
        Debug.Log(n);
        if (score.isClear==true)
        {
            gameObject.SetActive(false);
        }
    }
    void OnHit(int dmg)
    {
        health -= dmg;
        if (health <= 0)
        {
            GameObject bome = generator.MakeObj("bomB");
            bome.transform.position = transform.position; 
            Release();
        }
    }
    void Release()
    {
        switch (n)
        {
            case "leukocyte(Clone)":
                Debug.Log("dfjldsf");
                GameObject item = generator.MakeObj(itemObjs[i]);
                item.transform.position = transform.position;
                gameObject.SetActive(false);
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
                gauge.pain += 1;
                gameObject.SetActive(false);
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
