using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UIElements;
using static UnityEngine.Rendering.DebugUI;

public class AudioManager : MonoBehaviour
{
    #region Variables
    public static AudioManager AudioInstance { get; set; }

    public AudioMixer masterMixer;

    public Slider[] allSlider = new Slider[4];

    #endregion

    #region Built in Methods

    private void Awake()
    {
        AudioInstance = this;

    }

    private void Start()
    {
    }

    #endregion

    #region Customs Fonctions
    /// <summary>
    /// Set the audio of the master leve
    /// </summary>
    /// <param name="slider"></param>
    public void SetMasterLevel(ChangeEvent<float> value)
    {
        masterMixer.SetFloat("Master", value.newValue);

        if (SaveManager.instanceSaveManager)
            SaveManager.instanceSaveManager.SaveAudioLevel(0, value.newValue);

    }

    /// <summary>
    /// Set the audio of the musique level
    /// </summary>
    /// <param name="slider"></param>
    public void SetMusiqueLevel(ChangeEvent<float> value)
    {
        masterMixer.SetFloat("MusicVolume", value.newValue);

        if (SaveManager.instanceSaveManager)
            SaveManager.instanceSaveManager.SaveAudioLevel(1, value.newValue);

    }

    /// <summary>
    /// Set the audio of the ambiance level
    /// </summary>
    /// <param name="slider"></param>
    public void SetDialogueVolume(ChangeEvent<float> value)
    {
        masterMixer.SetFloat("DialogueVolume", value.newValue);

        if (SaveManager.instanceSaveManager)
            SaveManager.instanceSaveManager.SaveAudioLevel(2, value.newValue);
    }

    /// <summary>
    /// Set the audio of the effect level
    /// </summary>
    /// <param name="slider"></param>
    public void SetEffectLevel(ChangeEvent<float> value)
    {
        masterMixer.SetFloat("SFXVolume",value.newValue);

        if (SaveManager.instanceSaveManager)
            SaveManager.instanceSaveManager.SaveAudioLevel(3, value.newValue);
    }



    /// <summary>
    /// Load all the levels
    /// </summary>
    public void LoadAllLevel()
    {
        if (!SaveManager.instanceSaveManager) return;

        for (int i = 0; i < allSlider.Length; i++)
        {
            allSlider[i].SetValueWithoutNotify(SaveManager.allAudioLevels[i]);
        }
    }

    #endregion
}
