using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public Transform player;
    public TextMeshProUGUI PressToStart;
    [SerializeField] GameObject GameOverMenuUI;

    private Camera mainCamera;
    private bool gameStarted = false;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
        Time.timeScale = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameStarted)
        {
            CheckForInput();
        }
        else
        {
            CheckPlayerPosition();
        }
    }

    void CheckForInput()
    {
        // Herhangi bir girdi kontrolü (tuþ basýmý, fare týklamasý vb.)
        if (Input.anyKeyDown)
        {
            Destroy(PressToStart);
            StartGame();
        }
    }

    void StartGame()
    {
        gameStarted = true;
        Time.timeScale = 1f;
    }

    void CheckPlayerPosition()
    {
        float cameraBottomEdge = mainCamera.transform.position.y - mainCamera.orthographicSize;

        if (player.position.y < cameraBottomEdge)
        {
            GameOverMenu();
        }
    }

    void GameOverMenu()
    {
        GameOverMenuUI.SetActive(true);
        Time.timeScale = 0f;
    }
}
