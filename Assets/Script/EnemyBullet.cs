using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    Rigidbody2D rigid;
    EnemyShoot enemyShoot;
    public GameObject player;
    public int speed;
    Vector3 dir;
    // Start is called before the first frame update
    void Start()
    {
        enemyShoot = FindObjectOfType<EnemyShoot>();
        
    }
    void OnEnable()
    {
        dir = player.transform.position - transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += dir * speed * Time.deltaTime;
    }
}
