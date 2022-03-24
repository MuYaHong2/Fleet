using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCtrl : MonoBehaviour
{
    public float speed;
    public Animator anim;
    public int health;
    public GameObject shield;
    int maxHealth;
    Gauge pain;
    Shot shot;

    
    float side;
    float updown;
    bool hitBox;
    float Shield;
    bool isShield;
    float i;

    void Start()
    {
        pain = FindObjectOfType<Gauge>();
        shot = GetComponent<Shot>();
        maxHealth = health;
        shield.SetActive(false);
    }
    void Update()
    {
        if (Shield>=0)
        {
            isShield = true;
            Shield -= Time.deltaTime;
            if (Shield<=0.5f)
            {
                shield.SetActive(false);
                if (i<=0)
                {
                    isShield = false;
                }
            }
        }
        if (health>=maxHealth)
        {
            health = maxHealth;
        }
        var t=transform.position;
        var hInput = Input.GetAxisRaw("Horizontal");
        if (Input.GetKey(KeyCode.A))
        {
            side -= speed * 0.7f * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            side += speed * 0.7f * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            updown -= speed * 0.7f * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.W))
        {
            updown += speed* 0.7f * Time.deltaTime;
        }
        side = Mathf.Clamp(side, -10, 10);
        updown = Mathf.Clamp(updown, -10, 10);
        Vector3 curPos = transform.position;
        Vector3 nextPosY = Vector3.up * updown * Time.deltaTime;
        Vector3 nextPosX = Vector3.right * side * Time.deltaTime;
        transform.position = curPos + nextPosX + nextPosY;
        anim.SetFloat("Side",hInput);
        if (health<=0)
        {
            SceneManager.LoadScene("GameOver");
        }
        
    
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "enemy")
        {
            if (isShield==false)
            {
                health -= 1;
            }
        }
        switch (other.gameObject.name)
        {
            case "Heal(Clone)":
                    health += 5;
                break;
            case "Painkiller(Clone)":
                pain.pain -= 2;
                break;
            case "Power Up(Clone)":
                shot.bulletLevel += 1;
                break;
            case "Enemy Bullet 3(Clone)":
                if (isShield == false)
                {
                    health -= 1;
                }
                break;
            case "Invincibility(Clone)":
                Invincibility();
                break;
            case "Enemy Bullet 0(Clone)":
                if (isShield == false)
                {
                    health -= 2;
                }
                break;
        }

    }
    void Invincibility()
    {
        shield.SetActive(true);
        Shield += 3;
    }
}
