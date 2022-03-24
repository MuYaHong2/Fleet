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
    public int stage;

    int healthPoint;
    Score score;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
        score = director.GetComponent<Score>();
    }
    void OnEnable()
    {
        healthPoint = health;
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
        healthPoint -= dmg;
        if (healthPoint <= 0)
        {
            GameObject boom = gener.MakeObj("bomC");
            boom.transform.position = transform.position;
            gameObject.SetActive(false);
            bossClear = true;
            if (gameManager.stage1==true)
            {
                gameManager.stage1 = false;
                gameManager.count = 0;
                gameManager.stage2 = true;
                gameManager.stopG = true;
                gameManager.isBoss = false;
            }
            else if (gameManager.stage1==false)
            {
                gameManager.and();
            }   
        }
    }
}
