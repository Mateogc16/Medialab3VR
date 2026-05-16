using UnityEngine;
using UnityEngine.SceneManagement; // Súper importante para poder cambiar de escena

public class PortalEscena : MonoBehaviour
{
    [Tooltip("Asegúrate de escribir el nombre exactamente igual al archivo de la escena")]
    public string nombreEscenaDestino = "Escena2";

    private void OnTriggerEnter(Collider other)
    {
        // Verificamos si lo que cruzó el portal tiene la etiqueta "Player"
        if (other.CompareTag("Player"))
        {
            // Cambia de escena inmediatamente
            SceneManager.LoadScene(nombreEscenaDestino);
        }
    }
}