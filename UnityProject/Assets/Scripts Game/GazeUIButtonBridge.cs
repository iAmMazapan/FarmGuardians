using UnityEngine;
using UnityEngine.UI;

public class GazeUIButtonBridge : MonoBehaviour
{
    [Header("Botón UI a invocar")]
    public Button targetButton;   // asigna tu CustomButton o Button

    [Header("Opcional: dwell sin botón físico")]
    public bool useDwell = true;
    public float dwellTime = 1.0f;
    public Image dwellFill;       // Image (Filled Radial) para feedback (opcional)

    float t;
    bool gazing;

    void Reset()
    {
        if (!targetButton) targetButton = GetComponent<Button>();
    }

    void Update()
    {
        if (!useDwell || targetButton == null) return;

        if (gazing)
        {
            t += Time.deltaTime;
            if (dwellFill)
            {
                dwellFill.type = Image.Type.Filled;
                dwellFill.fillMethod = Image.FillMethod.Radial360;
                dwellFill.fillAmount = Mathf.Clamp01(t / dwellTime);
            }
            if (t >= dwellTime)
            {
                // Activa el botón UI
                targetButton.onClick?.Invoke();
                t = 0f;
                if (dwellFill) dwellFill.fillAmount = 0f;
            }
        }
        else
        {
            if (t > 0f) { t = 0f; if (dwellFill) dwellFill.fillAmount = 0f; }
        }
    }

    // Estos los llama CardboardReticlePointer vía SendMessage
    public void OnPointerEnter() { gazing = true;  }
    public void OnPointerExit()  { gazing = false; }
    public void OnPointerClick() // por si quieres click con botón físico
    {
        if (!useDwell && targetButton) targetButton.onClick?.Invoke();
    }
}
