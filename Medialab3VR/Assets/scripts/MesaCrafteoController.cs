using System.Collections;
using UnityEngine;

public class MesaCrafteoController : MonoBehaviour
{
    [Header("Objetos Requeridos")]
    public GameObject obj1;
    public GameObject obj2;
    public GameObject obj3;

    [Header("Resultados del Crafteo")]
    public GameObject hombreJaguar;
    public GameObject prefabFuegoJaguar;
    public Transform puntoAparicion; // Un objeto vacío sobre la mesa para saber dónde spawnear

    // Variables internas para saber qué hay en la mesa
    private bool estaObj1 = false;
    private bool estaObj2 = false;
    private bool estaObj3 = false;
    private bool ritualCompletado = false;

    void Start()
    {
        // Nos aseguramos de que el HombreJaguar empiece escondido
        if (hombreJaguar != null) hombreJaguar.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (ritualCompletado) return; // Si ya se hizo, no vuelve a pasar

        // Validamos cuál objeto entró a la zona de la mesa
        if (other.gameObject == obj1) estaObj1 = true;
        if (other.gameObject == obj2) estaObj2 = true;
        if (other.gameObject == obj3) estaObj3 = true;

        // Verificar si ya están los tres al mismo tiempo
        if (estaObj1 && estaObj2 && estaObj3)
        {
            CompletarRitual();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (ritualCompletado) return;

        // Si el usuario saca un objeto antes de completar los tres, quitamos el check
        if (other.gameObject == obj1) estaObj1 = false;
        if (other.gameObject == obj2) estaObj2 = false;
        if (other.gameObject == obj3) estaObj3 = false;
    }

    void CompletarRitual()
    {
        ritualCompletado = true;

        // 1. Desaparecer los 3 ingredientes de la mesa para dar espacio
        obj1.SetActive(false);
        obj2.SetActive(false);
        obj3.SetActive(false);

        // 2. Aparecer al HombreJaguar
        if (hombreJaguar != null)
        {
            hombreJaguar.SetActive(true);
        }

        // 3. Lanzar la corrutina para el efecto de fuego temporal
        if (prefabFuegoJaguar != null && puntoAparicion != null)
        {
            StartCoroutine(ManejarFuegoTemporal());
        }
    }

    IEnumerator ManejarFuegoTemporal()
    {
        // Instanciar (crear) el fuego en la posición del punto de aparición
        GameObject fuegoInstanciado = Instantiate(prefabFuegoJaguar, puntoAparicion.position, puntoAparicion.rotation);

        // Esperar exactamente 3 segundos
        yield return new WaitForSeconds(3f);

        // Destruir el fuego de la escena
        Destroy(fuegoInstanciado);
    }
}