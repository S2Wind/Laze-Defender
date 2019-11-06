using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
public class SceneManament : MonoBehaviour
{
    [SerializeField] AudioClip press;
    public void PressPlayButton()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        StartCoroutine(PressSound());
        SceneManager.LoadScene(currentScene + 1);
    }
    public void PressRestartButton()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        StartCoroutine(PressSound());
        SceneManager.LoadScene(currentScene);
    }
    public void PressQuitButton()
    {
        StartCoroutine(PressSound());
        Application.Quit();
    }
    
    IEnumerator PressSound()
    {
        GetComponent<AudioSource>().PlayOneShot(press);
        yield return new WaitForSeconds(0.5f);
    }
}
