using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCtrl : MonoBehaviour
{
    public float speed;

    string n;

    Rigidbody2D rigid;
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        n = gameObject.name;
    }
    void OnEnable()
    {
        rigid.velocity = Vector2.down * speed;
    }
    // Update is called once per frame
    void Update()
    {
        if (transform.position.y <= -6)
        {
            Release();
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            Release();
        }
    }
    void Release()
    {
        switch (n)
        {
            case "Invincibility(Clone)":
                NGenerator.Item0.Release(gameObject);
                break;
            case "PainKiller(Clone)":
                NGenerator.Item1.Release(gameObject);
                break;
            case "Power Up(Clone)":
                NGenerator.Item2.Release(gameObject);
                break;
            case "Heal(Clone)":
                NGenerator.Item3.Release(gameObject);
                break;
        }
    }
}
