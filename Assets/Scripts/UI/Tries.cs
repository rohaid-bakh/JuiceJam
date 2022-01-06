using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Tries : MonoBehaviour
{
    TMP_Text triesText;

    void Awake()
    {
        triesText = GetComponent<TMP_Text>();

        triesText.text += " test";
        Debug.Log("Deaths so far:");
    }

    void startNew()
    {

    }
}
