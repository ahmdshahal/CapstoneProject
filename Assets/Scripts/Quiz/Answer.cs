using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Answer : MonoBehaviour
{
    public GameObject feedTrue, feedFalse;

    public void Answering(bool Answer)
    {
        if (Answer)
        {
            feedTrue.SetActive(false);
            feedTrue.SetActive(true);
            int score = PlayerPrefs.GetInt("score") + 10;
            PlayerPrefs.SetInt("score", score);
        } else
        {
            feedFalse.SetActive(false);
            feedFalse.SetActive(true);
        }
        gameObject.SetActive(false);
        transform.parent.GetChild(gameObject.transform.GetSiblingIndex() + 1).gameObject.SetActive(true);
    }
}
