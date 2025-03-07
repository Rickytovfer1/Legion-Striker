using UnityEngine;

public class EnemigoAtaque : MonoBehaviour {
    private float cooldown = 1f;
    private float rangoX;
    private float rango2X;
    private int daño;

    private float distanciaColision;
    private BoxCollider2D boxCollider;
    private LayerMask layer;
    private float tempCooldown = Mathf.Infinity;
    
    public Animator animator;
    public EnemigoVigilando enemigoVigilando;
    
    public PlayerController player;
    public GameObject bala;

    public Transform puntoDisparo;
    private bool persiguiendo;

    private int vida;
    
    public float distanciaParaParar = 7f;
    public float velocidadPersecucion = 1f;

    private int direccion;
    private LayerMask sueloLayer; 
    
    private AudioSource audioSource;
    
    
    public void Awake() {
        animator = GetComponent<Animator>();
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        player = playerObj.GetComponent<PlayerController>();
        audioSource = GetComponent<AudioSource>();

        vida = 3;
        persiguiendo = false;
        sueloLayer = LayerMask.GetMask("Suelo");
    }

    void Update() {
        float dist = Mathf.Abs(player.transform.position.x - transform.position.x);
        
        rangoX = transform.position.x - 9f;
        rango2X = transform.position.x + 9f;

        if (JugadorVisto()) {
            persiguiendo = true;
            animator.SetBool("Disparando", true);
            enemigoVigilando.moviendose = false;
            if (player.transform.position.x > transform.position.x) {
                transform.rotation = Quaternion.Euler(0, 180, 0);
                puntoDisparo.transform.rotation = Quaternion.Euler(0, 0, 0);
                direccion = 1;
            } else {
                transform.rotation = Quaternion.Euler(0, 0, 0);
                puntoDisparo.transform.rotation = Quaternion.Euler(0, 180, 0);
                direccion = -1;
            }
            
            if (persiguiendo && dist >= distanciaParaParar && HaySueloDelante())
            {
                transform.position = new Vector3(transform.position.x + Time.deltaTime * direccion * velocidadPersecucion, transform.position.y, transform.position.z);
                if (dist >= 16f) {
                    persiguiendo = false;
                }
            }
            
            tempCooldown += Time.deltaTime;
            if (tempCooldown >= cooldown) {
                Instantiate(bala, puntoDisparo.position, puntoDisparo.rotation);
                audioSource.PlayOneShot(audioSource.clip);
                tempCooldown = 0f;
            }

            
        } else {
            persiguiendo = false;
            animator.SetBool("Disparando", false);
            if (vida > 0) {
                enemigoVigilando.moviendose = true;
            }
        }
    }

    public void RecibirImpacto()
    {
        vida--;
        if (vida <= 0)
        {
            enemigoVigilando.moviendose = false;
            animator.SetBool("Muerto", true);
            Destroy(gameObject, 1.4f);
            Destroy(enemigoVigilando.gameObject, 1.4f);
        }
    }

    private bool JugadorVisto()
    {
        if (player.transform.position.x >= rangoX && player.transform.position.x <= rango2X && vida > 0) {
            return true;
        }
        return false;
    }
    
    private bool HaySueloDelante() {
        Vector2 posicionRaycast = new Vector2(transform.position.x + (direccion * 0.5f), transform.position.y);
        RaycastHit2D hit = Physics2D.Raycast(posicionRaycast, Vector2.down, 1f, sueloLayer);

        return hit.collider;
    }
}
