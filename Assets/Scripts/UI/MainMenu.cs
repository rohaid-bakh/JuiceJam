using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [Header("UI elements")]
    [SerializeField] private GameObject MMenu;
    [SerializeField] private GameObject BG;
    [SerializeField] private GameObject ControlMenu;
    [SerializeField] private GameObject CreditsMenu;

    [Header("Start Objects")]
    [SerializeField] private GameObject Boss;
    [SerializeField] private MonoBehaviour[] PlayerScripts;
    [SerializeField] private AudioSource Sound;
    [SerializeField] private GameObject GUI;

    public void StartGame()
    {
        BG.SetActive(false);
        for (int i = 0; i < PlayerScripts.Length; i++)
        {
            PlayerScripts[i].enabled = true;
        }
        Boss.SetActive(true);
        GUI.SetActive(true);
        Sound.Play();
    }

    public void OpenControls()
    {
        MMenu.SetActive(false);
        ControlMenu.SetActive(true);
    }

    public void CloseControls()
    {
        ControlMenu.SetActive(false);
        MMenu.SetActive(true);
    }

    public void OpenCredits()
    {
        MMenu.SetActive(false);
        CreditsMenu.SetActive(true);
    }

    public void CloseCredits()
    {
        CreditsMenu.SetActive(false);
        MMenu.SetActive(true);
    }
}
