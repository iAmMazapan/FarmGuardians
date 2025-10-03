# FarmGuardians

FarmGuardians es un MVP educativo de agricultura que conecta datos reales de NASA con decisiones de juego en un entorno XR/2D. El proyecto permite a los jugadores gestionar el riego y fertilización de parcelas virtuales usando datos climáticos y de vegetación reales.

---

## Estructura del Proyecto


---

## Descripción de Carpetas

- **UnityProject/**: Contiene la escena XR/2D, scripts de mecánicas de juego, UI y prefabs de assets.  
- **DataIntegrator/**: Se encarga de descargar, procesar y generar los datasets para el juego.  
  - **ColabNotebooks/**: Notebooks en Google Colab para descargar datos de NASA POWER/MODIS y generar JSON.  
  - **raw_data/**: Almacena los datos originales descargados (opcional).  
  - **processed_data/**: Contiene los archivos JSON listos para ser leídos en Unity (`data.json`).  
  - **utils.py**: Funciones de ayuda para procesamiento de datos.  
  - **requirements.txt**: Librerías necesarias para ejecutar los notebooks (`pandas`, `requests`, `numpy`, etc.).

---

## Flujo de Trabajo

1. **Descarga de datos**  
   - Ejecutar `nasa_data.ipynb` en Google Colab para obtener datos de temperatura, lluvia y NDVI.  
   - Los datos crudos se guardan en `raw_data/`.

2. **Procesamiento**  
   - Limpiar y simplificar los datos a 6–8 semanas y 3 variables.  
   - Normalizar si es necesario para Unity.

3. **Generación de JSON**  
   - Guardar los datos procesados en `processed_data/data.json`.  
   - Formato ejemplo:

```json
[
  {"week":1, "temp":25, "rain":10, "ndvi":0.4},
  {"week":2, "temp":29, "rain":5, "ndvi":0.35}
]
