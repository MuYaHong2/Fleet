using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hp : MonoBehaviour
{
    public PlayerCtrl hp;
    float maxHealth;
    Image healthBar;
    // Start is called before the first frame update
    void Start()
    {
        hp = FindObjectOfType<PlayerCtrl>();
        healthBar = GetComponent<Image>();
        maxHealth = 20;
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.fillAmount = hp.health / maxHealth;
    }
}
