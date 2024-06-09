using System;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
public class AudioManager : MonoBehaviour
{
    //needed sounds: Correct_InputSound, MoveSound, MoveOnKeySound, LoseSound, ButtonSound, MenuMusic
    public static AudioManager instance;
    public Sound[] Sounds;
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

        foreach (Sound s in Sounds)
        {
           s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
            s.source.mute = s.mute;
            s.source.playOnAwake = s.playOnAwake;
        }
        
    }
    //play menu music on start
    void Start()
    {
        
    }
    //function to play an audio clip
    public void Play (string name)
    {
        Debug.Log("PlaySound!");
        Sound s = Array.Find(Sounds, sounds => sounds.name == name);
        if (s == null)
        {
            Debug.Log("Bitch is Null");
            return;
        }
        s.source.Play();
    }
    //function to stop and audio clip
    public void Stop(string name)
    {
        Sound s = Array.Find(Sounds, sounds => sounds.name == name);
        if (s == null)
        {
            Debug.LogWarning("ERROR WITH" + name + ", SOUND IS NULL FOR THAT NAME.");
            return;
        }
        s.source.Stop();
    }
    public void enableFootsteps(bool x, string catName)
    {
        Sound s;
            //choosing sound.
            if(catName == "MommaPlayer" || catName == "MommaPlayer(Clone)")
            {
                 s = Array.Find(Sounds, sounds => sounds.name == "MommaWalking");
            }
            else
            {
                 s = Array.Find(Sounds, sounds => sounds.name == "BeanWalking");
            }
        //if enabling footsteps
        if (x)
        {
            if (s != null)
            {
                s.source.Play();
            }
        }
        //if disabling footsteps
        else
        {
            if(s != null)
            {
                s.source.Stop();
            }
        }
    }
}
