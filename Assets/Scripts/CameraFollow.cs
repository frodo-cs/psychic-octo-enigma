﻿using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {
	
	[SerializeField] Vector3 offset;
	[SerializeField] float speed;
	Transform target;

	private void Start() {
		target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update() {
		transform.position = new Vector3(target.position.x + offset.x, 0 + offset.y, target.position.z - offset.z);
		//transform.position = Vector3.Lerp(transform.position, t.position + offset, speed * Time.deltaTime);
	}
}