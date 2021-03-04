using UnityEngine;

public class Cabin : MonoBehaviour {
    void OnTriggerEnter(Collider collision) {
        Player player = collision.GetComponent<Player>();
        if (player) {
            GameEvents.current.GameWonTrigger();
        }
    }
}