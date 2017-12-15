using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinLose : MonoBehaviour {

    private bool m_Win = false;

    public GameObject win;
    public GameObject lose;

    public void GameOver()
    {
        Time.timeScale = 0;

        CheckWin();
    }

    private void CheckWin()
    {
        if (m_Win == true)
        {
            win.SetActive(true);
        }
        else
        {
            lose.SetActive(true);
        }
    }

    public void Win()
    {
        m_Win = true;
    }
}
