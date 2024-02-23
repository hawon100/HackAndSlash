using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

[System.Serializable]
public class SFXClip
{
    public string name;
    public AudioClip clip;
}

public class AudioManager : MonoBehaviour
{
    public AudioMixer mixer;
    public AudioSource bgSound;
    public AudioClip[] bglist;
    public SFXClip[] sfxlist;

    private static AudioManager instance;

    public void Init()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        for(int i = 0; i < bglist.Length; i++)
        {
            if(scene.name == bglist[i].name)
            {
                BGSoundPlay(bglist[i]);
            }
        }
    }

    public void BGSoundVolume(float val)
    {
        mixer.SetFloat("BGSound", Mathf.Log10(val) * 20);
    }

    public void SFXSoundVolume(float val)
    {
        mixer.SetFloat("SFXSound", Mathf.Log10(val) * 20);
    }

    public void SFXPlay(string sfxName, AudioClip clip)
    {
        GameObject go = new GameObject(sfxName + "Sound");
        AudioSource audioSource = go.AddComponent<AudioSource>();
        audioSource.outputAudioMixerGroup = mixer.FindMatchingGroups("SFX")[0];
        audioSource.clip = clip;
        audioSource.Play();

        Destroy(go, clip.length);
    }

    public void BGSoundPlay(AudioClip clip)
    {
        bgSound.outputAudioMixerGroup = mixer.FindMatchingGroups("BGSound")[0];
        bgSound.clip = clip;
        bgSound.loop = true;
        bgSound.volume = 0.1f;
        bgSound.Play();
    }
}