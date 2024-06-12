using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dongle : MonoBehaviour
{
    public bool isDrag;
    Rigidbody2D rigid;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isDrag) {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            float rightWall = 4.1f - (transform.localScale.x / 2f);
            float leftWall = -4.1f + (transform.localScale.x / 2f);

            if (rightWall < mousePos.x)
            {
                mousePos.x = rightWall;
            }
            else if (mousePos.x < leftWall)
            {
                mousePos.x = leftWall;
            }

            mousePos.y = 8.0f;
            mousePos.z = 0f;

            transform.position = mousePos;
        }
    }

    public void Drag() {
        isDrag = true;

    }
    
    public void Drop() {
        isDrag = false;
        rigid.simulated = true; //물리작용 활성
    }
}
