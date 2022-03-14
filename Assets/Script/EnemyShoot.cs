using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class EnemyShoot : MonoBehaviour
{
    public GameObject enemyBullet;

    float shootTime;

    // Update is called once per frame
    void Update()
    {
        shootTime += Time.deltaTime;
        if (shootTime>=2)
        {
            Fire();
        }
    }

    void Fire()
    {
        var i = Generator.EnemyBullet.Get();
        i.transform.position = transform.position;
        shootTime = 0;
    }
}
