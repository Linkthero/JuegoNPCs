using TMPro;
using UnityEngine;

public class Puntuación : MonoBehaviour
{
    private int puntos;
    [SerializeField] private TextMeshProUGUI txtPuntos;
    [SerializeField] private GameObject panelInfo;
    private int MaxPuntos = 5;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        puntos = 0;
        panelInfo.SetActive(true);
        Invoke(nameof(CerrarPanelInfo), 5f);
    }
    public void SumarPunto()
    {
        puntos++;
        txtPuntos.text = puntos.ToString();    
        if(puntos == MaxPuntos)
        {
            Datos.instance.ReiniciarNivel();
        }
    }
    private void Update()
    {
        if(puntos == MaxPuntos)
        {
            Datos.instance.finJuego = true;
            Datos.instance.FinJuego();
        }
    }

    private void CerrarPanelInfo()
    {
        panelInfo.SetActive(false);
    }

}
