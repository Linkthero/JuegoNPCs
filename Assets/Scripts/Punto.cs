using UnityEngine;

public class Punto : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            EfectosSonido.instance.audioSource.PlayOneShot(EfectosSonido.instance.audioClip);
            other.gameObject.GetComponent<Puntuación>().SumarPunto();
        }
    }
}
