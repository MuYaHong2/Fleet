using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class BoomG : MonoBehaviour
{
    public static IObjectPool<GameObject> boom;
    public static IObjectPool<GameObject> boom1;
    public static IObjectPool<GameObject> boom2;
    public GameObject prefab;
    public GameObject prefab1;
    public GameObject prefab2;
    // Start is called before the first frame update
    void Start()
    {
        boom = new ObjectPool<GameObject>(() => { return Instantiate(prefab, transform.position, transform.rotation); }, (obj) => { obj.SetActive(true); }, (obj) => { obj.SetActive(false); }, (obj) => { Destroy(obj); }, false, 20, 10000);
        boom1 = new ObjectPool<GameObject>(() => { return Instantiate(prefab1, transform.position, transform.rotation); }, (obj) => { obj.SetActive(true); }, (obj) => { obj.SetActive(false); }, (obj) => { Destroy(obj); }, false, 20, 10000);
        boom2 = new ObjectPool<GameObject>(() => { return Instantiate(prefab2, transform.position, transform.rotation); }, (obj) => { obj.SetActive(true); }, (obj) => { obj.SetActive(false); }, (obj) => { Destroy(obj); }, false, 20, 10000);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
