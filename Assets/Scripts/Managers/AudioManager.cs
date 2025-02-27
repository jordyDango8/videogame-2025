using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    #region variables
    internal static AudioManager audioManager;

    [SerializeField]
    SoundInfo[] sounds;

    [SerializeField]
    AudioMixerGroup audioMixerGroup;

    [SerializeField]
    AudioMixer audioMixer;

    float volume;

    #endregion

    void Awake()
    {
        if (audioManager == null)
        {
            audioManager = this;
            Debug.Log($"audiomanager = {audioManager}");

            foreach (SoundInfo sound in sounds)
            {
                sound.name = sound.clip.name;

                sound.source = gameObject.AddComponent<AudioSource>();
                sound.source.clip = sound.clip;
                sound.source.playOnAwake = sound.playOnAwake;
                sound.source.loop = sound.loop;
                sound.source.volume = sound.volume;
                sound.source.pitch = sound.pitch;

                sound.source.outputAudioMixerGroup = audioMixerGroup;
            }
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    internal void Play(EnumManager.Audio _name)
    {
        //Debug.Log($"play {_name}");
        AudioSource soundTemp = Search(_name).source;  //marca error y se detiene, ver por qué
        if (soundTemp != null)
        {
            soundTemp.Play();
        }
    }

    internal void Stop(EnumManager.Audio _name)
    {
        AudioSource soundTemp = Search(_name).source;
        if (soundTemp != null)
        {
            StartCoroutine(FadeOut(soundTemp, 1, 0));
        }
    }

    internal float GetAudioDuration(EnumManager.Audio _name)
    {
        AudioSource soundTemp = Search(_name).source;
        if (soundTemp)
        {
            return soundTemp.clip.length;
        }
        return 0;
    }

    internal SoundInfo Search(EnumManager.Audio _name)
    {
        string name = _name.ToString();
        foreach (SoundInfo sound in sounds)
        {
            if (sound.clip.name == name)
            {
                //Debug.Log("encontré");     
                return sound;
            }
            //Debug.Log("buscando...");
        }
        Debug.LogWarning($"sound {name} not found!!!");
        return null;
    }

    IEnumerator FadeOut(AudioSource _audioSource, float duration, float targetVolume)
    {
        float currentTime = 0;
        float startVolume = _audioSource.volume;
        while (currentTime < duration)
        {
            currentTime += Time.deltaTime;
            _audioSource.volume = Mathf.Lerp(startVolume, targetVolume, currentTime / duration);
            yield return null;
        }
        _audioSource.Stop();
        _audioSource.volume = startVolume;
        //yield break;
    }

    internal void ChangeMasterVolume(float _newVolume)
    {
        audioMixer.SetFloat(EnumManager.floatType.volume.ToString(), _newVolume);
    }

    internal void SetVolume(float _newValue)
    {
        volume = _newValue;
        SaveVolume(_newValue);
        ChangeMasterVolume(volume);
    }

    void SaveVolume(float _newValue)
    {
        PlayerPrefs.SetFloat(EnumManager.floatType.volume.ToString(), _newValue);
    }

    internal float GetVolume()
    {
        LoadVolume();
        return volume;
    }

    void LoadVolume()
    {
        volume = PlayerPrefs.GetFloat(EnumManager.floatType.volume.ToString(), -10); // -80 a 0 default
    }

}
