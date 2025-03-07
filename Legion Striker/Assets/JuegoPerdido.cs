using UnityEngine;
using UnityEngine.SceneManagement;

public class JuegoPerdido : MonoBehaviour
{
    public void Jugar()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
    }

    public void Salir()
    {
        Application.Quit();
    }
}
