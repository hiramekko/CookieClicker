using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] RectTransform _shopItewmRoot = null;
    [SerializeField] GameObject _shopItemPrefab = null;

    public void Setup()
    {
        GameData.ShopItemTable.ForEach(item =>
        {
            GameObject go = Instantiate(_shopItemPrefab, _shopItewmRoot);
            ShopItem shopScript = go.GetComponent<ShopItem>();
            shopScript.Setup(item);
        });

        _shopItewmRoot.sizeDelta = new Vector2(260, 80 * GameData.ShopItemTable.Count);
    }
}
