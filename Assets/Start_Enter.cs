using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Start_Enter : MonoBehaviour
{
    public GameObject GuidePanel;

    private void Start()
    {
        GuidePanel.SetActive(false);
    }

    public void OnStartButtonClicked()
    {
        SceneManager.LoadScene("MainScene_proto");
        return;
    }

    public void OnGuideButtonClicked()
    {
        GuidePanel.SetActive(true);
        return;
    }

    public void OnGuideExitButtonClicked()
    {
        GuidePanel.SetActive(false);
        return;
    }
}
