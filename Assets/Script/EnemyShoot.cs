using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class EnemyShoot : MonoBehaviour
{
    public static IObjectPool<GameObject> EnemyBullet;
    public GameObject player;
    public Vector2 aiming;
    public GameObject enemyBullet;
    public EnemyBullet enemyBullet0;

    float shootTime;
    // Start is called before the first frame update
    void Start()
    {
        enemyBullet0 = FindObjectOfType<EnemyBullet>();
        EnemyBullet = new ObjectPool<GameObject>(() => { return Instantiate(enemyBullet, transform.position, transform.rotation); }, (obj) => { obj.SetActive(true); }, (obj) => { obj.SetActive(false); }, (obj) => { Destroy(obj); }, false, 10, 10000);
    }

    // Update is called once per frame
    void Update()
    {
        shootTime += Time.deltaTime;
        if (shootTime>=2)
        {
            //Vector2 aiming = player.transform.position - transform.position;
            Fire();
        }
        Debug.Log(player);
    }
    void Fire()
    {
        enemyBullet0.player = player;
        var i = EnemyBullet.Get();
        i.transform.position = transform.position;
        shootTime = 0;
    }
}
