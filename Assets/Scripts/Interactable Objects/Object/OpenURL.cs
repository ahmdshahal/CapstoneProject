using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenURL : Interactable
{
    [SerializeField] private string URL;

    protected override void Interact()
    {
        Application.OpenURL(URL);
        Debug.Log("Open link: " + URL);
    }
}
