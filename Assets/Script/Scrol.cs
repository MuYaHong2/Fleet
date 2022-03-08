using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scrol : MonoBehaviour
{
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    async void Update()
    {
        Vector3 bPos=transform.position;
        Vector3 apos=Vector3.down*speed*Time.deltaTime;
        transform.position=bPos+apos;
        if(transform.position.y<=-6){
            transform.position=new Vector3(0,6,0);
        }
    }
}
