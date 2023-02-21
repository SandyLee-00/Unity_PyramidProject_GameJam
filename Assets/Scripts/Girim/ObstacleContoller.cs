using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleContoller : MonoBehaviour
{
    
    GameObject player;
    BoxCollider2D headCollider;
    BoxCollider2D tailCollider;

    private void Awake()
    {
        player = GameObject.Find("Player").gameObject;
        headCollider = player.GetComponents<BoxCollider2D>()[1];
        tailCollider = player.GetComponents<BoxCollider2D>()[0];
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision == headCollider)
        {
            tailCollider.isTrigger = true;
            GetComponent<BoxCollider2D>().isTrigger = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        tailCollider.isTrigger = false;
        GetComponent<BoxCollider2D>().isTrigger = false;
    }

    
}
