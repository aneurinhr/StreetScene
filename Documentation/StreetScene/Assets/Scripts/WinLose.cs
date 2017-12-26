using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinLose : MonoBehaviour {

    private bool m_Win = false;

    public GameObject win;
    public GameObject lose;
    public GameObject menu;

    public AudioClip winAudio;
    public AudioClip loseAudio;

    public void GameOver()
    {
        menu.GetComponent<PauseMenu>().GameOver();

        CheckWin();
    }

    private void CheckWin()
    {
        if (m_Win == true)
        {
            GetComponent<AudioSource>().PlayOneShot(winAudio);
            win.SetActive(true);
        }
        else
        {
            GetComponent<AudioSource>().PlayOneShot(loseAudio);
            lose.SetActive(true);
        }
    }

    public void Win()
    {
        m_Win = true;
    }
}
