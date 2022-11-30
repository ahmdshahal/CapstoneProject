using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishText : MonoBehaviour
{
    public void PopupText()
    {
        int score = PlayerPrefs.GetInt("score");
        if (score == 100)
        {
            gameObject.transform.GetChild(0).gameObject.SetActive(true);
        } 
        else if (score >= 50 && score <= 75)
        {
            gameObject.transform.GetChild(1).gameObject.SetActive(true);
        } 
        else if (score >= 0 && score <= 25)
        {
            gameObject.transform.GetChild(2).gameObject.SetActive(true);
        }
    }
    
    void OnEnable()
    {
        PopupText();
    }

    public void Retry()
    {
        PlayerPrefs.SetInt("score", 0);
        gameObject.SetActive(false);
        gameObject.transform.GetChild(0).gameObject.SetActive(false);
        gameObject.transform.GetChild(1).gameObject.SetActive(false);
        gameObject.transform.GetChild(2).gameObject.SetActive(false);
        transform.parent.GetChild(gameObject.transform.GetSiblingIndex() - 4).gameObject.SetActive(true);
    }
}
