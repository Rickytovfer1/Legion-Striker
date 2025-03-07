using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Tiempo : MonoBehaviour
{
    [SerializeField] int min, segundo;
    [SerializeField] private Text texto;

    private float restante;
    private bool inicializado;

    private void Awake()
    {
        restante = (min * 60) + segundo;
        inicializado = true;
    }
    void Update()
    {
        if (inicializado)
        {
            restante -= Time.deltaTime;
            if (restante < 1 )
            {
                inicializado = true;
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 3);

            }
            int tiempoMin = Mathf.FloorToInt(restante / 60);
            int tiempoSegundo = Mathf.FloorToInt(restante % 60);
            texto.text = string.Format("{00:00}:{01:00}", tiempoMin, tiempoSegundo);    
        }
    }
}
