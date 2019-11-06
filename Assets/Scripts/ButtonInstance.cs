using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonInstance : MonoBehaviour
{
    void Awake()
    {
        int buttonManagers = FindObjectsOfType<ButtonInstance>().Length;
        if (buttonManagers > 1) Destroy(gameObject);
        else
            DontDestroyOnLoad(gameObject);
    }
}
