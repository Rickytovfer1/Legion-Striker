using UnityEngine;

public class DisparoEnemigo : MonoBehaviour
{
    public Transform puntoDisparo2;
    public GameObject Enemy;
    public GameObject Manolo;
    public GameObject bala;

    private float LastShoot;

    void Update() {
        // float distanceToEnemy = Mathf.Abs(Enemy.transform.position.x - transform.position.x);
        // float distanceToManolo = Vector3.Distance(Manolo.transform.position, transform.position);
        //
        // if (distanceToEnemy < 1.0f && distanceToManolo < 10.0f && Time.time > LastShoot + 1.0f)
        // {
        //     Vector3 shootPosition = Enemy.transform.position + new Vector3(0.5f * Mathf.Sign(transform.localScale.x), 0, 0);
        //     puntoDisparo2.position = shootPosition;
        //
        //     Quaternion rotacionBala = transform.localScale.x < 0 ? Quaternion.Euler(0, 180, 0) : Quaternion.identity;
        //     Instantiate(bala, puntoDisparo2.position, rotacionBala);
        //     LastShoot = Time.time;
        // }
    }
}