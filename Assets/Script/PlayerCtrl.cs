using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCtrl : MonoBehaviour
{
    public float speed;
    public Animator anim;
    public int health;
    int maxHealth;
    Gauge pain;
    Shot shot;

    
    float side;
    float updown;
    bool hitBox;

    void Start()
    {
        pain = FindObjectOfType<Gauge>();
        shot = GetComponent<Shot>();
        maxHealth = health;
    }
    void Update()
    {
        if (health>=maxHealth)
        {
            health = maxHealth;
        }
        var t=transform.position;
        var hInput = Input.GetAxisRaw("Horizontal");
        //var vInput = Input.GetAxisRaw("Vertical");
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
        //transform.position += new Vector3(side, updown, 0)* Time.deltaTime;
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
            health -= 1;
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
                health -= 1;
                break;
            case "Invincibility(Clone)":
                Invincibility();
                break;
        }

    }
    void Invincibility()
    {

    }
}
