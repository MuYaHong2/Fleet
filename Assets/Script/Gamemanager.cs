using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Gamemanager : MonoBehaviour
{



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
        count = 0;
        Debug.Log(scoreSave);

           
        

        SceneManager.LoadScene("GameOver");
    }
    public void start()
    {
        SceneManager.LoadScene("play");
    }
}
