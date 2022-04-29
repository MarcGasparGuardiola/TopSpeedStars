using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;
public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPaused = false;
    public GameObject pauseMenuPanel;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (PauseMenu.gameIsPaused)
            {
                Resume();
            } else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuPanel.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
    }
    void Pause()
    {
        pauseMenuPanel.SetActive(true);
        // TODO dont pause when online
        if (PhotonNetwork.CurrentRoom == null)
        {
            Time.timeScale = 0f;
        }
        gameIsPaused = true;
    }

    public void LoadMenu() 
    {
        Time.timeScale = 1f;
        gameIsPaused = false;
        if (PhotonNetwork.CurrentRoom != null)
        {
            PhotonNetwork.Disconnect();
        }
        SceneManager.LoadScene("ResultsList");
    }
    public void QuitGame() 
    {
        Application.Quit();
    }
}
