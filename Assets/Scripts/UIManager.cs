using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] public static GameObject winScreen { get; private set; }

    private void Awake()
    {
        gameOverScreen.SetActive(false);
    }
    //Activate game over screen
    public void GameOver()
    {
        gameOverScreen.SetActive(true);
    }
    //Activate you win screen(functions are the same but different UI)
    public void YouWin()
    {
        winScreen.SetActive(true);
    }

    //Game over functions
    public void Restart()
    {
        SceneManager.LoadScene("Game");
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void BackToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
