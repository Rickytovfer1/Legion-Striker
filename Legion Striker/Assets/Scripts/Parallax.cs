using UnityEngine;

public class Parallax : MonoBehaviour {

    private float longitud, posInicial;
    public GameObject camara;
    public float parallaxEffect;
    
    void Start() {
        posInicial = transform.position.x;
        longitud = GetComponent<SpriteRenderer>().bounds.size.x;
    }
    
    void Update() {
        float temp = camara.transform.position.x * (1 - parallaxEffect);
        
        float dsitancia = camara.transform.position.x * parallaxEffect;
        
        transform.position = new Vector3(posInicial + dsitancia, transform.position.y, transform.position.z);

        if (temp > posInicial + longitud) {
            posInicial += longitud;
        }
        else if (temp < posInicial - longitud) {
            posInicial -= longitud;
        }
        
    }
}
