using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UIElements;

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
        Debug.Log("Change value");

        masterMixer.SetFloat("Master", Mathf.Log10(value.newValue) * 25 + 5);

        if (SaveManager.instanceSaveManager)
            SaveManager.instanceSaveManager.SaveAudioLevel(0, value.newValue);

    }

    /// <summary>
    /// Set the audio of the musique level
    /// </summary>
    /// <param name="slider"></param>
    public void SetMusiqueLevel(Slider slider)
    {
        masterMixer.SetFloat("MusicVolume", Mathf.Log10(slider.value) * 25 + 5);

        if (SaveManager.instanceSaveManager)
            SaveManager.instanceSaveManager.SaveAudioLevel(1, slider.value);

    }

    /// <summary>
    /// Set the audio of the ambiance level
    /// </summary>
    /// <param name="slider"></param>
    public void SetDialogueVolume(Slider slider)
    {
        masterMixer.SetFloat("DialogueVolume", Mathf.Log10(slider.value) * 25 + 5);

        if (SaveManager.instanceSaveManager)
            SaveManager.instanceSaveManager.SaveAudioLevel(2, slider.value);
    }

    /// <summary>
    /// Set the audio of the effect level
    /// </summary>
    /// <param name="slider"></param>
    public void SetEffectLevel(Slider slider)
    {
        masterMixer.SetFloat("SFXVolume", Mathf.Log10(slider.value) * 25 + 5);

        if (SaveManager.instanceSaveManager)
            SaveManager.instanceSaveManager.SaveAudioLevel(3, slider.value);
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
