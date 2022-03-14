using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Shot : MonoBehaviour
{
    public static IObjectPool<GameObject> bullet;
    public static IObjectPool<GameObject> bullet1;
    public static IObjectPool<GameObject> bullet2;
    public int bulletLevel;

    public GameObject prefab;
    public GameObject prefab1;
    public GameObject prefab2;
    public GameObject shootPoint;
    public GameObject shootPoint1;

    float shotTime;

    void Awake()
    {
        bulletLevel = 1;
        bullet = new ObjectPool<GameObject>(() => { return Instantiate(prefab, transform.position, transform.rotation); }, (obj) => { obj.SetActive(true); }, (obj) => { obj.SetActive(false); }, (obj) => { Destroy(obj); }, false, 20, 10000);
        bullet1 = new ObjectPool<GameObject>(() => { return Instantiate(prefab1, transform.position, transform.rotation); }, (obj) => { obj.SetActive(true); }, (obj) => { obj.SetActive(false); }, (obj) => { Destroy(obj); }, false, 20, 10000);
        bullet2 = new ObjectPool<GameObject>(() => { return Instantiate(prefab2, transform.position, transform.rotation); }, (obj) => { obj.SetActive(true); }, (obj) => { obj.SetActive(false); }, (obj) => { Destroy(obj); }, false, 20, 10000);
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
                var i = bullet1.Get();
                i.transform.position = transform.position;
                shotTime = 0;
                break;
            case 2:
                var j = bullet1.Get();
                j.transform.position = shootPoint.transform.position;
                var a = bullet1.Get();
                a.transform.position = shootPoint1.transform.position;
                shotTime = 0;
                break;
            case 3:
                var b = bullet.Get();
                b.transform.position = gameObject.transform.position;
                shotTime = 0;
                break;
            case 4:
                var c = bullet.Get();
                c.transform.position = shootPoint.transform.position;
                var d = bullet.Get();
                d.transform.position = shootPoint1.transform.position;
                shotTime = 0;
                break;
            case 5:
                var e = bullet2.Get();
                e.transform.position = gameObject.transform.position;
                shotTime = 0;
                break;
        }
    }
}
