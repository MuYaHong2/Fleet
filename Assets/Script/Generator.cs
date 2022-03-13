using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Generator : MonoBehaviour
{
    public static IObjectPool<GameObject> enemy0;
    public static IObjectPool<GameObject> enemy1;
    public static IObjectPool<GameObject> enemy2;
    public static IObjectPool<GameObject> enemy3;
    public static IObjectPool<GameObject> enemy4;

    public EnemyShoot enemyShoot;

    public GameObject prefab0;
    public GameObject prefab1;
    public GameObject prefab2;
    public GameObject prefab3;
    public GameObject prefab4;
    public GameObject Player;
    public GameObject enemy;

    public GameObject [] prefabs;

    float time;
    int p;
    int s;

    // Start is called before the first frame update
    void Start()
    {
        enemyShoot = enemy.GetComponent<EnemyShoot>();
        enemy0 = new ObjectPool<GameObject>(() => { return Instantiate(prefab0, transform.position, transform.rotation); }, (obj) => { obj.SetActive(true); }, (obj) => { obj.SetActive(false); }, (obj) => { Destroy(obj); }, false, 10, 10000);
        enemy1 = new ObjectPool<GameObject>(() => { return Instantiate(prefab1, transform.position, transform.rotation); }, (obj) => { obj.SetActive(true); }, (obj) => { obj.SetActive(false); }, (obj) => { Destroy(obj); }, false, 10, 10000);
        enemy2 = new ObjectPool<GameObject>(() => { return Instantiate(prefab2, transform.position, transform.rotation); }, (obj) => { obj.SetActive(true); }, (obj) => { obj.SetActive(false); }, (obj) => { Destroy(obj); }, false, 10, 10000);
        enemy3 = new ObjectPool<GameObject>(() => { return Instantiate(prefab3, transform.position, transform.rotation); }, (obj) => { obj.SetActive(true); }, (obj) => { obj.SetActive(false); }, (obj) => { Destroy(obj); }, false, 10, 10000);
        enemy4 = new ObjectPool<GameObject>(() => { return Instantiate(prefab4, transform.position, transform.rotation); }, (obj) => { obj.SetActive(true); }, (obj) => { obj.SetActive(false); }, (obj) => { Destroy(obj); }, false, 10, 10000);
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time>=1)
        {
            s = Random.Range(0, 5);
            p = Random.Range(0, 5);
            switch (s)
            {
                case 0:
                    var i = enemy0.Get();
                    i.transform.position = prefabs[p].transform.position;
                    enemyShoot.player = Player;
                    time = 0;
                    break;
                case 1:
                    var j = enemy1.Get();
                    j.transform.position = prefabs[p].transform.position;
                    time = 0;
                    break;
                case 2:
                    var n = enemy2.Get();
                    n.transform.position = prefabs[p].transform.position;
                    break;
                case 3:
                    var a = enemy3.Get();
                    a.transform.position = prefabs[p].transform.position;
                    break;
                case 4:
                    var b = enemy4.Get();
                    b.transform.position = prefabs[p].transform.position;
                    break;
                case 5:
                    break;
            }
            
        }
    }
}
