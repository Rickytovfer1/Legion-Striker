using UnityEngine;

public class EnemigoVigilando : MonoBehaviour
{

    public Transform limiteIzq;
    public Transform limiteDech;

    public Transform enemigo;

    public float velocidad;
    private bool moverDerecha;

    public bool moviendose;

    public void Awake() {
        moviendose = true;
    }

    public void Update() {
        if (moviendose)
        {
            if (moverDerecha) {
                if (enemigo.position.x <= limiteDech.position.x) {
                    Move(1);
                }
                else {
                    CambioDireccion();
                }
            
            }
            else {
                if (enemigo.position.x >= limiteIzq.position.x) {
                    Move(-1);
                }
                else {
                    CambioDireccion();
                }
            }
        }
    }

    private void CambioDireccion() {
        moverDerecha = !moverDerecha;
    }

    private void Move(int direccion) {
        if (direccion == 1)
        {
            enemigo.transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else
        {
            enemigo.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        enemigo.position = new Vector3(enemigo.position.x + Time.deltaTime * direccion * velocidad, enemigo.position.y, enemigo.position.z);
    }
}