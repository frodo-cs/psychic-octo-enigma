using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour {

    [SerializeField] GameObject still;
    [SerializeField] GameObject text;

    private bool credits = false;

    private void Start() {
        Time.timeScale = 1f;
        Cursor.visible = true;
    }

    public void PlayGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ViewCredits() {
        credits = !credits;
    }

    public void ExitGame() {
        Application.Quit();
    }

    private void Update() {
        still.SetActive(!credits);
        text.SetActive(credits);
    }
}
