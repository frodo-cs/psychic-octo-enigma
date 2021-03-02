using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

    public static bool GamePaused = false;
    [SerializeField] GameObject pauseUI;
    [SerializeField] GameObject GUI;

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {           
            if (GamePaused) {
                Resume();
            } else {
                Pause();
            }
        }
    }

    private void Pause() {
        Cursor.visible = true;
        GUI.SetActive(false);
        pauseUI.SetActive(true);
        Time.timeScale = 0f;
        GamePaused = true;
    }

    public void Resume() {
        Cursor.visible = false;
        GUI.SetActive(true);
        pauseUI.SetActive(false);
        Time.timeScale = 1f;
        GamePaused = false;
    }

    public void MainMenu() {
        SceneManager.LoadScene("Menu");
    }

    public void Exit() {
        Application.Quit();
    }
}
