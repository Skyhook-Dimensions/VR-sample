using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public List<Sound> sounds;

    public void Play(GameObject thisObj, string name)
    {
        foreach(Sound sound in sounds)
        {
            if (sound.name.Equals(name))
            {
                AudioSource source = thisObj.AddComponent<AudioSource>();
                source.clip = sound.clip;
                source.volume = 1;
                source.loop = source.loop;
                source.spatialBlend = 1;
                source.Play();
                break;
            }
        }
    }
}
