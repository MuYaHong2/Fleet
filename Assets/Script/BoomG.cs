using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class BoomG : MonoBehaviour
{
    public static IObjectPool<GameObject> boom;
    public GameObject prefab;
    // Start is called before the first frame update
    void Start()
    {
        boom = new ObjectPool<GameObject>(() => { return Instantiate(prefab, transform.position, transform.rotation); }, (obj) => { obj.SetActive(true); }, (obj) => { obj.SetActive(false); }, (obj) => { Destroy(obj); }, false, 20, 10000);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
