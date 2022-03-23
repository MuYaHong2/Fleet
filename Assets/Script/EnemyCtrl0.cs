using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCtrl0 : MonoBehaviour
{
    public float speed;
    public int hp;
    public int health;
    string n;
    public Gauge gauge;
    public Score score;
    public Gamemanager gameManager;
    public Generator generator;
    int scorePoint0;

    //int health;

    Rigidbody2D rigid;
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        n = gameObject.name;
        gauge = FindObjectOfType<Gauge>();
        score = FindObjectOfType<Score>();
        gameManager = FindObjectOfType<Gamemanager>();
        generator = FindObjectOfType<Generator>();
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
            score.scorePoint += scorePoint0;
            gameManager.count += 1;
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
        
    }
    void Release()
    {
        gameObject.SetActive(false);
    }
}
