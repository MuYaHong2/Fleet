using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Genenrator : MonoBehaviour
{
    public static IObjectPool<GameObject> enemy0;
    public GameObject prefab0;
    // Start is called before the first frame update
    void Start()
    {
        enemy0 = new ObjectPool<GameObject>(() => { return Instantiate(prefab0, transform.position, transform.rotation); }, (obj) => { obj.SetActive(true); }, (obj) => { obj.SetActive(false); }, (obj) => { Destroy(obj); }, false, 10, 100);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
