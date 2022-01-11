using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class PauseMenu : MonoBehaviour
{
    [Header("Pause Menu")]
    [SerializeField] private GameObject PMenu;
    [SerializeField] private GameObject PButton;
    [SerializeField] private AudioSource audio;
    [SerializeField] private AudioLowPassFilter filter;

    [Header("Controls Menu")]
    [SerializeField] private GameObject Controls;

    [Header("UI SFX")]
    [SerializeField] private AudioClip[] clips = new AudioClip[2];
    //0 is default click // 1 is exit sound
    [SerializeField] private AudioSource source;
    public void OpenPause()
    {
        PMenu.SetActive(true);
        PButton.SetActive(false);
        Time.timeScale = 0f;
        audio.volume = .5f;
        filter.enabled = true;
    }

    public void ClosePause()
    {
        PMenu.SetActive(false);
        PButton.SetActive(true);
        Time.timeScale = 1f;
        audio.volume = 1f;
        filter.enabled = false;
    }

    public void OpenControls()
    {
        PMenu.SetActive(false);
        Controls.SetActive(true);
    }

    public void CloseControls()
    {
        Controls.SetActive(false);
        PMenu.SetActive(true);
    }

    public void PlayClick()
    {
        source.clip = clips[0];
        source.Play();
    }

    public void PlayClose()
    {
        source.clip = clips[1];
        source.Play();
    }

}
