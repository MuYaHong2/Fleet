using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCtrl : MonoBehaviour
{
    public int health;
    public bool bossClear;
    public GameObject director;
    public GameObject[] sponPoint;
    public Generator gener;
    public int stage;
    public bool clear;
    Score score;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
        score = director.GetComponent<Score>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag=="PlayerBullet")
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
            GameObject boom = gener.MakeObj("bomC");
            boom.transform.position = transform.position;
            gameObject.SetActive(false);
            bossClear = true;
        }
           
    }
}
