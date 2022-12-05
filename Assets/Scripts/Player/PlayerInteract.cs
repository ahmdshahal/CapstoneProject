using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField]
    private float distance = 5f;
    [SerializeField]
    private LayerMask mask;
    [SerializeField]
    private Camera cam;

    [SerializeField]
    private GameObject timerUI;
    [SerializeField]
    private TMP_Text timerText;
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
        InteractObjectWithTimer();
    }

    void InteractObjectWithTimer()
    {
        if (Interactable.isPopUp) { mask = LayerMask.GetMask("Close");}
        else { mask = LayerMask.GetMask("Interactable");}

        //Create a ray at the center of the camera, shooting outwards.
        Ray ray = new Ray(cam.transform.position, cam.transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * distance);
        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo, distance, mask))
        {
            Interactable interactable = hitInfo.collider.GetComponent<Interactable>();

            if (interactable != null)
            {
                timerText.text = timerValue.ToString("0.0");
                if (timerValue <= 0)
                {
                    timerValue = interactable.timer;
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
