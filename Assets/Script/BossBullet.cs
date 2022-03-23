using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBullet : MonoBehaviour
{
    public int speed;
    public Generator generator;
    // Start is called before the first frame update
    void Start()
    {
        generator = FindObjectOfType<Generator>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        if (transform.position.y <= -6)
        {
            gameObject.SetActive(false);
        }
       
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            GameObject boom = generator.MakeObj("bomB");
            boom.transform.position = transform.position;
            gameObject.SetActive(false);    
        }
    }
}
