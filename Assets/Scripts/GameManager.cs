using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager
{
    static GameManager _instance = new GameManager();
    static public GameManager Instance => _instance;
    GameManager() { } //コンストラクタ
    List<UpgradeData> _upgrades = new List<UpgradeData>();
    int _countCookie = 0;
    static public int CountCookie => _instance._countCookie;
    FactoryManager _factoryMan = null;
    static public FactoryManager Factory => _instance._factoryMan;
    static public List<UpgradeData> UpgradeInfo => _instance._upgrades;

    static public void AddCookie(int num)
    {
        _instance._countCookie += num; 
    }

    static public void Purchase(ShopItemTable item, int cost)
    {
        _instance._countCookie -= cost;
        switch (item.Type)
        {
            case ItemType.Factory:
                _instance._factoryMan.Purchase(item.TargetId);
                break;

            case ItemType.Upgrade:
                //TODO:

                break;
        }
    }

    public void Load()
    {
        var save = LocalData.Load<SaveData>(Application.dataPath + "/save.json");
        if (save == null)
        {
            save = new SaveData();
        }

        _countCookie = save.CookieNum;

        var root = GameObject.Find("/Factory");
        _factoryMan = root.GetComponent<FactoryManager>();
        int cc = _factoryMan.transform.childCount;
        for (int i = 0; i < cc; ++i)
        {
            GameObject.Destroy(_factoryMan.transform.GetChild(i).gameObject);
        }
        _factoryMan.Setup(save.Factory);
    }

    public void Save()
    {
        SaveData save = new SaveData();
        _factoryMan.Save(save);
        save.CookieNum = _countCookie;
        LocalData.Save<SaveData>(Application.dataPath + "/save.json", save);
    }

    public void Legacy()
    {
        SaveData save = new SaveData();
        int cc = _factoryMan.transform.childCount;
        for (int i = 0; i < cc; ++i)
        {
            GameObject.Destroy(_factoryMan.transform.GetChild(i).gameObject);
        }
        _countCookie = 0;
        save.CookieNum = _countCookie;
        LocalData.Save<SaveData>(Application.dataPath + "/save.json", save);
    }
}