using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void Salir() {
        Application.Quit();
    }

    public void ReiniciarNivel()
    {
        SceneManager.LoadScene("Juego");
    }

    public void VolverAMenuPrincipal()
    {
        SceneManager.LoadScene("MenuPrincipal");
    }
}
