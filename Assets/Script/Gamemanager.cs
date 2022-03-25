using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Gamemanager : MonoBehaviour
{
    public Gamemanager() { }

    private static Gamemanager instance;
    public static Gamemanager Instance
    {
        get
        {
            if (instance==null)
            {
                instance = new GameObject().AddComponent<Gamemanager>();
                if (instance==null)
                {
                    Debug.Log("¾øÀ½");
                }
            }
            return instance;
        }
    }
    


    public int scoreSave;

    public int score1;
    public int score2;
    public int score3;
    public int score4;
    public int score5;
    public int[] lank;
    public int count;


    public Score score;
    // Start is called before the first frame update
    void Start()
    {
        

        
        score = FindObjectOfType<Score>();
        count = 0;
    }
    void Awake()
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
        lank = new int[] {score1, score2, score3, score4, score5};



    }
    /*void SpawnEnemy()
    {
        int ranEnemy = Random.Range(0, 3);
        int ranPoint = Random.Range(0, 5);
        GameObject enemy = generator.MakeObj(enemyObjs[ranEnemy]);
        enemy.transform.position = spawnPoint[ranPoint].transform.position;
    }

    void SpawnNpc()
    {
        int ranNpc = Random.Range(0, 2);
        int ranPoint1 = Random.Range(0, 5);
        GameObject npc = generator.MakeObj(npcObjs[ranNpc]);
        npc.transform.position = spawnPoint[ranPoint1].transform.position;
    }

    void SpawnItem()
    {

        int ranItem = Random.Range(0, 4);
        int ranPoint2 = Random.Range(0, 5);
        GameObject item = generator.MakeObj(itemObjs[ranItem]);
        item.transform.position = transform.position;
    }*/

    public void And()
    {
        scoreSave = score.scorePoint;
        count = 0;
        Debug.Log(scoreSave);

            if (scoreSave>score1)
            {
                score5 = score4;
                score4 = score3;
                score3 = score2;
                score2 = score1;
                score1 = scoreSave;
            }
            else if (scoreSave > score2)
            {
                score5 = score4;
                score4 = score3;
                score3 = score2;
                score2 = scoreSave;
            }
            else if (scoreSave > score3)
            {
                score5 = score4;
                score4 = score3;
                score3 = scoreSave;
            }
            else if (scoreSave > score4)
            {
                score5 = score4;
                score4 = scoreSave;
            }
            else if (scoreSave > score5)
            {
                score5 = scoreSave;
            }
        

        SceneManager.LoadScene("GameOver");
    }
}
