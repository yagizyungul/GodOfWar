using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenuUI;

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f; // Oyun zaman�n� normale d�nd�r
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f; // Oyun zaman�n� durdur
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Resume();
    } 
    public void QuitGame()//�imdilik ana men� olmad���ndan oyunu kapat�yor
    {
        SceneManager.LoadScene(0); // Oyunu kapat
    }
}
