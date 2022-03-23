using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCtrl : MonoBehaviour
{
    public float speed;
    public int dmg;

    public Generator generator;

    string n;
    void Start()
    {
        n = gameObject.name;
        generator = FindObjectOfType<Generator>();
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
        else if (collision.gameObject.tag == "enemy" )
        {
            EnemyCtrl0 enemyCtrl = collision.gameObject.GetComponent<EnemyCtrl0>();
            if (enemyCtrl.health>dmg)
            {
                GameObject boom = generator.MakeObj("bomA");
                boom.transform.position = transform.position;
            }
            Release();
        }
        else if (collision.gameObject.tag == "Npc")
        {
            GameObject boom = generator.MakeObj("bomA");
            boom.transform.position = transform.position;
            Release();

        }
        else if (collision.gameObject.tag == "boss")
        {
            GameObject boom = generator.MakeObj("bomA");
            boom.transform.position = transform.position;
            Release();
        }
    }
    void Release()
    {
        gameObject.SetActive(false);
    }
}
