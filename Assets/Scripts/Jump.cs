using UnityEngine;

public class Jump : MonoBehaviour {
    [SerializeField] AudioClip clip;   
    [SerializeField] float vol;
    private AudioSource source;
    private Collider col;

    private void Start() {
        source = GetComponent<AudioSource>();
        col = GetComponent<SphereCollider>();
    }

    void OnTriggerEnter(Collider collision) {
        Player player = collision.GetComponent<Player>();
        if (player) {
            Remove();
        }
    }

    private void Remove() {
        col.enabled = false;
        source.PlayOneShot(clip, vol);
    }
}
