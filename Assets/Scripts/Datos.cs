using UnityEngine;
using UnityEngine.SceneManagement;

public class Datos : MonoBehaviour
{
     public static Datos instance;
    public bool finJuego = false;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            //DontDestroyOnLoad(gameObject);
        }

    }

    public void ReiniciarNivel()
    {
        SceneManager.LoadScene("Juego");
    }

    public void VolverAMenuPrincipal()
    {
        SceneManager.LoadScene("MenuPrincipal");
    }

    public void FinJuego()
    {
        SceneManager.LoadScene("FinJuego");
    }
}
