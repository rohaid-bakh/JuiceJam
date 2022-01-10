using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hearts : MonoBehaviour
{
     
    [SerializeField] private Image[] hearts;
    [SerializeField] private Sprite heart;
    [SerializeField] private PlayerHealth script; 

    void Update(){
        for(int i = 0; i< hearts.Length; i++){
            if(i<script.currentHealth){
                hearts[(hearts.Length-1)-i].enabled = true;
            } else {
                hearts[(hearts.Length-1)-i].enabled = false;
            }
        }
    }
}
