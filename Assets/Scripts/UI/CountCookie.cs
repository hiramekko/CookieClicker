using UnityEngine;
using UnityEngine.UI;

public class CountCookie : MonoBehaviour
{
    [Tooltip("クッキーを数えるテキスト")]
    [SerializeField] Text _countText;

    void Update()
    {
        _countText.text = GameManager.CountCookie.ToString();
    }
}