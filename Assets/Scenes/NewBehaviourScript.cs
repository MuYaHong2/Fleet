using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public float speed;
    public Animator anim;

    void Update()
    {
        var hInput = Input.GetAxisRaw("Horizontal");
        var vInput = Input.GetAxisRaw("Vertical");
        transform.position += new Vector3(hInput, vInput, 0) * speed * Time.deltaTime;
        anim.SetFloat("Side",hInput);
    }
}
