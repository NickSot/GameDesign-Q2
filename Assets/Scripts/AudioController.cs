using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController: MonoBehaviour
{
    private static AudioController instance = null;
    public AudioSource audio;
    public AudioSource audio1;
    public AudioSource audio2;

    private int audioSource = 1;

    private void Awake()
    {
        if (instance == null)
        { 
            instance = this;
            DontDestroyOnLoad(gameObject);
            return;
        }
        
        if (instance == this) return; 
        Destroy(gameObject);
    }

    void LateUpdate() {
        if (!audio.isPlaying && !audio1.isPlaying && !audio2.isPlaying) {
            switch (audioSource) {
                case 0:
                    audio.Play();
                    break;
                case 1:
                    audio1.Play();
                    break;
                case 2:
                    audio2.Play();
                    break;
            }

            audioSource = (audioSource + 1) % 3;
        }
    }

    void Start()
    {
        
    }
}
