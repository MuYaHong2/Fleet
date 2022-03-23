using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Shot : MonoBehaviour
{
    public GameObject shootPoint;
    public GameObject shootPoint1;
    public Generator generator;

    public int bulletLevel;

    GameObject bullet;

    float shotTime;

    void Awake()
    {
        bulletLevel = 1;
    }
    void Update()
    {
        shotTime += Time.deltaTime;
        if (Input.GetMouseButton(0))
        {
            if (shotTime >= 0.15f)
            {
                Shoot();
            }
            if (bulletLevel>=5)
            {
                bulletLevel = 5;
            }
        }
    }
    void Shoot()
    {
        switch (bulletLevel)
        {
            case 1:
                bullet = generator.MakeObj("playerBullet1");
                bullet.transform.position = gameObject.transform.position;
                shotTime = 0;
                break;
            case 2:
                bullet = generator.MakeObj("playerBullet1");
                bullet.transform.position = shootPoint.transform.position;
                bullet = generator.MakeObj("playerBullet1");
                bullet.transform.position = shootPoint1.transform.position;
                shotTime = 0;
                break;
            case 3:
                bullet = generator.MakeObj("playerBullet2");
                bullet.transform.position = shootPoint1.transform.position;
                shotTime = 0;
                break;
            case 4:
                bullet = generator.MakeObj("playerBullet2");
                bullet.transform.position = shootPoint.transform.position;
                bullet = generator.MakeObj("playerBullet2");
                bullet.transform.position = shootPoint1.transform.position;
                shotTime = 0;
                break;
            case 5:
                bullet = generator.MakeObj("playerBullet3");
                bullet.transform.position = shootPoint1.transform.position;
                shotTime = 0;
                break;
        }
    }
}
