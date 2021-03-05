using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndMenu : MonoBehaviour {
    [SerializeField] GameObject menu;
    [SerializeField] GameObject GUI;
    [SerializeField] Text text;

    private void Start() {
        GameEvents.current.OnGameWon += Won;
        GameEvents.current.OnGameLost += Lost;
    }

    private void Won() {
        FinishGame(true);
    }

    private void Lost() {
        FinishGame(false);
    }

    private void FinishGame(bool state) {
        Cursor.visible = true;
        text.text = state ? "Victory" : "Game Over";
        text.color = state ? Color.green : Color.red;
        GUI.SetActive(false);
        Time.timeScale = 0f;
        menu.SetActive(true);
    }

    public void Restart() {
        SceneManager.LoadScene(1);
    }
}
