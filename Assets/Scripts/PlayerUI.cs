using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour {
    [SerializeField] Text batteryAmount;
    private Player player;
    private Image charge;

    private void Start() {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        charge = GameObject.FindGameObjectWithTag("ChargeUI").GetComponent<Image>();
    }

    private void Update() {
        batteryAmount.text = "x" + player.batteryCount;
        var amount = (int) player.flashlight.currentCharge;
        var max = player.flashlight.maxCharge;
        charge.fillAmount = amount.Map(0, max, 0, 100) / 100f;
        if (charge.fillAmount <= 1 / 5f) {
            charge.color = Color.red;
        } else if (player.inArea) {
            charge.color = Color.yellow;
        } else {
            charge.color = Color.green;
        }
    }
}