using UnityEngine;

public class Wall : MonoBehaviour {
    void OnTriggerEnter(Collider collision) {
        Player player = collision.GetComponent<Player>();
        if (player) {
            player.InArea(true);
        }
    }

    void OnTriggerExit(Collider collision) {
        Player player = collision.GetComponent<Player>();
        if (player) {
            player.InArea(false);
        }
    }
}