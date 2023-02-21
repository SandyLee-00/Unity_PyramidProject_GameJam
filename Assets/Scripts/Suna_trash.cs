using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Suna_trash : MonoBehaviour
{
    private float speed = 0.005f;
    void Start()
    {

    }

    void Update()
    {

        transform.Translate(new Vector3(0, -speed, 0));


        float posY = transform.position.y;
        if (posY < -7.0f)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {

            Destroy(gameObject);

        }
    }


}