using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Relesolt : MonoBehaviour
{
    private Gamemanager gamemanager;
    int score1;
    int score2;
    int score3;
    int score4;
    int score5;
    int[] scores;
    int[] rank;
    // Start is called before the first frame update
    void Start()
    {
        gamemanager = FindObjectOfType<Gamemanager>();

        
        for (int i = 0; i < 5; i++)
        {
            if (gamemanager.scoreSave>scores[i])
            {
                for (int j = 0; j < i; j++)
                {

                }
                scores[i] = gamemanager.scoreSave;
                Debug.Log(scores[0]);
                Debug.Log(score1);
            }
        }

        
        Debug.Log(gamemanager.scoreSave);
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void ReStart()
    {
        SceneManager.LoadScene("play");
    }
    
}

