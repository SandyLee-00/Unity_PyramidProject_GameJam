using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    //  플레이어 조작 변수
    public float jumpPower;
    public float maxSpeed;

    //  생명
    int life; 
    GameObject heartImage;
    GameObject collisionObject;

    //  Component
    Rigidbody2D rigid;
    SpriteRenderer spriteRenderer;
    Animator animator;

    //  게임클리어
    GameObject ClearPanel;
    //  게임오버
    GameObject OverPanel;


    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer= GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();

        life = 2;
        heartImage = GameObject.Find("Heart");
        ClearPanel = GameObject.Find("Canvas").gameObject.transform.GetChild(1).gameObject;
        OverPanel = GameObject.Find("Canvas").gameObject.transform.GetChild(3).gameObject;

        Time.timeScale = 1f;
    }


    private void FixedUpdate()
    {
        //  Move Speed
        float h = Input.GetAxisRaw("Horizontal");
        rigid.AddForce(Vector2.right * h, ForceMode2D.Impulse);

        Debug.Log(h);

        //  Max Speed
        if(rigid.velocity.x > maxSpeed) //Right
        {
            rigid.velocity = new Vector2(maxSpeed, rigid.velocity.y);
        }
        else if(rigid.velocity.x < maxSpeed * (-1)) //Left
        {
            rigid.velocity = new Vector2(maxSpeed * (-1), rigid.velocity.y);
        }
    }


    void Update()
    {
        //  Jump
        if (Input.GetButtonDown("Jump") && !animator.GetBool("isJump"))
        {
            rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            animator.SetBool("isJump", true);
        }

        //  Horizontal
        if (Input.GetButtonDown("Horizontal"))
        {
            rigid.velocity = new Vector2(rigid.velocity.normalized.x, rigid.velocity.y);
            spriteRenderer.flipX = Input.GetAxisRaw("Horizontal") == 1;
        }

        //  Walk Animation
        if (Mathf.Abs(rigid.velocity.x) < 0.2)
        {
            animator.SetBool("isWalk", false);
        }
        else
        {
            animator.SetBool("isWalk", true);
        }

        //  Dead
        if(life < 0)
        {
            animator.SetBool("isDead", true);
            // todo : 게임 멈추고 사망 패널 띄우기
            Invoke("GameOver", 1.5f);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //  게임클리어 패널 띄우기 + 멈추기
        if (collision.collider.gameObject.CompareTag("Finish"))
        {
            ClearPanel.SetActive(true);
            Time.timeScale = 0f;
        }
         
        
        // 양쪽 벽에 닿으면 튕겨나가기
        if (collision.collider.gameObject.CompareTag("Wall"))
        {
            Vector2 pos = this.transform.position;
            ContactPoint2D cp = collision.GetContact(0);
            Vector2 dir = pos - cp.point; // 접촉지점에서부터 탄위치 의 방향
            rigid.AddForce((dir).normalized * 500f);
        }

        //  물과 충돌
        if (collision.gameObject.tag == "Water")
        {
            collisionObject = collision.gameObject; //  충돌한 오브젝트

            Debug.Log("물과 충돌");
            heartImage.gameObject.transform.GetChild(life).gameObject.SetActive(false);
            heartImage.gameObject.transform.GetChild(life+3).gameObject.SetActive(true);
            life--;

            //  3초간 무적상태
            collisionObject.GetComponent<BoxCollider2D>().enabled = false;
            Debug.Log("생명 : " + life);
            animator.SetBool("isHit", true);
            Invoke("Hitted", 1.0f);
            Invoke("WaterColliderOn", 3.0f);
        }

        //  점프 후 발판에 착지
        if(collision.gameObject.CompareTag("Platform"))
        {
            animator.SetBool("isJump", false);
            Debug.Log("isJump : " + animator.GetBool("isJump"));
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Trash")
        {
            collisionObject = collision.gameObject; //  충돌한 오브젝트

            Debug.Log("낙하물과 충돌");
            heartImage.gameObject.transform.GetChild(life).gameObject.SetActive(false);
            heartImage.gameObject.transform.GetChild(life + 3).gameObject.SetActive(true);
            life--;


            //  3초간 무적상태
            collisionObject.GetComponent<BoxCollider2D>().enabled = false;
            animator.SetBool("isHit", true);
            Invoke("Hitted", 1.0f);
            Invoke("WaterColliderOn", 3.0f);
        }
    }

    void GameOver()
    {
        // 게임오버 패널 띄우기
        OverPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    private void Hitted()
    {
        animator.SetBool("isHit", false);
    }

    void WaterColliderOn()
    {
        collisionObject.GetComponent<BoxCollider2D>().enabled = true;
    }
}
