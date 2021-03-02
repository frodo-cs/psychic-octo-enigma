using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour {
    public int maxCharge = 30;
    public int mult = 1;
    public float currentCharge = 30;
    private Light lightbulb;
    private float batteryLoss = 1;
    private float intensity = 1.5f;
    public bool dying = false;

    private void Start() {
        lightbulb = GameObject.FindGameObjectWithTag("Light").GetComponent<Light>();
    }

    private void Update() {
        if (currentCharge >= 1) {
            currentCharge -= batteryLoss * Time.deltaTime * mult;

            if (!dying) {
                if (currentCharge <= (1 / 5f) * maxCharge) {
                    dying = true;
                    StartCoroutine(Flickering());
                } else if (currentCharge <= (1 / 4f) * maxCharge) {
                    lightbulb.intensity = intensity / 4;
                } else if (currentCharge <= (1 / 2f) * maxCharge) {
                    lightbulb.intensity = intensity / 2;
                } else if (currentCharge <= (3 / 4f) * maxCharge) {
                    lightbulb.intensity = (2 / 3f) * intensity;
                }
            } else {
                if (currentCharge > (1 / 4f) * maxCharge) {
                    dying = false;
                } else if (currentCharge < 1) {
                    lightbulb.intensity = 0;
                    dying = false;
                    GameEvents.current.GameLostTrigger();
                }
            }
            

            /*
            int bat = (int)(batteryLife);
            int v = bat.Map(0, batteryCharge, 0, 150);
            lightbulb.intensity = v/150.0f;
            */
        }
    }

    public bool BatteryDying() {
        return dying;
    }

    public void ChangeBattery() {
        StopAllCoroutines();
        currentCharge = maxCharge;
        dying = false;
        lightbulb.intensity = intensity;
    }

    public void ChangeLoss(bool b) {
        batteryLoss = b ? 2f : 1f;
    }

    IEnumerator Flickering() {
        while (dying) {
            yield return new WaitForSeconds(Random.Range(0.1f, 0.5f));
            lightbulb.enabled = !lightbulb.enabled;
        }
    }

}
