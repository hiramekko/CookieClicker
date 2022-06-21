using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gacha : MonoBehaviour
{
    [Tooltip("アイテムプレハブ")]
    [SerializeField] GameObject[] _itemCollection;
    //[SerializeField] ShopItemTable[] _shopCollection;
    [Tooltip("ガチャ1回回すのに必要なクッキーの個数")]
    [SerializeField] long _gachacookie = 10;
    [Tooltip("確率")]
    [SerializeField] int _probability;
    int number = 1;
    Vector3 state;
    AudioSource _as;

    public void RandomCreate()
    {
        if (GameManager.CountCookie < _gachacookie)
        {
            return;
        }
        number = Random.Range(0, _itemCollection.Length);
        state.x = Random.Range(-200, 1200);
        state.y = Random.Range(500, 800);
        state.z = Random.Range(0, 1200);
        Instantiate(_itemCollection[number], state, Quaternion.identity);
        GameManager.CountCookie -= _gachacookie;
        //_as.PlayOneShot(_as.clip);
        switch(number)
        {
            case 0:
                Debug.Log($"緑星を生成した");
                break;
            case 1:
                Debug.Log($"青星を生成した");
                break;
            case 2:
                Debug.Log($"赤星を生成した");
                break;
            case 3:
                Debug.Log($"紫星を生成した");
                break;
        }
    }
}