using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundOncollision : MonoBehaviour
{
    public string soundName;
    SoundManager soundManager;

    private void Start()
    {
        soundManager = FindObjectOfType<SoundManager>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        soundManager.Play(gameObject,soundName);
        Debug.Log(gameObject);
        Debug.Log(soundName);
    }
}
