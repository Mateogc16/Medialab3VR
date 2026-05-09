using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class ShowCanvasOnGrab : MonoBehaviour
{
    public GameObject canvas;
    public Image image;

    public float fadeDuration = 0.5f;

    private XRGrabInteractable grabInteractable;

    void Awake()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();
    }

    void OnEnable()
    {
        grabInteractable.selectEntered.AddListener(OnGrab);
        grabInteractable.selectExited.AddListener(OnRelease);
    }

    void OnDisable()
    {
        grabInteractable.selectEntered.RemoveListener(OnGrab);
        grabInteractable.selectExited.RemoveListener(OnRelease);
    }

    void Start()
    {
        Color color = image.color;
        color.a = 0f;
        image.color = color;

        canvas.SetActive(false);
    }

    void OnGrab(SelectEnterEventArgs args)
    {
        StopAllCoroutines();

        canvas.SetActive(true);
        StartCoroutine(FadeImage(0f, 1f));
    }

    void OnRelease(SelectExitEventArgs args)
    {
        StopAllCoroutines();

        StartCoroutine(FadeOutAndDisable());
    }

    IEnumerator FadeImage(float start, float end)
    {
        float elapsed = 0f;

        Color color = image.color;

        while (elapsed < fadeDuration)
        {
            elapsed += Time.deltaTime;

            color.a = Mathf.Lerp(start, end, elapsed / fadeDuration);
            image.color = color;

            yield return null;
        }

        color.a = end;
        image.color = color;
    }

    IEnumerator FadeOutAndDisable()
    {
        yield return StartCoroutine(FadeImage(1f, 0f));

        canvas.SetActive(false);
    }
}