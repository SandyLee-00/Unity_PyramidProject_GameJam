using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class count : MonoBehaviour
{
    [SerializeField] float setTime = 3.0f;
    [SerializeField] GameObject countTxt;

    // Start is called before the first frame update
    void Start()
    {
        countTxt.GetComponent<TextMeshProUGUI>().text = setTime.ToString();
        //countdownText.text = setTime.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (setTime>=0) 
        { 
            setTime-= Time.deltaTime;
            countTxt.GetComponent<TextMeshProUGUI>().text = Mathf.Round(setTime).ToString();
        
        }
        else
        {
            countTxt.SetActive(false);
        }

        
    }
}
