using UnityEngine;

public class OpenPopUp : Interactable
{
    [SerializeField]
    GameObject[] isActive;
    [SerializeField]
    GameObject[] isNotActive;

    /// <summary>
    /// This function is where we will design our interaction using code
    /// </summary>
    protected override void Interact()
    {
        isPopUp = true;

        for (int i = 0; i < isActive.Length; i++)
        {
            isActive[i].SetActive(true);
        }
        for (int i = 0; i < isNotActive.Length; i++)
        {
            isNotActive[i].SetActive(false);
        }
    }
}
