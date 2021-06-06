using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuOptions : MonoBehaviour
{
    /// <summary>
    /// Start Game es llamado para ejecutar la escena del juego para jugar
    /// </summary>
    /// <param name="sceneName">Nombre de la escena que se cargará</param>
    public void LoadLevel(int numberScence)
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(numberScence);
    }

    /// <summary>
    /// Quit Game es llamado cuando se quiera salir del juego
    /// </summary>
    public void QuitGame()
    {
        // Por si estamos dentro del editor de Unity
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;

        // Por si estamos en el juego como tal
        #else
            Application.Quit();

        #endif
    }
}
