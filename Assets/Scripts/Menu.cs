using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{

    [SerializeField] private GameObject menuOpciones;
    [SerializeField] private GameObject Toggles;
    private Toggle toggleFacil;
    private Toggle toggleMedio;
    private Toggle toggleDificil;

    private void Start()
    {
        if (menuOpciones != null)
        {
            menuOpciones.SetActive(false);

            toggleFacil = Toggles.transform.GetChild(0).GetComponent<Toggle>();
            toggleMedio = Toggles.transform.GetChild(1).GetComponent<Toggle>();
            toggleDificil = Toggles.transform.GetChild(2).GetComponent<Toggle>();

            toggleFacil.isOn = true;
            toggleMedio.isOn = false;
            toggleDificil.isOn = false;
        }
        AudioManager.instance.PlayMenu();
    }

    public void Salir() {
        Application.Quit();
    }

    public void Jugar()
    {
        int dificultad;
        if (toggleFacil.isOn)
        {
            dificultad = 0;
        }
        else if (toggleMedio.isOn)
        {
            dificultad = 1;
        }
        else if (toggleDificil.isOn)
        {
            dificultad = 2;
        }
        else
        {
            dificultad = 0; // Por defecto, si no se selecciona nada, se elige facil
        }

        Datos.instance.SetDificultad(dificultad);
        SceneManager.LoadScene("Juego");
    }

    public void VolverAMenuPrincipal()
    {
        SceneManager.LoadScene("MenuPrincipal");
    }

    public void abrirMenuOpciones()
    {
         menuOpciones.SetActive(true);
    }

    public void Volver()
    {
        menuOpciones.SetActive(false);
    }

    public void ActivaToggleFacil()
    {
        toggleMedio.isOn = false;
        toggleDificil.isOn = false;
    }

    public void ActivaToggleMedio()
    {
        toggleFacil.isOn = false;
        toggleDificil.isOn = false;
    }

    public void ActivaToggleDificil()
    {
        toggleFacil.isOn = false;
        toggleMedio.isOn = false;
    }   
}
