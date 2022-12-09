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
    private Transform rayTransform;

    [SerializeField]
    private GameObject timerUI;
    [SerializeField]
    private TMP_Text timerText;
    [SerializeField]
    private Image imgTimer;
    [SerializeField]
    private float timerValue;

    [SerializeField]
    private LineRenderer laserLineRenderer; 
    public float laserWidth = 0.1f;
    public float laserMaxLength = 5f;

    private float countTime;
    private bool isCount;
    private PlayerUI playerUI;

    void Awake()
    {
        playerUI = GetComponent<PlayerUI>();
    }

    void Start()
    {
        Vector3[] initLaserPositions = new Vector3[2] { Vector3.zero, Vector3.zero };
        laserLineRenderer.SetPositions(initLaserPositions);
        laserLineRenderer.SetWidth(laserWidth, laserWidth);
    }

    void FixedUpdate()
    {
        InteractObjectWithTimer();
        //ShootLaserFromTargetPosition(new Vector3(rayTransform.position.x, rayTransform.position.y - 0.1f, rayTransform.position.z), rayTransform.transform.forward, laserMaxLength);
    }

    void InteractObjectWithTimer()
    {
        if (Interactable.isPopUp) { mask = LayerMask.GetMask("Close");}
        else { mask = LayerMask.GetMask("Interactable");}

        //Create a ray at the center of the camera, shooting outwards.
        Ray ray = new Ray(rayTransform.transform.position, rayTransform.transform.forward);
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

    void ShootLaserFromTargetPosition(Vector3 targetPosition, Vector3 direction, float length)
    {
        Ray ray = new Ray(targetPosition, direction);
        RaycastHit raycastHit;
        Vector3 endPosition = targetPosition + (length * direction);

        if (Physics.Raycast(ray, out raycastHit, length))
        {
            endPosition = raycastHit.point;
        }

        /*laserLineRenderer.SetPosition(0, targetPosition);
        laserLineRenderer.SetPosition(1, endPosition);*/
    }
}
