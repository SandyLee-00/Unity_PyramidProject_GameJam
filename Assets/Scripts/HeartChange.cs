using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HeartChange : MonoBehaviour
{
    [SerializeField] Image[] spriteR;
    Sprite sprites;
    int index=0;
    public GameObject gameover;

    
    private void Start()
    {
        
        sprites = Resources.Load<Sprite>("UI/Heartimage/icon_heart_dark");

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name=="Water")
        {
            if (index < 3)
            {
                spriteR[index].sprite = sprites;
                            index++;
               
            }
            if(index==3)
                {
                    gameover.SetActive(true);
                    //SceneManager.LoadScene("StartScene");
                    //          return;
                }
        }
    }

   

}

