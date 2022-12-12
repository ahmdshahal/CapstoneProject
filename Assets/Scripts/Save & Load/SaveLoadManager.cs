using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLoadManager : MonoBehaviour
{
    public Transform player;

    public float positionX;
    public float positionY;
    public float positionZ;

    public GameObject lock1;
    public GameObject lock2;
    public GameObject lock3;
    public GameObject lock4;

    void Start()
    {
        if (PlayerPrefs.GetInt("HasLaunched", 0) != 0)
        {
            LoadPlayerPos();
        }
        PlayerPrefs.SetInt("HasLaunched", 1);
    }

    void GetPlayerData()
    {
        positionX = player.position.x;
        positionY = player.position.y;
        positionZ = player.position.z;
    }

    void SetPlayerData()
    {
        player.transform.position = new Vector3(positionX, positionY, positionZ);
    }

    public void Save()
    {
        GetPlayerData();
        PlayerPrefs.SetFloat("posX", positionX);
        PlayerPrefs.SetFloat("posY", positionY);
        PlayerPrefs.SetFloat("posZ", positionZ);

        PlayerPrefs.SetInt("Lock1", boolToInt(lock1.activeInHierarchy));
        PlayerPrefs.SetInt("Lock2", boolToInt(lock2.activeInHierarchy));
        PlayerPrefs.SetInt("Lock3", boolToInt(lock3.activeInHierarchy));
        PlayerPrefs.SetInt("Lock4", boolToInt(lock4.activeInHierarchy));
    }

    void LoadPlayerPos()
    {
        positionX = PlayerPrefs.GetFloat("posX");
        positionY = PlayerPrefs.GetFloat("posY");
        positionZ = PlayerPrefs.GetFloat("posZ");

        lock1.SetActive(intToBool(PlayerPrefs.GetInt("Lock1", 0)));
        lock2.SetActive(intToBool(PlayerPrefs.GetInt("Lock2", 0)));
        lock3.SetActive(intToBool(PlayerPrefs.GetInt("Lock3", 0)));
        lock4.SetActive(intToBool(PlayerPrefs.GetInt("Lock4", 0)));
        SetPlayerData();
    }

    int boolToInt(bool val)
    {
        if (val)
            return 1;
        else
            return 0;
    }

    bool intToBool(int val)
    {
        if (val != 0)
            return true;
        else
            return false;
    }

    private void OnApplicationQuit()
    {
        Save();
    }
}
