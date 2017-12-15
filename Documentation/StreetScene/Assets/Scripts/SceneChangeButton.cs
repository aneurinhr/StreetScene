using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeButton : MonoBehaviour {

    public string nextScene;
    //public AudioClip button;

    public void Activate()
    {
        if (nextScene == "Quit")
        {
            //GetComponent<AudioSource>().PlayOneShot(button);
            StartCoroutine(ExecuteQuit());
        }
        else
        {
            //GetComponent<AudioSource>().PlayOneShot(button);
            StartCoroutine(ExecuteReset());
        }
    }

    IEnumerator ExecuteReset()
    {
        yield return new WaitForSecondsRealtime(0.3f);

        Time.timeScale = 1.0f;
        SceneManager.LoadScene(nextScene);
    }

    IEnumerator ExecuteQuit()
    {
        yield return new WaitForSecondsRealtime(0.3f);

        Application.Quit();
    }

}
