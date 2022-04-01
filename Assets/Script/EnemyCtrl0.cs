using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCtrl0 : MonoBehaviour
{
    public float speed;
    public int hp;
    public int health;
    public Gauge gauge;
    public scoreCtrl scoreCtrl; 
    public Gamemanager gameManager;
    public Generating generating;
    public Generator generator;
    int scorePoint0;

    //int health;

    Rigidbody2D rigid;
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        gauge = FindObjectOfType<Gauge>();
        scoreCtrl = FindObjectOfType<scoreCtrl>();
        //gameManager = FindObjectOfType<Gamemanager>();
        generator = FindObjectOfType<Generator>();
        generating = FindObjectOfType<Generating>();
        gameManager = FindObjectOfType<Gamemanager>();
    }
    void OnEnable()
    {
        rigid.velocity = Vector2.down * speed;
        health = hp;
        scorePoint0 = hp*100;
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
            GameObject bome = generator.MakeObj("bomB");
            bome.transform.position = transform.position;
            scoreCtrl.scorePoint += scorePoint0;
            generating.count += 1;
            Release();
        }
    }
   

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y<=-6)
        {

            Release();
            gauge.pain += 1;
        }
        if (generating.stopG==true)
        {
            Release();
        }
    }
    void Release()
    {
        gameObject.SetActive(false);
    }
}
