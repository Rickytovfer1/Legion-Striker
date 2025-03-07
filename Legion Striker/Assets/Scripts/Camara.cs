using UnityEngine;

public class Camara : MonoBehaviour {

    public Transform objetivo;
    public float velocidad;
    public Vector3 camara;

    private void FixedUpdate() {
        Vector3 dPosicion = objetivo.position + camara;
        Vector3 sPosicion = Vector3.Lerp(transform.position, dPosicion, velocidad * Time.deltaTime);

        transform.position = sPosicion;
    }
}
