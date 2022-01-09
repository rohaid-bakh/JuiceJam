using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SteamSound", menuName = "Boss/Steam_Sounds")]
public class SteamSound : ScriptableObject
{
    public AudioClip steamSound;
    public AudioClip bulletSound;
    public AudioClip hurtSound;

}
