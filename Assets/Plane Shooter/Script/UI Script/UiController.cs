using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UiController : MonoBehaviour
{
    [SerializeField]
    private GameObject pauseGame;
    [SerializeField]
    private GameObject pauseButton;
    [SerializeField]
    private GameObject gameOverMenu;

    void Start()
    {
        pauseGame.SetActive(false);
        pauseButton.SetActive(true);
        gameOverMenu.SetActive(false);
    }

    void Update()
    {
        
    }

    public void PauseGame()
    {
        pauseGame.SetActive(true);
        pauseButton.SetActive(false);
        Time.timeScale = 0.0f;
    }

    public void ResumeGame()
    {
        pauseGame.SetActive(false);
        pauseButton.SetActive(true);
        Time.timeScale = 1.0f;
    }

    public void GameOver()
    {
        gameOverMenu.SetActive(true);
        pauseButton.SetActive(false);
        
    }

    public void TryAgain()
    {
        SceneManager.LoadScene("LEVEL 01");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void CharacterSelection()
    {
        SceneManager.LoadScene("Plane Selection");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
