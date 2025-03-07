using UnityEngine;
using UnityEngine.SceneManagement;

public class TiempoAcabado : MonoBehaviour
{
    public void Jugar()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 3);
    }

    public void Salir()
    {
        Application.Quit();
    }
}
