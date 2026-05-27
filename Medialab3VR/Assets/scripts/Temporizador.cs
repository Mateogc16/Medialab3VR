using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LoadZoneAfterVideo : MonoBehaviour
{
    // Tiempo en segundos
    public float delay = 68f;

    // Nombre exacto de la escena a cargar
    public string sceneName = "Escena1";

    void Start()
    {
        StartCoroutine(LoadSceneAfterDelay());
    }

    IEnumerator LoadSceneAfterDelay()
    {
        yield return new WaitForSeconds(delay);

        SceneManager.LoadScene(sceneName);
    }
}