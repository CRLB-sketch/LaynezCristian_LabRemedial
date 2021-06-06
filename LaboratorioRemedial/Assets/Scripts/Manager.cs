using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    // --> Menu Pausa
    [SerializeField] private GameObject pauseMenu;
    bool isPaused = false;

    // --> Game Over
    [SerializeField] private Dragon dragonRed;
    [SerializeField] private GameObject gameOver;

    public bool IsPaused
    {
        get
        {
            return isPaused;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        // Para activar el menu de pausa
        if(Input.GetKeyDown(KeyCode.Escape))
            PauseMenu();

        // Si el dragon murio entonces se mostrará el Game Over
        if(!dragonRed)
            GameOver();
    }

    /// <summary>
    /// Pause Menu es para pausar el juego "congelando" el timepo
    /// </summary>
    public void PauseMenu()
    {
        isPaused = !isPaused;
        pauseMenu.SetActive(isPaused);
        Time.timeScale = isPaused ? 0.0f : 1.0f;
    }

    private void GameOver()
    {
        Time.timeScale = 0.0f;
        gameOver.SetActive(true);
    }
}
