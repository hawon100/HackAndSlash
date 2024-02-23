using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class BaseScene : MonoBehaviour
{
    public Define.Scene SceneType { get; protected set; } = Define.Scene.Unknown;

    private void Awake()
    {
        Init();
    }

    protected virtual void Init()
    {
        Object obj = GameObject.FindObjectOfType(typeof(EventSystem));
        Object audio = GameObject.FindObjectOfType(typeof(AudioManager));

        if (obj == null) Managers.Resource.Instantiate("UI/EventSystem").name = "@EventSystem";
        if (audio == null) Managers.Resource.Instantiate("Audio/AudioManager").name = "@AudioManager";
    }

    public abstract void Clear();
}
