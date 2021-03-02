using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class Player : MonoBehaviour {
    [SerializeField] public int batteryCount;
    [SerializeField] Transform holder;
    [SerializeField] Transform fl;

    [HideInInspector] public Flashlight flashlight;
    [HideInInspector] public bool inArea;

    private void Start() {
        flashlight = Instantiate(fl, holder).GetComponent<Flashlight>();
    }

    private void Update() {
        if (flashlight.BatteryDying()) {
            if(batteryCount > 0) {
                flashlight.ChangeBattery();
                batteryCount--;
            }
        }
    }

    public void InArea(bool v) {
        inArea = v;
        flashlight.ChangeLoss(v);
    }

    public void PickupBattery() {
        batteryCount++;
    }

}