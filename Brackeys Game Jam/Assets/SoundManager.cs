using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private static SoundManager _instance;
    public static SoundManager Instance { get { return _instance; } }

    [Range(0, 3)]
    public float index;
    [SerializeField]
    public float volume;

    [FMODUnity.EventRef]
    [SerializeField]
    private string musicEvent;

    private void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Sound");

        if(objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);

        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }

    }

    private void Update()
    {
        SetMusic();
    }

    void SetMusic()
    {
        FMOD.Studio.EventInstance playMusicEvent;
        playMusicEvent = FMODUnity.RuntimeManager.CreateInstance(musicEvent);
        playMusicEvent.setParameterByName("MusicParts", index);
        playMusicEvent.setParameterByName("MusicVolume", volume);
        playMusicEvent.start();
        //playMusicEvent.release();
    }
}
