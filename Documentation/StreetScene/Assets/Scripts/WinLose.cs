using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinLose : MonoBehaviour {

    private bool m_Win = false;

    public GameObject win;
    public GameObject lose;
    public GameObject menu;

    public void GameOver()
    {
        menu.GetComponent<PauseMenu>().GameOver();

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
