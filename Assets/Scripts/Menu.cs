using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void Salir() {
        Application.Quit();
    }

    public void ReiniciarNivel()
    {
        SceneManager.LoadScene("");//NOMBRE DE LA ESCENA
    }

    public void VolverAMenuPrincipal()
    {
        SceneManager.LoadScene("MenuPrincipal");
    }
}
