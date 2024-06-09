using UnityEngine.Audio;
using UnityEngine;

/*
 * SOUND CLASS USED IN AUDIO MANAGER SCRIPT
 * ALLOWS US TO DEFINE TRAITS OF EACH AUDIO INSTANCE IN ONE MANAGER OBJECT
 */
[System.Serializable]
public class Sound
{
    public string name;
    public AudioClip clip;
    [Range(0f, 1f)]
    public float volume;

    [Range(0.1f, 3f)]
    public float pitch;

    [HideInInspector]
    public AudioSource source;

    public bool loop;
    public bool mute;
}
