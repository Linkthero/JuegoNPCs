using System.Collections;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    [SerializeField] public AudioSource audioSource;
    [SerializeField] private AudioClip musicaMenu;
    [SerializeField] private AudioClip musicaAmbiente;
    //[SerializeField] private AudioClip musicaPersecucion;

    //public bool persecucionSonando = false;


    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioSource.clip = musicaMenu;
        audioSource.Play();
        Debug.Log(audioSource.clip.name);
    }

    public void PlayMenu()
    {
        audioSource.clip = musicaMenu;
        audioSource.Play();
    }

    public void PlayJuego()
    {
        audioSource.clip = musicaAmbiente;
        audioSource.Play();
    }

    public void StartFadeOut(float d)
    {
        StartCoroutine(FadeOutCoroutine(d));
    }public void StartFadeIn(float d)
    {
        StartCoroutine(FadeInCoroutine(d));
    }

    IEnumerator FadeOutCoroutine(float duration)
    {
        float startVolume = audioSource.volume;
        float timer = 0f;

        while (timer < duration)
        {
            timer += Time.deltaTime;
            audioSource.volume = Mathf.Lerp(startVolume, 0f, timer / duration);
            yield return null; // Espera al siguiente frame
        }

        audioSource.volume = 0f; // Asegura que el volumen sea cero
    }

    IEnumerator FadeInCoroutine(float duration)
    {
        float currentTime = 0;
        while (currentTime < duration)
        {
            currentTime += Time.deltaTime;
            audioSource.volume = Mathf.Lerp(0f, 1f, currentTime / duration);
            yield return null;
        }
        audioSource.volume = 1f; // Asegura el volumen máximo
    }

    //public void PlayPersecución()
    //{
    //    if(!persecucionSonando) 
    //    {
    //        persecucionSonando = true;
    //        audioSource.clip = musicaPersecucion;
    //        audioSource.Play();
    //    }
    //}

}
