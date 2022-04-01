using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Generating : MonoBehaviour
{
    public string[] enemyObjs;
    public string[] npcObjs;
    public string[] itemObjs;
    public GameObject[] spawnPoint;
    
    public Generator generator;
    public Gamemanager gamemanager;
    public GameObject boss;

    public bool isBoss;
    public bool stage1;
    public bool stage2;
    public bool clear;
    public bool stopG;

    public int count;

    float i;
    float j;
    float time;
    float sTime;
    // Start is called before the first frame update
    void Start()
    {
        enemyObjs = new string[] { "enemyA", "enemyB", "enemyC" };
        npcObjs = new string[] { "npcA", "npcB", };
        itemObjs = new string[] { "itemA", "itemB", "itemC", "itemD" };
        gamemanager = FindObjectOfType<Gamemanager>();

        isBoss = false;
        stage1 = true;
        stage2 = false;
    }

    // Update is called once per frame
    void Update()
    {
        j += Time.deltaTime;
        time += Time.deltaTime;
        i += Time.deltaTime;
        if (stage2 == true)
        {
            sTime += Time.deltaTime;
        }
        /*if (stopG == true)
        {
            sTime += Time.deltaTime;
            if (sTime >= 5)
            {
                stopG = false;
            }
        }*/

        
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
            if (count >= 10)
            {
                boss.SetActive(true);
                isBoss = true;
            }
            else
            {
                isBoss=false;
            }
            if (time >= 6)
            {
                SpawnItem();
                time = 0;
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
        item.transform.position = spawnPoint[ranPoint2].transform.position;
    }
    public IEnumerator Fade1()
    {
        yield return new WaitForSeconds(2);
        yield return null;
        
    }
}
