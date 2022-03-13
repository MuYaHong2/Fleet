using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class NGenerator : MonoBehaviour
{
    public static IObjectPool<GameObject> Item0;
    public static IObjectPool<GameObject> Item1;
    public static IObjectPool<GameObject> Item2;
    public static IObjectPool<GameObject> Item3;

    public GameObject prefab0;
    public GameObject prefab1;
    public GameObject prefab2;
    public GameObject prefab3;

    // Start is called before the first frame update
    void Start()
    {
        Item0 = new ObjectPool<GameObject>(() => { return Instantiate(prefab0, transform.position, transform.rotation); }, (obj) => { obj.SetActive(true); }, (obj) => { obj.SetActive(false); }, (obj) => { Destroy(obj); }, false, 10, 10000);
        Item1 = new ObjectPool<GameObject>(() => { return Instantiate(prefab1, transform.position, transform.rotation); }, (obj) => { obj.SetActive(true); }, (obj) => { obj.SetActive(false); }, (obj) => { Destroy(obj); }, false, 10, 10000);
        Item2 = new ObjectPool<GameObject>(() => { return Instantiate(prefab2, transform.position, transform.rotation); }, (obj) => { obj.SetActive(true); }, (obj) => { obj.SetActive(false); }, (obj) => { Destroy(obj); }, false, 10, 10000);
        Item3 = new ObjectPool<GameObject>(() => { return Instantiate(prefab3, transform.position, transform.rotation); }, (obj) => { obj.SetActive(true); }, (obj) => { obj.SetActive(false); }, (obj) => { Destroy(obj); }, false, 10, 10000);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
