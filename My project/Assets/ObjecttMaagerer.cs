using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjecttMaagerer : MonoBehaviour
{
    public GameObject prefab;
    GameObject[] cube;

    private void Awake()
    {
        cube = new GameObject[10];

        Generate();
    }

    void Generate()
    {
        for (int i = 0; i < cube.Length; i++)
        {
            cube[i]=Instantiate(prefab);
            cube[i].SetActive(true);
            cube[i].transform.position = new Vector3(Random.Range(0, 11), Random.Range(0, 11), 0);
        }
    }

}
