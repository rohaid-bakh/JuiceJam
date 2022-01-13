using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScene : MonoBehaviour
{
    [SerializeField] private GameObject EScene;

    public void turnOnButton(){
        EScene.SetActive(true);
    }

    public void startOver(){
        SceneManager.LoadScene(0);
    }
}
