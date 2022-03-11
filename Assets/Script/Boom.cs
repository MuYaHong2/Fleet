using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boom : MonoBehaviour
{


    float pt;
    // Start is called before the first frame update
    void OnEnable()
    {
        pt = 0;
    }

    public void r()
    {
        BoomG.boom.Release(gameObject);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
