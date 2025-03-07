using UnityEngine;

public class Bala : MonoBehaviour {

    private Rigidbody2D rb2d;
    public float velocidad;
    public float distanciaMax = 50f;
    private Vector2 posicionInicial;
    
    void Start() {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.linearVelocity = transform.right * velocidad;
        posicionInicial = transform.position;
    }

    void Update() {
        if (Vector2.Distance(posicionInicial, transform.position) > distanciaMax) {
            Destroy(gameObject);
        }
    }
    
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Terreno")) {
            Destroy(gameObject);
        } else if (collision.gameObject.CompareTag("Enemy")) {
            collision.gameObject.GetComponent<EnemigoAtaque>().RecibirImpacto();
            Destroy(gameObject);
        } else if (collision.gameObject.CompareTag("Player")) {
            collision.gameObject.GetComponent<PlayerController>().RecibirImpacto();
            Destroy(gameObject);
        }
    }
}