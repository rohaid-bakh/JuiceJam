using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartButton : MonoBehaviour
{
    public int deathAmount = 0;

    public void OnButtonPress()
    {
        deathAmount++;

        Debug.Log("Restart button has been used.");

        //The scene name can be changed.
        SceneManager.LoadScene(sceneName: "Dungeon");
    }
}
