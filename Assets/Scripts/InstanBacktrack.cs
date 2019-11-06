using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstanBacktrack : MonoBehaviour
{
    void Awake()
    {
        int backTracks = FindObjectsOfType<InstanBacktrack>().Length;
        if (backTracks > 1) Destroy(gameObject);
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

}
