using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TeleportArea : Interactable
{
    [SerializeField]
    private Transform player;

    protected override void Interact()
    {
        player.transform.position = transform.position;
    }
}
