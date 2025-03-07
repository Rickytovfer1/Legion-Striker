using UnityEngine;
using UnityEngine.SceneManagement;
public class Menuganado : MonoBehaviour
{
    public void Jugar()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void Salir()
    {
        Application.Quit();
    }
}
