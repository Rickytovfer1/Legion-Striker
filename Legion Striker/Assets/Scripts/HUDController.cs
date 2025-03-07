using TMPro;
using UnityEngine;

public class HUDController : MonoBehaviour {
    public TextMeshProUGUI textoMunicion;
    public TextMeshProUGUI textoCorazon;
    public PlayerController player;
    
    void Update() {
        textoMunicion.text = "x" + player.municion;
        textoCorazon.text = "x" + player.vida;
    }
}
