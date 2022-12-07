using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorGuide : MonoBehaviour
{
    public void Next()
    {
        gameObject.SetActive(false);
        transform.parent.GetChild(gameObject.transform.GetSiblingIndex() + 1).gameObject.SetActive(true);
    }

    public void Back()
    {
        gameObject.SetActive(false);
        transform.parent.GetChild(gameObject.transform.GetSiblingIndex() - 1).gameObject.SetActive(true);
    }
}
