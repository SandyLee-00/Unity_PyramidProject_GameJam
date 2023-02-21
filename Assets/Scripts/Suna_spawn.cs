using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Suna_spawn : MonoBehaviour
{
    public GameObject[] trash;

    bool isSpawn = true;

    public GameObject Player;
    public float floor3 = 50f;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Player.transform.position.y > floor3)
        {
            isSpawn = false;
        }


        if (isSpawn)
        {
            StartCoroutine("SpawnTrash");
        }
    }


    IEnumerator SpawnTrash()
    {
        isSpawn = false;
        int type = Random.Range(0, trash.Length);
        int posX = Random.Range(-6, 6);
        Vector2 pos = new Vector2(Random.Range(-6, 6), this.transform.position.y);
        Quaternion rot = this.transform.rotation;

        Instantiate(trash[type], pos, this.transform.rotation);


        yield return new WaitForSeconds(2f);
        isSpawn = true;
    }
}