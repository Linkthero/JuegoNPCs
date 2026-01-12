using TMPro;
using UnityEngine;

public class Puntuación : MonoBehaviour
{
    private int puntos;
    [SerializeField] private TextMeshProUGUI txtPuntos;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        puntos = 0;
    }
    public void SumarPunto()
    {
        puntos++;
        txtPuntos.text = puntos.ToString();    
    }
}
