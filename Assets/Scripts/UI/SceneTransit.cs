using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
public class SceneTransit : MonoBehaviour
{
    [Header("Audio")]
    [SerializeField] private AudioClip clip;
    [SerializeField] private AudioSource source;

    [Header("UI")]
    [SerializeField] private GameObject Pause;
    private Scene scene;
    float Timer;
    float MaxTimer;

    // [SerializeField] private Boss script;
    // void Update(){
    //     if(script.CurrHealth <= 0){
    //         EndScene();
    //     }
    // }
    public void EndScene(){
        Pause.SetActive(false);
        source.loop = false;
        source.clip = clip;
        source.Play();
        StartCoroutine(SceneTrans());
    }
    
    IEnumerator SceneTrans(){
        yield return new WaitForSeconds(clip.length);
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.buildIndex + 1);
    }

}
