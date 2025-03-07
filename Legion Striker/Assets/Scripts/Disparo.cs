using UnityEngine;

public class Disparo : MonoBehaviour {
    public Transform puntoDisparo;
    public GameObject bala;
    public PlayerController player;
    
    public AudioClip encasquilladoSonido;
    private AudioSource encasquilladoSource;

    void Start() {
        encasquilladoSource = gameObject.AddComponent<AudioSource>();
        encasquilladoSource.clip = encasquilladoSonido;
    }

    void Update() {
        if (Input.GetMouseButtonDown(0)) {
            if (player.municion != 0) {
                Instantiate(bala, puntoDisparo.position, transform.rotation);
                player.audioSource.PlayOneShot(player.disparo);
                player.municion -= 1;
            } else {
                encasquilladoSource.Play();
            }
        }
    }
}