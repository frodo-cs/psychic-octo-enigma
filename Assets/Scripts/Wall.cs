using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Wall : MonoBehaviour {
    void OnTriggerEnter(Collider collision) {
        Player player = collision.GetComponent<Player>();
        if (player) {
            player.InArea(true);
            Debug.Log("Player in area");
        }
    }

    void OnTriggerExit(Collider collision) {
        Player player = collision.GetComponent<Player>();
        if (player) {
            player.InArea(false);
            Debug.Log("Player out area");
        }
    }
}