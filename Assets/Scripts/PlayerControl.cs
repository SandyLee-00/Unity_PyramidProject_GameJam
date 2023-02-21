using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private Rigidbody2D rigid;
    public float Speed;
    public float jumpPower;
    public bool isJump=false;

    private void Awake()
    {
        rigid=GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        playerMove();
        Jump();
    }

    void playerMove()
    {
        float h = Input.GetAxisRaw("Horizontal");
        Vector3 moveVelocity = new Vector3(h, 0, 0) * Speed * Time.deltaTime;
        this.transform.position += moveVelocity;

    }
    void Jump()
    {
        if(Input.GetKeyDown(KeyCode.Space)) 
        {
            if(!isJump)
            {
                isJump=true;
                rigid.AddForce(Vector3.up * jumpPower, ForceMode2D.Impulse);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.name.Equals("Ground"))
        {
            isJump=false;
        }
    }
}
