using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerCtrl : MonoBehaviour
{
    public float speed;
    public Animator anim;
    public float health;
    public GameObject shield;
    public Generator generator;
    public Gamemanager gamemanager;
    public GameObject shootPoint;
    public GameObject shootPoint1;
    public scoreCtrl scorectrl;
    float maxHealth;
    GameObject bullet;
    Gauge pain;
    public Image image;
    float shotTime;
    int bulletLevel;
    float side;
    float updown;
    bool hitBox;
    float Shield;
    bool isShield;
    float i;

    void Start()
    {
        generator = FindObjectOfType<Generator>();
        pain = FindObjectOfType<Gauge>();
        gamemanager = FindObjectOfType<Gamemanager>();
       
        maxHealth = health;
        shield.SetActive(false);
        bulletLevel = 1;
    }
    void Update()
    {
        if (transform.position.x > 8.5)
        {
            transform.position = new Vector2(8.5f, transform.position.y);
        }
        if (transform.position.x < -8.5)
        {
            transform.position = new Vector2(-8.5f, transform.position.y);
        }
        if (transform.position.y > 4.5)
        {
            transform.position = new Vector2(transform.position.x, 4.5f);
        }
        if (transform.position.y < -4.5)
        {
            transform.position = new Vector2(transform.position.x, -4.5f);
        }
        shotTime += Time.deltaTime;
        if (Input.GetMouseButton(0))
        {
            if (shotTime >= 0.15f)
            {
                Shoot();
            }
            if (bulletLevel >= 5)
            {
                bulletLevel = 5;
            }
        }
        if (Shield >= 0)
        {
            isShield = true;
            Shield -= Time.deltaTime;
            if (Shield <= 0.5f)
            {
                shield.SetActive(false);
                if (i <= 0)
                {
                    isShield = false;
                }
            }
        }
        if (health >= maxHealth)
        {
            health = maxHealth;
        }
        var t = transform.position;
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
            updown += speed * 0.7f * Time.deltaTime;
        }
        side = Mathf.Clamp(side, -10, 10);
        updown = Mathf.Clamp(updown, -10, 10);
        Vector3 curPos = transform.position;
        Vector3 nextPosY = Vector3.up * updown * Time.deltaTime;
        Vector3 nextPosX = Vector3.right * side * Time.deltaTime;
        transform.position = curPos + nextPosX + nextPosY;
        anim.SetFloat("Side", hInput);
        if (health <= 0)
        {
            gamemanager.scoreSave = scorectrl.scorePoint;
            gamemanager.And();
        }
        image.fillAmount = health / maxHealth;
    }
    void Shoot()
    {
        switch (bulletLevel)
        {
            case 1:
                bullet = generator.MakeObj("playerBullet1");
                bullet.transform.position = gameObject.transform.position;
                shotTime = 0;
                break;
            case 2:
                bullet = generator.MakeObj("playerBullet1");
                bullet.transform.position = shootPoint.transform.position;
                bullet = generator.MakeObj("playerBullet1");
                bullet.transform.position = shootPoint1.transform.position;
                shotTime = 0;
                break;
            case 3:
                bullet = generator.MakeObj("playerBullet2");
                bullet.transform.position = shootPoint1.transform.position;
                shotTime = 0;
                break;
            case 4:
                bullet = generator.MakeObj("playerBullet2");
                bullet.transform.position = shootPoint.transform.position;
                bullet = generator.MakeObj("playerBullet2");
                bullet.transform.position = shootPoint1.transform.position;
                shotTime = 0;
                break;
            case 5:
                bullet = generator.MakeObj("playerBullet3");
                bullet.transform.position = shootPoint1.transform.position;
                shotTime = 0;
                break;
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "enemy")
        {
            if (isShield == false)
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
                bulletLevel += 1;
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
