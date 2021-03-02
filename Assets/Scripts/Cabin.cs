using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cabin : MonoBehaviour {
    void OnTriggerEnter(Collider collision) {
        Player player = collision.GetComponent<Player>();
        if (player) {
            GameEvents.current.GameWonTrigger();
        }
    }
}