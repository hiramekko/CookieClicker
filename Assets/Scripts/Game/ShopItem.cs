using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopItem : MonoBehaviour
{
    [SerializeField] UnityEngine.UI.Text _name;
    [SerializeField] UnityEngine.UI.Text _cost;
    [SerializeField] UnityEngine.UI.Text _num;

    static int _itemNum = 0;
    Button _button;
    static ShopItemTable _item;
    StarData _data;
    //[SerializeField]
    AudioSource _as;

    void Start()
    {
        _as = GetComponent<AudioSource>();
    }

    public void Setup(ShopItemTable item)
    {
        _item = item;
        _button = GetComponent<UnityEngine.UI.Button>();
        _button.onClick.AddListener(() =>
        {
            if (Cost() > GameManager.CountCookie)
            {
                return;
            }

            _as.PlayOneShot(_as.clip);
            GameManager.Purchase(_item, Cost());
        });

        //UpdateItem();
    }

    static public long Cost()
    {
        return Mathf.FloorToInt(_item.Cost * 
            (1.0f + (float)(_itemNum / 10.0f)));
    }

    public void UpdateItem()
    {
        _name.text = _item.Name;

        if (_item.Type == ItemType.Star)
        {
            _itemNum = GameManager.Star.GetLevel(_item.TargetId);
            _num.text = _itemNum.ToString();
        }
        else
        {
            _num.text = "";
        }

        _cost.text = string.Format("Cost:{0}", 
            CostStringConverter.Convert(Cost()));
    }

    void Update()
    {
        CheckPerchase();
    }

    void CheckPerchase()
    {
        if (Cost() > GameManager.CountCookie)
        {
            _cost.color = Color.red;
        }
        else
        {
            _cost.color = Color.black;
        }
    }
}
