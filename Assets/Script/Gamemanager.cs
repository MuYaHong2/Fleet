using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Gamemanager : MonoBehaviour
{
    public int score1;
    public int score2;
    public int score3;
    public int score4;
    public int score5;

    public int scoreSave;

    
    public int count;


    
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        
        count = 0;
    }
    void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        



    }

    public void And()
    {
        count = 0;
        Debug.Log(scoreSave);
        
           
        

        SceneManager.LoadScene("GameOver");
    }
    public void start()
    {
        SceneManager.LoadScene("play");
    }

    public void ScorBord()
    {
        if (scoreSave > score5 && scoreSave < score4)
        {
            score5 = scoreSave;
        }
        else if (scoreSave > score4 && scoreSave < score3)
        {
            score5 = score4;
            score4 = scoreSave;
        }
        else if (scoreSave > score3 && scoreSave < score2)
        {
            score5 = score4;
            score4 = score3;
            score3 = scoreSave;
        }
        else if (scoreSave > score2 && scoreSave < score1)
        {
            score5 = score4;
            score4 = score3;
            score3 = score2;
            score2 = scoreSave;
        }
        else if (scoreSave > score1)
        {
            score5 = score4;
            score4 = score3;
            score3 = score2;
            score2 = score1;
            score1 = scoreSave;
        }
    }
}
