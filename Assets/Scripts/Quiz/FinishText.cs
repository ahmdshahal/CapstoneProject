using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishText : MonoBehaviour
{
    public void Retry()
    {
        PlayerPrefs.SetInt("score", 0);
        gameObject.SetActive(false);
        transform.parent.GetChild(1).gameObject.SetActive(true);
    }
}
