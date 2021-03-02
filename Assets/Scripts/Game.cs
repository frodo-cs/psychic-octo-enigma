using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour {

    [SerializeField] Transform spawn;
    [SerializeField] Transform player;

    private void Awake() {
        Time.timeScale = 1f;
        Cursor.visible = false;
        Instantiate(player, spawn);
    }
}
