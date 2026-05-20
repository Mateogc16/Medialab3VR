using UnityEngine;

public class SonidoTrigger : MonoBehaviour
{
    [Header("AudioSource con el sonido")]
    public AudioSource audioSource;

    void OnTriggerEnter(Collider other)
    {
        // Reproduce el sonido cuando cualquier objeto entra al trigger
        if (audioSource != null)
        {
            audioSource.Play();
        }
    }
}
