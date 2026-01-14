using UnityEngine;

public class ColisionEnemigo : MonoBehaviour
{
    [SerializeField] private GameObject panelGameOver;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Enemy") )
        {
            panelGameOver.SetActive(true);
            Invoke(nameof(menu),3);
        }
    }

    private void menu()
    {
        Datos.instance.VolverAMenuPrincipal();
    } 
}
