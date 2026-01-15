using UnityEngine;

public class EfectosSonido : MonoBehaviour
{
    public static EfectosSonido instance;
    [SerializeField] public AudioSource audioSource;
    [SerializeField] public AudioClip audioClip;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioSource.clip = audioClip;
    }

}
