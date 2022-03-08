using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Shot : MonoBehaviour
{
    public static IObjectPool<GameObject> bullet;
    public GameObject prefab;

    float shotTime;
    // Start is called bdefore the first frame update
    void Awake()
    {
        bullet=new ObjectPool<GameObject>(() => {return Instantiate(prefab, transform.position, transform.rotation);},(obj) => {obj.SetActive(true);}, (obj)=>{obj.SetActive(false);}, (obj) => {Destroy(obj);}, false, 20, 10000);
    }

    // Update is called once per frame
    void Update()
    {
        shotTime += Time.deltaTime;
        if (Input.GetMouseButton(0))
        {
            if (shotTime >= 0.27f)
            {
                var i = Shot.bullet.Get();
                i.transform.position = transform.position;
                shotTime = 0;
            }

        }
    }
}
