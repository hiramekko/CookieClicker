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
    long _countCookie = 0;
    //static public long CountCookie => _instance._countCookie;
    static public long CountCookie 
    { get { return _instance._countCookie; }
    set{ _instance._countCookie = value; } }
    StarManager _starManager = null;
    static public StarManager Star => _instance._starManager;
    static public List<UpgradeData> UpgradeInfo => _instance._upgrades;

    static public void AddCookie(long num)
    {
        _instance._countCookie += num; 
    }

    static public void Purchase(ShopItemTable item, long cost)
    {
        _instance._countCookie -= cost;
        switch (item.Type)
        {
            case ItemType.Star:
                _instance._starManager.Purchase(item.TargetId);
                break;

            case ItemType.Upgrade:
                //TODO:

                break;
        }
    }

    public void Load()
    {
        var save = LocalData.Load<SaveData>(Application.dataPath + "/save.json");
        //if (save == null)
        //{
        //    save = new SaveData();
        //}

        _countCookie = save.CookieNum;

        var root = GameObject.Find("/Star");
        _starManager = root.GetComponent<StarManager>();
        int cc = _starManager.transform.childCount;
        for (int i = 0; i < cc; ++i)
        {
            GameObject.Destroy(_starManager.transform.GetChild(i).gameObject);
        }
        _starManager.Setup(save.Star);
    }

    public void Save()
    {
        SaveData save = new SaveData();
        //_factoryMan.Save(save);
        save.CookieNum = _countCookie;
        LocalData.Save<SaveData>(Application.dataPath + "/save.json", save);
    }

    public void Legacy()
    {
        SaveData save = new SaveData();
        //int cc = _factoryMan.transform.childCount;
        //for (int i = 0; i < cc; ++i)
        //{
        //    GameObject.Destroy(_factoryMan.transform.GetChild(i).gameObject);
        //}
        _countCookie = 0;
        save.CookieNum = _countCookie;
        LocalData.Save<SaveData>(Application.dataPath + "/save.json", save);
    }
}