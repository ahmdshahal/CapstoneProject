using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportToSpecificArea : Interactable
{
    [SerializeField]
    private Transform player;
    [SerializeField]
    private Transform teleportArea;

    protected override void Interact() => player.transform.position = teleportArea.transform.position;
}
