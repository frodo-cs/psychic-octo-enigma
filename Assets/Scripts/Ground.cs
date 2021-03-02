using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Ground : MonoBehaviour {
	[SerializeField] private int size = 15;
	[HideInInspector] public int spawnSize;
	private readonly int spawnMult = 7;

	private void Start() {
		transform.localScale = new Vector3(size, 1, size);
		spawnSize = size * spawnMult;
	}

	void Update() {
		transform.localScale = new Vector3(size, 1, size);
		spawnSize = size * spawnMult;
	}

    private void PlayerInWall() {
        
    }

    void OnDrawGizmosSelected() {
		Gizmos.color = new Color(1, 0, 0, 0.3f);
		Gizmos.DrawCube(transform.position, new Vector3(spawnSize, 2, spawnSize));
	}
}