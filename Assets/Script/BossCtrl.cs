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
    public Gamemanager gameManager;
    public Generating generating;
    public int stage;

    int healthPoint;
    Score score;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
        score = director.GetComponent<Score>();
        gameManager = FindObjectOfType<Gamemanager>();
    }
    void OnEnable()
    {
        healthPoint = health;
    }

    // Update is called once per frame

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
        healthPoint -= dmg;
        if (healthPoint <= 0)
        {
            score.scorePoint += 10000;
            GameObject boom = gener.MakeObj("bomC");
            boom.transform.position = transform.position;
            gameObject.SetActive(false);
            bossClear = true;
            if (generating.stage1==true)
            {
                generating. stage1 = false;
                Gamemanager.Instance.count = 0;
                generating.stage2 = true;
                generating.stopG = true;
                generating.isBoss = false;
            }
            else if (generating.stage1==false)
            {
                Gamemanager.Instance.count = 0;
                gameManager.And();
            }   
        }
    }
}
