using System.Collections;
using UnityEngine;

public class AutoMakeCookie : MonoBehaviour
{
    [Tooltip("クッキーが増える間隔")]
    [SerializeField] float _interval = 0.5f;
    [Tooltip("自動で増えるクッキーの数")]
    [SerializeField] long _autoAddCookie = 1;

    void Start()
    {
        StartCoroutine(MakeCookie());
    }

    IEnumerator MakeCookie()
    {
        while (true)
        {
            if (_interval <= 0.001f)
            {
                break;
            }
            yield return new WaitForSeconds(_interval);
            GameManager.AddCookie(_autoAddCookie);
        }
    }
}