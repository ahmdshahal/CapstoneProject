using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField]
    private float distance = 3f;
    [SerializeField]
    private LayerMask mask;
    [SerializeField]
    private Camera cam;

    [SerializeField]
    private GameObject timerUI;
    [SerializeField]
    private Image imgTimer;
    [SerializeField]
    private float timerValue;

    private float countTime;
    private bool isCount;
    private PlayerUI playerUI;

    void Start()
    {
        playerUI = GetComponent<PlayerUI>();
    }

    void FixedUpdate()
    {
        //Create a ray at the center of the camera, shooting outwards.
        Ray ray = new Ray(cam.transform.position, cam.transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * distance);
        RaycastHit hitInfo;
        if(Physics.Raycast(ray, out hitInfo, distance, mask))
        {
            if (hitInfo.collider.GetComponent<Interactable>() != null)
            {
                Interactable interactable = hitInfo.collider.GetComponent<Interactable>();
                if (timerValue <= 0)
                {
                    timerValue = interactable.timer;
                    Debug.Log("Add Time");
                    countTime = interactable.timer;
                }
                else
                {
                    isCount = true;
                    playerUI.UpdateText(interactable.promptMessage);
                    timerUI.SetActive(true);
                    if (isCount)
                    {
                        timerValue -= Time.deltaTime;
                        Debug.Log("is counting");
                        imgTimer.fillAmount = timerValue / countTime;
                        if (timerValue <= 0)
                        {
                            interactable.BaseInteract();
                            isCount = false;
                        }
                    }
                }
            }
        }
        else
        {
            isCount = false;
            timerUI.SetActive(false);
            playerUI.UpdateText(string.Empty);
            timerValue = 0;
        }
    }
}
