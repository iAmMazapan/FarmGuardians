using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ReticleAutoActivator : MonoBehaviour
{
    [Header("Referencias")]
    public Button button;          // tu CustomButton hereda de Button; si no lo asignas, se detecta solo
    public GameObject panels;      // padre a ocultar ("Panels")
    public GameObject mensajeUI;   // objeto "mensaje" (inactivo por defecto)
    public GameObject level1UI;    // objeto "Level 1" (inactivo por defecto)

    [Header("Opciones")]
    public float enterDelay = 0f;  // si quieres 0 = inmediato, o p.ej. 0.1f para evitar falsos positivos
    public bool freezeAtEnd = false;

    bool triggered = false;
    Coroutine pendingCo;

    void Awake()
    {
        if (button == null) button = GetComponent<Button>();
        if (mensajeUI) mensajeUI.SetActive(false);
        if (level1UI) level1UI.SetActive(false);
    }

    // Llamado por CardboardReticlePointer via SendMessage
    void OnPointerEnter()
    {
        if (triggered || pendingCo != null) return;
        pendingCo = StartCoroutine(StartAfterDelay());
    }

    void OnPointerExit()
    {
        // si quieres que no se cancele una vez iniciado, no hagas nada aquí
        if (pendingCo != null)
        {
            StopCoroutine(pendingCo);
            pendingCo = null;
        }
    }

    IEnumerator StartAfterDelay()
    {
        if (enterDelay > 0f) yield return new WaitForSeconds(enterDelay);
        Activate();
    }

    void Activate()
    {
        if (triggered) return;
        triggered = true;

        // dispara onClick si tenías listeners en el botón
        button?.onClick?.Invoke();

        StartCoroutine(Sequence());
    }

    IEnumerator Sequence()
    {
        // 1) Oculta panel padre
        if (panels) panels.SetActive(false);

        // 2) Muestra "mensaje" 2s
        if (mensajeUI) mensajeUI.SetActive(true);
        yield return new WaitForSeconds(2f);
        if (mensajeUI) mensajeUI.SetActive(false);

        // 3) Muestra "Level 1"
        if (level1UI) level1UI.SetActive(true);

        // 4) Opcional: congelar juego
        if (freezeAtEnd) Time.timeScale = 0f;
    }
}
