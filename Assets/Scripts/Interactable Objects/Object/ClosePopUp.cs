using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClosePopUp : Interactable
{
    [SerializeField]
    GameObject[] isActiveWhenClose;
    [SerializeField]
    GameObject[] isNotActiveWhenClose;

    /// <summary>
    /// This function is where we will design our interaction using code
    /// </summary>
    protected override void Interact()
    {
        for (int i = 0; i < isActiveWhenClose.Length; i++)
        {
            isActiveWhenClose[i].SetActive(true);
        }
        for (int i = 0; i < isNotActiveWhenClose.Length; i++)
        {
            isNotActiveWhenClose[i].SetActive(false);
        }

        isPopUp = false;
    }
}
