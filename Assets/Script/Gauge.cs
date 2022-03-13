using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Gauge : MonoBehaviour
{
    public float pain;
    float maxPain;
    Image painBar;
    
    // Start is called before the first frame update
    void Start()
    {
        pain = 0;
        painBar = GetComponent<Image>();
        maxPain = 10;
    }

    // Update is called once per frame
    void Update()
    {
        if (pain<=0)
        {
            pain = 0;
        }
        painBar.fillAmount = pain / maxPain;
        if (pain >= 10)
        {
            SceneManager.LoadScene("GameOver");
        }
    }
}
