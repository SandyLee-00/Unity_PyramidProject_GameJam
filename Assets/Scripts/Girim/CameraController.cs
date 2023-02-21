using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float cameraSpeed = 5.0f;
    GameObject player;

    private void Awake()
    {
        player = GameObject.Find("Player").gameObject;
    }


    
    void Update()
    {
        //Vector3 dir = player.transform.position - this.transform.position;
        //Vector3 moveVector = new Vector3(0.0f, dir.y * cameraSpeed * Time.deltaTime + 0.05f, 0.0f);
        this.transform.position = new Vector3(this.transform.position.x, player.transform.position.y+2f, this.transform.position.z);
    }
}
