using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class scoreCtrl : MonoBehaviour
{
    public GameObject score;
    public GameObject clear;

    Gamemanager gameManager;

    public int scorePoint;
    public bool isClear;

    BossCtrl bossCtrl;
    Text scorBord;

    float t;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<Gamemanager>();
        bossCtrl = FindObjectOfType<BossCtrl>();
        scorBord = score.GetComponent<Text>();
        scorePoint = 0;
        clear.SetActive(false);
        isClear = false;
    }

    // Update is called once per frame
    void Update()
    {
        gameManager.scoreSave = scorePoint;
        if (bossCtrl.bossClear == true)
        {

            Fade();
        }
        
        scorBord.text = scorePoint.ToString();
    }
    IEnumerator Fade()
    {
        clear.SetActive(true);
        bossCtrl.bossClear = false;
        yield return new WaitForSeconds(2);
        clear.SetActive(false);
        yield return null;

    }
}
