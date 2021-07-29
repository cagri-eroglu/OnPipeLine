using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicContoller : MonoBehaviour
{
    [SerializeField]
    private bool musicEnable;
    [SerializeField]
    private AudioSource music;

    private void Awake()
    {
        musicEnable = true;
    }
    public void ToggleMusic()
    {
        if (!musicEnable)
        {
            music.Play();
            musicEnable = true;
        }
        else
        {
            music.Pause();
            musicEnable = false;
        }
    }
}
