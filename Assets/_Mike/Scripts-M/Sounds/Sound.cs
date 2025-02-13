using UnityEngine.Audio;
using UnityEngine;

// Ref Brackeys.
// https://www.youtube.com/watch?v=6OT43pvUyfY

[System.Serializable]
public class Sound
{
    
    public string name;
    public AudioClip clip;
    public AudioMixerGroup mixerGroup;
    [Range(0f, 1f)] public float volume;
    [Range(0.1f, 3f)] public float pitch;
    public bool loop;
    

    [HideInInspector] public AudioSource source;
}
