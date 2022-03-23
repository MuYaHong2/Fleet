using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Generator : MonoBehaviour
{
    public GameObject enemyAPrefab;
    public GameObject enemyBPrefab;
    public GameObject enemyCPrefab;

    public GameObject itemAPrefab;
    public GameObject itemBPrefab;
    public GameObject itemCPrefab;
    public GameObject itemDPrefab;

    public GameObject npcAPrefab;
    public GameObject npcBPrefab;

    public GameObject playerBullet1Prefab;
    public GameObject playerBullet2Prefab;
    public GameObject playerBullet3Prefab;
    public GameObject enemyBulletPrefab;
    public GameObject bossBulletPrefab;

    public GameObject bomAPrefab;
    public GameObject bomBPrefab;
    public GameObject bomCPrefab;

    GameObject[] enemyA;
    GameObject[] enemyB;
    GameObject[] enemyC;

    GameObject[] itemA;
    GameObject[] itemB;
    GameObject[] itemC;
    GameObject[] itemD;

    GameObject[] npcA;
    GameObject[] npcB;

    GameObject[] playerBullet1;
    GameObject[] playerBullet2;
    GameObject[] playerBullet3;
    GameObject[] enemyBullet;
    GameObject[] bossBullet;

    GameObject[] bomA;
    GameObject[] bomB;
    GameObject[] bomC;

    GameObject[] targetPool;

    void Awake()
    {
        enemyA = new GameObject[10];
        enemyB = new GameObject[10];
        enemyC = new GameObject[10];

        itemA = new GameObject[10];
        itemB = new GameObject[10];
        itemC = new GameObject[10];
        itemD = new GameObject[10];

        npcA = new GameObject[10];
        npcB = new GameObject[10];

        playerBullet1 = new GameObject[50];
        playerBullet2 = new GameObject[50];
        playerBullet3 = new GameObject[50];
        enemyBullet = new GameObject[20];
        bossBullet = new GameObject[10];

        bomA = new GameObject[30];
        bomB = new GameObject[30];
        bomC = new GameObject[30];

        Generate();
    }
    void Generate()
    {
        //Àû
        for (int i = 0; i < enemyA.Length; i++)
        {
            enemyA[i] = Instantiate(enemyAPrefab);
            enemyA[i].SetActive(false);
        }
        for (int i = 0; i < enemyB.Length; i++)
        {
            enemyB[i] = Instantiate(enemyBPrefab);
            enemyB[i].SetActive(false);
        }
        for (int i = 0; i < enemyC.Length; i++)
        {
            enemyC[i] = Instantiate(enemyCPrefab);
            enemyC[i].SetActive(false);
        }
        //¾ÆÀÌÅÛ
        for (int i = 0; i < itemA.Length; i++)
        {
            itemA[i] = Instantiate(itemAPrefab);
            itemA[i].SetActive(false);
        }
        for (int i = 0; i < itemB.Length; i++)
        {
            itemB[i] = Instantiate(itemBPrefab);
            itemB[i].SetActive(false);
        }
        for (int i = 0; i < itemC.Length; i++)
        {
            itemC[i] = Instantiate(itemCPrefab);
            itemC[i].SetActive(false);
        }
        for (int i = 0; i < itemD.Length; i++)
        {
            itemD[i] = Instantiate(itemDPrefab);
            itemD[i].SetActive(false);
        }
        //NPC
        for (int i = 0; i < npcA.Length; i++)
        {
            npcA[i] = Instantiate(npcAPrefab);
            npcA[i].SetActive(false);
        }
        for (int i = 0; i < npcB.Length; i++)
        {
            npcB[i] = Instantiate(npcBPrefab);
            npcB[i].SetActive(false);
        }
        //ÃÑ¾Ë
        for (int i = 0; i < playerBullet1.Length; i++)
        {
            playerBullet1[i] = Instantiate(playerBullet1Prefab);
            playerBullet1[i].SetActive(false);
        }
        for (int i = 0; i < playerBullet2.Length; i++)
        {
            playerBullet2[i] = Instantiate(playerBullet2Prefab);
            playerBullet2[i].SetActive(false);
        }
        for (int i = 0; i < playerBullet3.Length; i++)
        {
            playerBullet3[i] = Instantiate(playerBullet3Prefab);
            playerBullet3[i].SetActive(false);
        }
        for (int i = 0; i < enemyBullet.Length; i++)
        {
            enemyBullet[i] = Instantiate(enemyBulletPrefab);
            enemyBullet[i].SetActive(false);
        }
        for (int i = 0; i < bossBullet.Length; i++)
        {
            bossBullet[i] = Instantiate(bossBulletPrefab);
            bossBullet[i].SetActive(false);
        }
        //ÀÌÆåÆ®
        for (int i = 0; i < bomA.Length; i++)
        {
            bomA[i] = Instantiate(bomAPrefab);
            bomA[i].SetActive(false);
        }
        for (int i = 0; i < bomB.Length; i++)
        {
            bomB[i] = Instantiate(bomBPrefab);
            bomB[i].SetActive(false);
        }
        for (int i = 0; i < bomC.Length; i++)
        {
            bomC[i] = Instantiate(bomCPrefab);
            bomC[i].SetActive(false);
        }
    }

    public GameObject MakeObj(string type)
    {

        switch (type)
        {
            case "enemyA":
                targetPool = enemyA;
                break;
            case "enemyB":
                targetPool = enemyB;
                break;
            case "enemyC":
                targetPool = enemyC;
                break;
            case "itemA":
                targetPool = itemA;
                break;
            case "itemB":
                targetPool = itemB;
                break;
            case "itemC":
                targetPool = itemC;
                break;
            case "itemD":
                targetPool = itemD;
                break;
            case "npcA":
                targetPool = npcA;
                break;
            case "npcB":
                targetPool = npcB;
                break;
            case "playerBullet1":
                targetPool = playerBullet1;
                break;
            case "playerBullet2":
                targetPool = playerBullet2;
                break;
            case "playerBullet3":
                targetPool = playerBullet3;
                break;
            case "enemyBullet":
                targetPool = enemyBullet;
                break;
            case "bossBullet":
                targetPool = bossBullet;
                break;
            case "bomA":
                targetPool = bomA;
                break;
            case "bomB":
                targetPool = bomB;
                break;
            case "bomC":
                targetPool = bomC;
                break;
        }
        for (int i = 0; i < targetPool.Length; i++)
        {
            if (!targetPool[i].activeSelf)
            {
                targetPool[i].SetActive(true);
                return targetPool[i];
            }

        }
        return null;
    }
}


    