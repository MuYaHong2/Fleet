using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class EnemyShoot : MonoBehaviour
{
    public GameObject enemyBullet;
    public Generator generator;

    float shootTime;


    void Awake()
    {
        generator = FindObjectOfType<Generator>();
    }
    void Update()
    {
        shootTime += Time.deltaTime;
        if (shootTime>=2)
        {
            Fire();
            shootTime = 0;
        }
    }

    void Fire()
    {
        GameObject eBullet = generator.MakeObj("enemyBullet");
        eBullet.transform.position = gameObject.transform.position;
    }
}
