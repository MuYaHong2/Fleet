using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class scoreCtrl : MonoBehaviour
{
    public GameObject score;
    public GameObject clear;
    BossCtrl bossCtrl;

    Score scoreA;
    // Start is called before the first frame update
    void Start()
    {
        bossCtrl = FindObjectOfType<BossCtrl>();
        scoreA = FindObjectOfType<Score>();
        scoreA.scorePoint = 0;
        clear.SetActive(false);
        scoreA.isClear = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (bossCtrl.bossClear == true)
        {
            clear.SetActive(true);
            bossCtrl.bossClear = false;
            scoreA.isClear = true;
        }
        if (scoreA.isClear == true)
        {
            scoreA.t += Time.deltaTime;
            if (scoreA.t >= 2)
            {
                clear.SetActive(false);
                scoreA.isClear = false;
                scoreA.t = 0;
            }
        }
        score.GetComponent<Text>().text = scoreA.scorePoint.ToString();
    }
}
