# Farm Guardians: NASA Agro Challenge 🚜🌿

**Farm Guardians** es un MVP educativo desarrollado para la [NASA Space Apps Challenge 2025](https://www.spaceappschallenge.org/2025/challenges/nasa-farm-navigators-using-nasa-data-exploration-in-agriculture/).  
El proyecto permite a los jugadores gestionar riego, fertilización y rotación de cultivos usando datos satelitales reales de NASA, equilibrando producción y sostenibilidad.

**Nombre del equipo:** Todo está acá 👉🧠👈

**Integrantes:**
- Gutierrez Vilca, Henry Williams  
- Nieto Barrientos, Yishar Piero (Líder de equipo)  
- Ochoa Barrios, Jesús Gustavo  
- Pachari Lipa, Milton Alexis  
- Puma Huamani, Glina de la Flor  

---

## Objetivo del Juego
Convertirse en un guardián agrícola sostenible, tomando decisiones basadas en datos reales:  
- Riego y fertilización  
- Rotación de cultivos  
- Balance entre rendimiento y cuidado ambiental  

### Bucle Principal
1. Observar datos NASA (Temperatura, Lluvia, NDVI; opcional: Humedad SMAP, Evapotranspiración ECOSTRESS)  
2. Decidir acciones (regar, fertilizar, rotar cultivos)  
3. Simular la semana → actualizar vigor, agua y alertas  
4. Recibir feedback inmediato (puntaje y tooltips educativos)

---

## Mecánicas Clave
- Mantener tres indicadores: Vigor del cultivo, Humedad del suelo, Salud del suelo  
- Desafíos: eficiencia en agua, fertilización balanceada, rotación sostenible  
- Recompensas visuales: cambios de color en cultivos y biodiversidad  
- Minijuegos opcionales para reforzar aprendizaje de datos

---

## Datos Reales NASA
| Fuente | Uso | Implementación |
|--------|-----|----------------|
| NASA POWER | Temperatura y lluvia | JSON diario/semanal |
| NDVI MODIS/VIIRS | Vigor vegetal inicial | PNG estática |
| SMAP (opcional) | Humedad inicial | Valor base |
| ECOSTRESS (opcional) | Evapotranspiración | Factores dinámicos |

**Modo sin conexión:** usar dataset precargado (`JSON`).

---

## Estructura del Proyecto

```text
FarmGuardians/
│
├─ UnityProject/            # Proyecto de Unity (XR + UI + Mecánicas)
│   ├─ Assets/
│   ├─ Scenes/
│   ├─ Scripts/
│   └─ UI/
│
├─ DataIntegrator/
│   ├─ ColabNotebooks/
│   │   └─ nasa_data.ipynb
│   ├─ raw_data/
│   ├─ processed_data/
│   │   └─ data.json
│   ├─ utils.py
│   └─ requirements.txt
│
├─ Design/
│   ├─ Mockups/
│   └─ Documentation/
│
└─ README.md

![Mapa de fenómenos](mapa_fenomenos.png)

