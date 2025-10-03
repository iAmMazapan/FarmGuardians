# FarmGuardians

FarmGuardians es un MVP educativo de agricultura que conecta datos reales de NASA con decisiones de juego en un entorno XR/2D. El proyecto permite a los jugadores gestionar el riego y fertilización de parcelas virtuales usando datos climáticos y de vegetación reales.

---

## 📂 Estructura del Proyecto

```text
FarmGuardians/
│
├─ UnityProject/            # Proyecto de Unity (XR + UI + Mecánicas)
│   ├─ Assets/              # Prefabs, texturas, sonidos, modelos
│   ├─ Scenes/              # Escenas del juego
│   ├─ Scripts/             # Scripts de mecánicas y lectura de JSON
│   └─ UI/                  # Prefabs de barras de estado y tutorial
│
├─ DataIntegrator/          # Parte 3: Integración de datos NASA
│   ├─ ColabNotebooks/      # Notebooks para descargar y procesar datos
│   │   └─ nasa_data.ipynb
│   ├─ raw_data/            # Datos descargados crudos (opcional)
│   ├─ processed_data/      # Archivos JSON listos para Unity
│   │   └─ data.json
│   ├─ utils.py             # Funciones de ayuda: descarga, limpieza, normalización
│   └─ requirements.txt     # Librerías necesarias (pandas, requests, numpy...)
│
├─ Design/                  # Recursos de UI/UX
│   ├─ Mockups/             # Imágenes de diseño de barras, tutoriales
│   └─ Documentation/       # Guías y referencias de diseño
│
└─ README.md
