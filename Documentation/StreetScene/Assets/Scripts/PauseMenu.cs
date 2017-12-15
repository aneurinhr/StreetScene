using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class PauseMenu : MonoBehaviour {

    public bool menuOpen = false;
    public bool gameOver = false;

    public GameObject pauseMenu;
    public GameObject player;

    private MouseLook m_MouseLook;

    private void Start()
    {
        m_MouseLook = player.GetComponent<FirstPersonController>().GetMouseLook();
    }

    // Update is called once per frame
    void Update () {
		
        if ((Input.GetButtonDown("Cancel")) && (gameOver == false))
        {
            menuOpen = !menuOpen;

            if (menuOpen == true)
            {
                Time.timeScale = 0;
                m_MouseLook.SetCursorLock(false);
                pauseMenu.SetActive(true);
            }
            else
            {
                Time.timeScale = 1;
                m_MouseLook.SetCursorLock(true);
                pauseMenu.SetActive(false);
            }

        }

	}

    public void GameOver()
    {
        gameOver = true;
        Time.timeScale = 0;
        m_MouseLook.SetCursorLock(false);
        pauseMenu.SetActive(true);
    }

}
