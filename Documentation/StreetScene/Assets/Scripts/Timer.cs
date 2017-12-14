using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    public float timer;
    public float timeLimit;

    // Use this for initialization
    void Start () {
        timer = timeLimit;
    }
	
	// Update is called once per frame
	void Update () {

        timer = timer - Time.deltaTime;

        if (timer < 0.0f)
        {
            //GameOver
        }

        gameObject.GetComponent<Image>().fillAmount = (1 / timeLimit) * timer;

    }
}
