using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Still : MonoBehaviour {

    [SerializeField] Transform still;
    [SerializeField] float speed = 1f;

    void Update() {
        transform.localRotation *= Quaternion.AngleAxis(speed * Time.deltaTime, Vector3.up);
    }
}
