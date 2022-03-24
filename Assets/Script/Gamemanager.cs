using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gamemanager : MonoBehaviour
{
    public string[] enemyObjs;
    public string[] npcObjs;
    public string[] itemObjs;
    public GameObject[] spawnPoint;
    public GameObject boss;
    public int count;
    public bool isBoss;
    public bool stage1;
    public bool stage2;
    public bool clear;
    public bool stopG;
    public int scoreSave;
    public int[] lank;

    float i;
    float j;
    float time;
    float sTime;



    public Generator generator;
    public Score score;
    // Start is called before the first frame update
    void Start()
    {
        enemyObjs = new string[] { "enemyA", "enemyB", "enemyC" };
        npcObjs = new string[] { "npcA", "npcB", };
        itemObjs = new string[] { "itemA", "itemB", "itemC", "itemD" };

        isBoss = false;
        stage1 = true;
        stage2 = false;
    }

    // Update is called once per frame
    void Update()
    {
        Scene scene = SceneManager.GetActiveScene();
        j += Time.deltaTime;
        time += Time.deltaTime;
        i += Time.deltaTime;
        if (stage2 == true)
        {
            sTime += Time.deltaTime;
        }
        if (stopG == true)
        {
            sTime += Time.deltaTime;
            if (sTime >= 5)
            {
                stopG = false;
            }
        }
        if (scene.name == "play")
        {
            if (stopG == false)
            {
                if (j >= 4)
                {
                    SpawnNpc();
                    j = 0;
                }
                if (isBoss == false)
                {
                    if (i >= 3)
                    {
                        SpawnEnemy();
                        i = 0;
                    }
                }
                if (count >= 1)
                {
                    boss.SetActive(true);
                    isBoss = true;
                }
                if (time >= 6)
                {
                    SpawnItem();
                    time = 0;
                }
            }
        }



    }
    void SpawnEnemy()
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
    }

    public void and()
    {
        scoreSave = score.scorePoint;
        Debug.Log(scoreSave);
        for (int s = 0; s < lank.Length; s++)
        {
            if (scoreSave > lank[s])
            {
                lank[s] = scoreSave;
            }
        }
        SceneManager.LoadScene("GameOver");
    }
}
