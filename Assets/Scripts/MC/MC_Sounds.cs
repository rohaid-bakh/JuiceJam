using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[CreateAssetMenu(fileName = "MC_Sounds", menuName = "MC/MC_Sounds")]
public class MC_Sounds : ScriptableObject
{
    public AudioClip[] meleeSound;
    public AudioClip[] rangedSound;
    public AudioClip dodgeSound;
    public AudioClip hurtSound;
    public AudioClip emptySound;

    public AudioClip randomSound(string clip)
    {
        switch (clip)
        {
            case "Ranged":
                int index = (int)Random.Range(0f,(rangedSound.Length-1));
                return rangedSound[index];
                break;
            case "Melee":
                int index2 = (int)Random.Range(0f,(meleeSound.Length-1));
                return meleeSound[index2];
                break;
            default:
                return emptySound;
                break;
        }
    }

    

}
