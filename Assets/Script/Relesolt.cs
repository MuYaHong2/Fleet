using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Relesolt : MonoBehaviour
{
    public GameObject scorBord1;
    public GameObject scorBord2;
    public GameObject scorBord3;
    public GameObject scorBord4;
    public GameObject scorBord5;
    Text scoreBord1;
    Text scoreBord2;
    Text scoreBord3;
    Text scoreBord4;
    Text scoreBord5;
    private Gamemanager gamemanager;
 
    int[] scores;
    int[] rank;
    // Start is called before the first frame update
    void Start()
    {
        gamemanager = FindObjectOfType<Gamemanager>();
        scoreBord1 = scorBord1.GetComponent<Text>();
        scoreBord2 = scorBord2.GetComponent<Text>();
        scoreBord3 = scorBord3.GetComponent<Text>();
        scoreBord4 = scorBord4.GetComponent<Text>();
        scoreBord5 = scorBord5.GetComponent<Text>();
        Debug.Log(gamemanager.scoreSave);
        Debug.Log(gamemanager.score1);
        Debug.Log(gamemanager.score2);
        Debug.Log(gamemanager.score3);
        Debug.Log(gamemanager.score4);
        Debug.Log(gamemanager.score5);
        gamemanager.ScorBord();
    }

    // Update is called once per frame
    void Update()
    {
        scoreBord1.text = gamemanager.score1.ToString();
        scoreBord2.text = gamemanager.score2.ToString();
        scoreBord3.text = gamemanager.score3.ToString();
        scoreBord4.text = gamemanager.score4.ToString();
        scoreBord5.text = gamemanager.score5.ToString();
    }
    public void ReStart()
    {
        SceneManager.LoadScene("play");
    }

   
}

