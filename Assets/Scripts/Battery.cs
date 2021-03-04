using UnityEngine;

public class Battery : MonoBehaviour {

    [SerializeField] AudioClip effect;

    void OnTriggerEnter(Collider collision) {
        Player player = collision.GetComponent<Player>();
        if (player) {
            player.PickupBattery();
            Remove();
        }
    }

    private void Remove() {
        Destroy(gameObject);
        AudioSource.PlayClipAtPoint(effect, transform.position);
    }
}
