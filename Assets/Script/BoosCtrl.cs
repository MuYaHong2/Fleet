using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoosCtrl : MonoBehaviour
{
    public int health;
    public bool bossCliear;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
        bossCliear = false;
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
            var i = BoomG.boom2.Get();
            i.transform.position = transform.position;
            Destroy(gameObject);
            bossCliear = true;
        }
    }
}
