using UnityEngine;
using UnityEngine.EventSystems;
//using UnityEngine.UI;

public class ClickController : MonoBehaviour//, IPointerEnterHandler, IPointerExitHandler
{
    [Tooltip("クリック（ボタン）で増えるクッキーの数")]
    [SerializeField] long _addClickNum = 1;
    [Tooltip("クッキーの所持数上限")]
    [SerializeField] long _maxCookie = 9999999999999;
    AudioSource _as;
    Animator _anim;

    void Start()
    {
        _anim = GetComponent<Animator>();
        _as = GetComponent<AudioSource>();
    }

    public void ClickCookie()
    {
        if(GameManager.CountCookie >= _maxCookie)
        {
            return;
        }

        if (Input.GetMouseButtonDown(0))
        {
            GameManager.AddCookie(_addClickNum);
            _anim.SetTrigger("Pressed");
            _as.PlayOneShot(_as.clip);
        }
    }
}
