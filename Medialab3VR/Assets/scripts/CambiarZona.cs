using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class MenuVR : MonoBehaviour
{
    [Header("Canvas del menú")]
    public GameObject menuPrincipal;
    public GameObject menuZonas;

    [Header("Botones del menú principal")]
    public Button botonInicio;
    public Button botonSeleccionarZona;

    [Header("Botones del menú de zonas")]
    public Button botonZona1;
    public Button botonZona2;
    public Button botonZona3;

    private InputAction botonGrab;
    private Button botonSeleccionado;

    void Start()
    {
        // Configurar acciones de los botones
        botonInicio.onClick.AddListener(() => SceneManager.LoadScene("Anim1"));
        botonSeleccionarZona.onClick.AddListener(AbrirMenuZonas);

        botonZona1.onClick.AddListener(() => SceneManager.LoadScene("Escena1"));
        botonZona2.onClick.AddListener(() => SceneManager.LoadScene("Escena2"));
        botonZona3.onClick.AddListener(() => SceneManager.LoadScene("Escena3"));

        // Selección inicial en el menú principal
        botonSeleccionado = botonInicio;
        botonSeleccionado.Select();
    }

    void OnEnable()
    {
        // Configurar acción para el botón Grab
        botonGrab = new InputAction(type: InputActionType.Button, binding: "<XRController>{RightHand}/gripButton");
        botonGrab.performed += ctx => EjecutarAccion();
        botonGrab.Enable();
    }

    void OnDisable()
    {
        botonGrab.Disable();
    }

    void EjecutarAccion()
    {
        // Ejecuta el botón actualmente seleccionado
        if (botonSeleccionado != null)
            botonSeleccionado.onClick.Invoke();
    }

    public void SeleccionarBoton(Button nuevoBoton)
    {
        botonSeleccionado = nuevoBoton;
        botonSeleccionado.Select();
    }

    public void AbrirMenuZonas()
    {
        // Apagar menú principal y encender menú de zonas
        menuPrincipal.SetActive(false);
        menuZonas.SetActive(true);

        // Solo resaltar Zona1 como selección inicial, sin ejecutarla
        SeleccionarBoton(botonZona1);
    }
}
