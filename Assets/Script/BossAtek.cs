using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAtek : MonoBehaviour
{
    public GameObject player;
    public Generator generator;
    float aTime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 len = player.transform.position - transform.position;
        float z = Mathf.Atan2(len.y, len.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, z);
        aTime += Time.deltaTime;
        if (aTime>=1.5f)
        {
            GameObject bullet = generator.MakeObj("bossBullet");
            bullet.transform.position = gameObject.transform.position;
            bullet.transform.rotation = gameObject.transform.rotation;
            aTime = 0;
        }
    }
}
