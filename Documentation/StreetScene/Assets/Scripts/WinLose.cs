using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinLose : MonoBehaviour {

    private bool m_Win = false;
    private bool m_Gameover = false;

    public GameObject win;
    public GameObject lose;
    public GameObject menu;

    public AudioClip winAudio;
    public AudioClip loseAudio;

    public void GameOver()
    {
        if (m_Gameover == false)
        {
            menu.GetComponent<PauseMenu>().GameOver();
            CheckWin();
        }

        m_Gameover = true;
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
