using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public int scorePoint;
    public GameObject score;
    public GameObject clear;
    public GameObject boss;
    BossCtrl bossCtrl;
    float t;
    public bool isClear;
    // Start is called before the first frame update
    void Start()
    {
        bossCtrl = boss.GetComponent<BossCtrl>();
        scorePoint = 0;
        clear.SetActive(false);
        isClear = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (bossCtrl.bossClear==true)
        {
            clear.SetActive(true);
            bossCtrl.bossClear = false;
            isClear = true;
        }
        if (isClear==true)
        {
            t += Time.deltaTime;
            if (t >= 2)
            {
                clear.SetActive(false);
                isClear = false;
                t = 0;
            }
        }
        score.GetComponent<Text>().text = scorePoint.ToString();
    }
}
