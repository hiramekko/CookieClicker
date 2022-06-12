using UnityEngine;

public class ClickController : MonoBehaviour
{
    [Tooltip("クリック（ボタン）で増えるクッキーの数")]
    [SerializeField] int _addClickNum = 1;
    AudioSource _as;
    Animator _anim;

    void Start()
    {
        _anim = GetComponent<Animator>();
        _as = GetComponent<AudioSource>();
    }

    void Update()
    {
        if(Input.anyKeyDown)
        {
            GameManager.AddCookie(_addClickNum);
            _anim.SetTrigger("Pressed");
            _as.PlayOneShot(_as.clip); ;
        }
    }
}
