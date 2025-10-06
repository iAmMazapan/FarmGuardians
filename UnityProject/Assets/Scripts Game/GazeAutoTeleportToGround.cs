using UnityEngine;
using UnityEngine.UI;

public class GazeAutoTeleportToGround : MonoBehaviour
{
    public Transform playerRoot;         // ← el GO que mueve todo el rig (padre de la cámara)
    public LayerMask groundMask;         // ← capa del suelo (ej. "Ground")
    public float maxDistance = 25f;
    public float dwellTime = 0.9f;       // tiempo de mirada para activar
    public float cooldown = 0.5f;        // evita TPs seguidos
    public float minStep = 0.5f;         // ignora destinos demasiado cercanos
    public bool keepPlayerY = true;      // mantener altura Y del jugador (confort VR)
    public Image reticleFill;            // opcional: Image (Filled Radial) para feedback

    float t = 0f, cd = 0f;
    Vector3 lastPoint; bool hasLast;

    void Awake(){
        if (!playerRoot && Camera.main){
            var cam = Camera.main.transform;
            playerRoot = cam.parent ? cam.parent : cam;
        }
    }

    void Update()
    {
        if (cd > 0f) cd -= Time.deltaTime;

        var cam = Camera.main.transform;
        if (Physics.Raycast(cam.position, cam.forward, out var hit, maxDistance, groundMask))
        {
            if (!hasLast || Vector3.Distance(hit.point, lastPoint) > 0.15f) { hasLast = true; lastPoint = hit.point; t = 0f; SetFill(0); }
            else
            {
                t += Time.deltaTime; SetFill(t / dwellTime);
                if (t >= dwellTime && cd <= 0f) { TeleportTo(lastPoint, cam); t = 0f; cd = cooldown; SetFill(0); }
            }
        }
        else { hasLast = false; t = 0f; SetFill(0); }

        Debug.DrawRay(cam.position, cam.forward * maxDistance, Color.cyan);
    }

    void TeleportTo(Vector3 p, Transform cam)
    {
        if (!playerRoot) return;
        if ((p - playerRoot.position).sqrMagnitude < minStep*minStep) return;

        Vector3 dest = p;
        if (keepPlayerY) dest.y = playerRoot.position.y;
        playerRoot.position = dest;

        Vector3 yaw = cam.forward; yaw.y = 0f;
        if (yaw.sqrMagnitude > 0.001f) playerRoot.rotation = Quaternion.LookRotation(yaw.normalized, Vector3.up);
    }

    void SetFill(float f){ if (reticleFill){ reticleFill.type = Image.Type.Filled; reticleFill.fillMethod = Image.FillMethod.Radial360; reticleFill.fillAmount = Mathf.Clamp01(f);} }
}
