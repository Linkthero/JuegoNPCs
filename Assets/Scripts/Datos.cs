using UnityEngine;
using UnityEngine.SceneManagement;

public class Datos : MonoBehaviour
{
     public static Datos instance;


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
        SceneManager.LoadScene("");//NOMBRE DE LA ESCENA
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
