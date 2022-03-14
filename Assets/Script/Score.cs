using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public int scorePoint;
    public GameObject score;
    // Start is called before the first frame update
    void Start()
    {
        scorePoint = 0;
    }

    // Update is called once per frame
    void Update()
    {
        score.GetComponent<Text>().text = scorePoint.ToString("D7");
    }
}
