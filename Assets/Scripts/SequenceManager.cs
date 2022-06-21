using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SequenceManager : MonoBehaviour
{
    void Start()
    {
        Load();

        GameObject shop = GameObject.Find("/Canvas/Shop");
        Shop shopScript = shop.GetComponent<Shop>();
        shopScript.Setup();
    }

    public void Load()
    {
        GameManager.Instance.Load();
    }

    public void Save()
    {
        GameManager.Instance.Save();
    }

    public void Legacy()
    {
        GameManager.Instance.Legacy();
    }
}
