using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ReticleUIProxy : MonoBehaviour
{
    [Header("Referencias")]
    public Button button;              // tu FGUIStarter.CustomButton hereda de Button
    public GameObject panels;          // el panel padre que quieres ocultar ("Panels")
    public GameObject mensajeUI;       // el objeto que dice "mensaje"
    public GameObject level1UI;        // el objeto/Texto "Level 1"

    [Header("Opcional: congelar juego al final")]
    public bool freezeAtEnd = false;

    bool _clickedOnce = false;

    void Awake()
    {
        if (button == null) button = GetComponent<Button>();
    }

    // Estos nombres coinciden con los SendMessage del CardboardReticlePointer
    void OnPointerEnter()
    {
        // (Opcional) cambia visual: seleccionar el botón
        var selectable = button as Selectable;
        if (selectable) UnityEngine.EventSystems.EventSystem.current.SetSelectedGameObject(gameObject);
    }

    void OnPointerExit()
    {
        // (Opcional) limpia selección
        if (UnityEngine.EventSystems.EventSystem.current &&
            UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject == gameObject)
        {
            UnityEngine.EventSystems.EventSystem.current.SetSelectedGameObject(null);
        }
    }

    void OnPointerClick()
    {
        if (_clickedOnce) return; // evita doble disparo si el usuario mantiene el gatillo
        _clickedOnce = true;

        // Dispara el onClick del botón (por si tienes listeners)
        if (button != null) button.onClick?.Invoke();

        // Ejecuta la secuencia que pediste
        StartCoroutine(Sequence());
    }

    IEnumerator Sequence()
    {
        // 1) Oculta el panel padre
        if (panels) panels.SetActive(false);

        // 2) Muestra "mensaje" 2s
        if (mensajeUI) mensajeUI.SetActive(true);
        yield return new WaitForSeconds(2f);
        if (mensajeUI) mensajeUI.SetActive(false);

        // 3) Muestra "Level 1"
        if (level1UI) level1UI.SetActive(true);

        // 4) “y luego ahí se quede todo el juego”
        if (freezeAtEnd)
        {
            Time.timeScale = 0f; // congela toda la simulación
            // Si prefieres solo bloquear input, en vez de esto desactiva scripts de control del jugador.
        }
    }
}
