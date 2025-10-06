using UnityEngine;
using System.Collections;

public class GameIntroUI : MonoBehaviour
{
    [Header("UI Panels")]
    public GameObject rateUsPanel;   // RateUs!Panel
    public GameObject mensajePanel;  // mensaje
    public GameObject level1Panel;   // level 1

    [Header("Timing")]
    public float delayOnStart = 0.3f;  // aparece RateUs tras 0.3 s
    public float mensajeDuration = 2f; // mensaje visible 2 s

    void Start()
    {
        // Estado inicial: todo oculto
        if (rateUsPanel)  rateUsPanel.SetActive(false);
        if (mensajePanel) mensajePanel.SetActive(false);
        if (level1Panel)  level1Panel.SetActive(false);

        StartCoroutine(ShowRateUsAfterDelay());
    }

    IEnumerator ShowRateUsAfterDelay()
    {
        yield return new WaitForSeconds(delayOnStart);
        if (rateUsPanel) rateUsPanel.SetActive(true);
    }

    // Llama esto cuando el botón por mirada se "active"
    public void StartGameSequence()
    {
        StartCoroutine(StartSequenceCo());
    }

    IEnumerator StartSequenceCo()
    {
        if (rateUsPanel)  rateUsPanel.SetActive(false);
        if (mensajePanel) mensajePanel.SetActive(true);
        yield return new WaitForSeconds(mensajeDuration);
        if (mensajePanel) mensajePanel.SetActive(false);
        if (level1Panel)  level1Panel.SetActive(true);
    }
}
