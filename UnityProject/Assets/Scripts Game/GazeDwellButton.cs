using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class GazeDwellButton : MonoBehaviour
{
    [Header("Gaze dwell")]
    public float dwellTime = 1.0f;         // segundos mirando para activar
    public Image reticleFill;              // opcional: Image UI para llenar (0-1)
    public UnityEvent OnActivate;          // lo conectaremos a GameIntroUI.StartGameSequence

    float t = 0f;
    bool gazing = false;
    bool activated = false;

    void Update()
    {
        if (activated) return;

        if (gazing)
        {
            t += Time.deltaTime;
            UpdateFill(t / dwellTime);
            if (t >= dwellTime)
            {
                activated = true;
                UpdateFill(0f);
                OnActivate?.Invoke();
            }
        }
        else
        {
            if (t > 0f) { t = 0f; UpdateFill(0f); }
        }
    }

    void UpdateFill(float v)
    {
        if (reticleFill)
        {
            reticleFill.type = Image.Type.Filled;
            reticleFill.fillMethod = Image.FillMethod.Radial360;
            reticleFill.fillAmount = Mathf.Clamp01(v);
        }
    }

    // Estos métodos los llama CardboardReticlePointer por SendMessage
    public void OnPointerEnter() { gazing = true; }
    public void OnPointerExit()  { gazing = false; }
    // Ignoramos OnPointerClick porque no queremos botón físico
}
