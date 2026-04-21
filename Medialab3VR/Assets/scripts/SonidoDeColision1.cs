using UnityEngine;

public class SonidoDeColision : MonoBehaviour
{
    private AudioSource fuenteAudio;
    public float fuerzaMinima = 0.2f; // Para que no suene si solo roza el piso

    void Start()
    {
        fuenteAudio = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Solo suena si el golpe tiene cierta fuerza (velocidad)
        if (collision.relativeVelocity.magnitude > fuerzaMinima)
        {
            fuenteAudio.Play();
        }
    }
}