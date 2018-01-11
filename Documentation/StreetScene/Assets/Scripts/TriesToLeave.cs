using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriesToLeave : MonoBehaviour {

    public AudioClip triesToLeave;

    private bool voiceLine = false;
    private bool letterFinished = false;

    private void Start()
    {
        StartCoroutine(ExecuteAllowed());
    }

    private void OnTriggerEnter(Collider other)
    {
        if ((voiceLine == false) && (letterFinished == true))
        {
            GetComponent<AudioSource>().PlayOneShot(triesToLeave);
            voiceLine = true;
            StartCoroutine(ExecuteVoiceline());
        }
    }

    IEnumerator ExecuteVoiceline()
    {
        yield return new WaitForSecondsRealtime(5f);

        voiceLine = false;
    }

    IEnumerator ExecuteAllowed()
    {
        yield return new WaitForSecondsRealtime(41f);

        letterFinished = true;
    }

}
