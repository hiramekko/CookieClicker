using UnityEngine;
using UnityEngine.EventSystems;
//using UnityEngine.UI;

public class ClickController : MonoBehaviour//, IPointerEnterHandler, IPointerExitHandler
{
    [Tooltip("クリック（ボタン）で増えるクッキーの数")]
    [SerializeField] long _addClickNum = 1;
    AudioSource _as;
    Animator _anim;

    void Start()
    {
        _anim = GetComponent<Animator>();
        _as = GetComponent<AudioSource>();
    }


    //public void OnPointerEnter(PointerEventData eventData)
    //{
    //    Debug.Log("クッキーです");
        

    //}

    //public void OnPointerExit(PointerEventData eventData)
    //{
    //    Debug.Log("何もない1");
    //}

    void Update()
    {
        //ClickCookie();
    }

    public void ClickCookie()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameManager.AddCookie(_addClickNum);
            _anim.SetTrigger("Pressed");
            _as.PlayOneShot(_as.clip); ;
        }
    }
}
