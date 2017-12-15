using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    public float timer;
    public float timeLimit;

    public GameObject lose;

    // Use this for initialization
    void Start () {
        timer = timeLimit;
    }
	
	// Update is called once per frame
	void Update () {

        timer = timer - Time.deltaTime;

        if (timer < 0.0f)
        {
            lose.GetComponent<WinLose>().GameOver();
        }

        gameObject.GetComponent<Image>().fillAmount = (1 / timeLimit) * timer;

    }
}
