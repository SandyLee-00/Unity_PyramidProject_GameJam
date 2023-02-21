using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//using UnityEngine.Windows;

public class PausePanel : MonoBehaviour
{
    public GameObject menuSet;
    public GameObject pausePanel;
    // Start is called before the first frame update

   
    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Cancel"))
        {
            pausePanel.SetActive(true);
            Time.timeScale = 0;
        }
    
    }
   
    public void ResetYesbtn()
    {
        pausePanel.SetActive(true);
        Time.timeScale = 0;
    }
    public void ResetNobtn()
    {   
        pausePanel.SetActive(false);
        
        StartCoroutine(Delaytime());
    }

    IEnumerator Delaytime()
    {
        yield return new WaitForSecondsRealtime(2.0f);
        
        Time.timeScale=1.0f;
    
    }

    //void ResetNobtn()
    //{
    //    Time.unscaledTime=
    //    Invoke("Delaytime", 3.0f);
    //}

    //void Delaytime()
    //{

    //}


    public void sceneChange()
    {
        SceneManager.LoadScene("StartScene");
        return;
    }
}
