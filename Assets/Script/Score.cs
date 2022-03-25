using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Score() { }

    private static Score instance;
    public static Score _Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new GameObject().AddComponent<Score>();
                if (instance == null)
                {
                    Debug.Log("¾øÀ½");
                }
            }
            return instance;
        }
    }


    public int scorePoint;
    
    public float t;
    public bool isClear;
    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != null)
        {
            Debug.Log("destroy");
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
