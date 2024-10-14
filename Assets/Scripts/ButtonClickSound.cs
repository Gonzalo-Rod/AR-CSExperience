using UnityEngine;
using UnityEngine.UI;

public class ButtonClickSound : MonoBehaviour
{
    private AudioSource audioSource;

    void Start()
    {
        // Obtiene el componente AudioSource
        audioSource = GetComponent<AudioSource>();

        // Añade un listener al botón para que reproduzca el sonido al hacer clic
        GetComponent<Button>().onClick.AddListener(PlaySound);
    }

    void PlaySound()
{
    // Reproduce el sonido sin retrasos con PlayOneShot
    audioSource.PlayOneShot(audioSource.clip);
}
}
