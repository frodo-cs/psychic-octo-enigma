using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

    [SerializeField] GameObject still;
    [SerializeField] GameObject credits;
    [SerializeField] GameObject controls;

    private bool credEnabled = false;
    private bool contEnabled = false;

    private void Start() {
        Time.timeScale = 1f;
        Cursor.visible = true;
    }

    public void PlayGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ViewCredits() {
        credEnabled = !credEnabled;
        contEnabled = false;
    }

    public void ViewControls() {
        contEnabled = !contEnabled;
        credEnabled = false;
    }

    private void Update() {
        still.SetActive(!credEnabled && !contEnabled);
        credits.SetActive(credEnabled && !contEnabled);
        controls.SetActive(contEnabled && !credEnabled);
    }
}
