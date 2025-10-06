using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(RectTransform))]
[RequireComponent(typeof(BoxCollider))]
public class UIColliderSync : MonoBehaviour
{
    void Reset()
    {
        Sync();
    }

    void OnValidate()
    {
        Sync();
    }

    void LateUpdate()
    {
        // Por si cambia el layout dinámicamente
        Sync();
    }

    void Sync()
    {
        var rt = GetComponent<RectTransform>();
        var col = GetComponent<BoxCollider>();

        // Convierte el tamaño del rect en escala local del Canvas
        Vector2 size = rt.rect.size;
        Vector3 lossy = rt.lossyScale;
        col.size = new Vector3(size.x * Mathf.Abs(lossy.x), size.y * Mathf.Abs(lossy.y), 0.01f);
        col.center = Vector3.zero;
    }
}
