using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterDisappear : MonoBehaviour {

	// Use this for initialization
	void Start () {
        StartCoroutine(ExecuteDisappear());
    }

    IEnumerator ExecuteDisappear()
    {
        yield return new WaitForSecondsRealtime(41f);

        gameObject.SetActive(false);
    }
}
