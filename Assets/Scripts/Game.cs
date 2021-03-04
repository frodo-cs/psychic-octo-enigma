using UnityEngine;

public class Game : MonoBehaviour {

    [SerializeField] Transform spawn;
    [SerializeField] Transform player;
    [SerializeField] AudioClip won;
    [SerializeField] AudioClip lost;
    private AudioSource sounds;

    private void Awake() {
        Time.timeScale = 1f;
        Cursor.visible = false;
        Instantiate(player, spawn);
    }

    private void Start() {
        spawn.localRotation = Quaternion.Euler(0, Random.Range(0f, 360), 0);
        sounds = GetComponent<AudioSource>();
        GameEvents.current.OnGameWon += Won;
        GameEvents.current.OnGameLost += Lost;
    }

    private void Won() {
        sounds.PlayOneShot(won, 0.5f);
    }

    private void Lost() {
        sounds.PlayOneShot(lost, 0.5f);
    }
}
