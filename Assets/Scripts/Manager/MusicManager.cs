using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public static MusicManager Instance;

    [Tooltip("0 : Main theme \n 1 : Exploration \n 2 : Explo Passe \n 3 : Explo Present")]
    public AudioClip[] musics; //0 main theme //1 exploration

    private AudioSource audioSource;

    private void Awake()
    {
        if (Instance != null)
        {
            GameObject.Destroy(Instance);
        }
        else
        {
            Instance = this;
        }
        DontDestroyOnLoad(this);

        audioSource = GetComponent<AudioSource>();

        ChangeMusic(0);
    }


    /// <summary>
    /// Change the music we wanted
    /// 0 : Main Theme
    /// 1 : Exploration
    /// </summary>
    /// <param name="musicWanted"></param>
    public void ChangeMusic(int index)
    {
        index = Mathf.Clamp(index, 0, musics.Length - 1);

        audioSource.clip = musics[index];

        audioSource.Play();
    }
}
