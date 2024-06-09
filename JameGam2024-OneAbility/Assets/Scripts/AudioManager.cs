using System;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
public class AudioManager : MonoBehaviour
{
    //needed sounds: Correct_InputSound, MoveSound, MoveOnKeySound, LoseSound, ButtonSound, MenuMusic
    public static AudioManager instance;
    public Sound[] sounds;
    //on Awake, check to make sure only one audio manager exists, then map each sound in the manager's values to the instances.
    void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);

        foreach (Sound s in sounds)
        {
           s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
            s.source.mute = s.mute;
        }
        
    }
    //play menu music on start
    void Start()
    {
        
    }
    //function to play an audio clip
    public void Play (string name)
    {
        Sound s = Array.Find(sounds, sounds => sounds.name == name);
        if (s == null)
            return;
        s.source.Play();
    }
    //function to stop and audio clip
    public void Stop(string name)
    {
        Sound s = Array.Find(sounds, sounds => sounds.name == name);
        if (s == null)
        {
            Debug.LogWarning("ERROR WITH" + name + ", SOUND IS NULL FOR THAT NAME.");
            return;
        }
        s.source.Stop();
    }

}
