using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Answer : MonoBehaviour
{
    public GameObject feedTrue, feedFalse;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Answering(bool Answer)
    {
        if (Answer)
        {
            feedTrue.SetActive(false);
            feedTrue.SetActive(true);
            int score = PlayerPrefs.GetInt("score") + 25;
            PlayerPrefs.SetInt("score", score);
        } else
        {
            feedFalse.SetActive(false);
            feedFalse.SetActive(true);
        }
        gameObject.SetActive(false);
        transform.parent.GetChild(gameObject.transform.GetSiblingIndex() + 1).gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
