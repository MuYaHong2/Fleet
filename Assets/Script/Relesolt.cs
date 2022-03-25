using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Relesolt : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("1등"+Gamemanager.Instance.score1);
        Debug.Log("2등"+Gamemanager.Instance.score2);
        Debug.Log("3등"+Gamemanager.Instance.score3);
        Debug.Log("4등"+Gamemanager.Instance.score4);
        Debug.Log("5등"+Gamemanager.Instance.score5);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
