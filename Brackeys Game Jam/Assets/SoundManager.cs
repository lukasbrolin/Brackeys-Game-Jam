using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SoundManager : MonoBehaviour
{
    private static SoundManager _instance;
    public static SoundManager Instance { get { return _instance; } }

    private FMOD.Studio.EventInstance playMusicEvent;

    [Range(0,3)]
    [SerializeField]
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

    private void Start()
    {
        SetMusic();
    }

    public void SetMusic()
    {
        playMusicEvent.release();
        playMusicEvent = FMODUnity.RuntimeManager.CreateInstance(musicEvent);
        playMusicEvent.setParameterByName("MusicParts", index);
        playMusicEvent.start();
    }


    public void SetFloat(float value)
    {
        index = value;
        playMusicEvent.setParameterByName("MusicParts", index);
        playMusicEvent.release();
    }
}
