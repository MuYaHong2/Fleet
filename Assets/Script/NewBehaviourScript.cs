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
        if(hInput==-1)anim.SetBool("isMoving",false);
        if(hInput==1)anim.SetBool("isMoving", true);
        var viewPos = Camera.main.WorldToViewportPoint(transform.position); // 오브젝트의 좌표를 화면 상 좌표로...
        viewPos.x = Mathf.Clamp01(viewPos.x); // 위에서 받아온 좌표의 x값을 가공
        viewPos.y = Mathf.Clamp01(viewPos.y); // 위에서 받아온 좌표의 y값을 가공

        var worldPos = Camera.main.ViewportToWorldPoint(viewPos); // 화면 상 좌표를 월드 좌표로...
        transform.position = worldPos; // 오브젝트에 월드좌표를 적용
    }
}
