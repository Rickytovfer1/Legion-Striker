using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

    public Rigidbody2D rb2d;
    public Animator animator;
    public bool estaCorriendo;
    public float velocidad;
    
    public LayerMask suelo;
    public Transform sensorSuelo;
    public float fuerzaSalto;
    private bool tocaSuelo;

    public AudioClip recargaSonido;
    public AudioSource audioSource;
    
    public AudioClip impactoSonido;
    public AudioClip disparo;
    private AudioSource audioSourceImpacto;

    public AudioClip checkpointSonido;
    private AudioSource checkponintSource;

    public int municion = 6;
    public int vida = 3;

    public Transform ultimoCheckpoint;

    void Start() {
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        
        rb2d.freezeRotation = true;
        audioSource = GetComponent<AudioSource>();
        audioSourceImpacto = GetComponent<AudioSource>();
        checkponintSource = GetComponent<AudioSource>();
    }

    void Update() {
        Move();
    }

    void Move() {

        if (Input.GetKeyDown(KeyCode.D)) {
            animator.SetBool("corriendo", true);
            velocidad = 2.5f;
            estaCorriendo = true;
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }

        if (Input.GetKeyUp(KeyCode.D)) {
            animator.SetBool("corriendo", false);
            estaCorriendo = false;
        }

        if (Input.GetKeyDown(KeyCode.A)) {
            animator.SetBool("corriendo", true);
            velocidad = -2.5f;
            estaCorriendo = true;
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }

        if (Input.GetKeyUp(KeyCode.A)) {
            animator.SetBool("corriendo", false);
            estaCorriendo = false;
        }

        if (estaCorriendo) {
            rb2d.linearVelocity = new Vector2(velocidad, rb2d.linearVelocity.y);
        }

        if (tocaSuelo) {
            if (Input.GetKeyDown(KeyCode.Space)) {
                rb2d.AddForce(new Vector2(0, fuerzaSalto));
            }
        }
    }

    public void FixedUpdate() {
        tocaSuelo = Physics2D.OverlapCircle(sensorSuelo.position, 0.2f, suelo);
        animator.SetBool("saltando", !tocaSuelo);
    }
    
    public void RecibirImpacto() {
        if (vida >= 0)
        {
            vida--;
            if (audioSourceImpacto != null && impactoSonido != null)
            {
                audioSourceImpacto.PlayOneShot(impactoSonido);
            }
        
            if (vida <= 0) {
                animator.SetBool("muerto", true);
                Destroy(gameObject, 1.8f);
                Invoke("CambiarEscena", 1);
            }
        }
        
    }
    
    void CambiarEscena() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }
    
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Municion")) {
            municion += 6; 

            if (audioSource != null && recargaSonido != null) {
                audioSource.PlayOneShot(recargaSonido); 
            }

            Destroy(collision.gameObject);
            
        } else if (collision.CompareTag("Limite")) {
            RecibirImpacto();
            Respawn(ultimoCheckpoint); 
        } else if (collision.CompareTag("Checkpoint")) {
            ultimoCheckpoint = collision.transform;
            checkponintSource.PlayOneShot(checkpointSonido);
            
        } else if (collision.CompareTag("Vida")) {
            vida++;
            Destroy(collision.gameObject);
        }
    }

    private void Respawn(Transform checkpoint) {
 
        try {
            transform.position = checkpoint.position;
        }
        catch (UnassignedReferenceException) {
            transform.position = new Vector2(-7.91f, -2.49f);
        }
    }

}