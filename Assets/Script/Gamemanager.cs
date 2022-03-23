using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gamemanager : MonoBehaviour
{
    public string[] enemyObjs;
    public string[] npcObjs;
    public string[] itemObjs;
    public GameObject[] spawnPoint;
    public GameObject boss;
    public int count;
    public bool isBoss;

    float i;
    float j;
    float time;

    public Generator generator;
    // Start is called before the first frame update
    void Start()
    {
        enemyObjs = new string[] { "enemyA", "enemyB", "enemyC" };
        npcObjs = new string[] { "npcA", "npcB", };
        itemObjs = new string[] { "itemA", "itemB", "itemC", "itemD" };
        isBoss = false;
    }

    // Update is called once per frame
    void Update()
    {
        j += Time.deltaTime;
        if (j >= 4)
        {
            SpawnNpc();
            j = 0;
        }
        if (isBoss == false)
        {
            i += Time.deltaTime;
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
        time += Time.deltaTime;

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
        item.transform.position = transform.position;
    }
}
