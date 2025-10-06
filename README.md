# Farm Guardians: NASA Agro Challenge 🚜🌿

**Farm Guardians** is an educational MVP developed for the [NASA Space Apps Challenge 2025](https://www.spaceappschallenge.org/2025/challenges/nasa-farm-navigators-using-nasa-data-exploration-in-agriculture/).  
It transforms **NASA satellite data** into a videogame where players balance **productivity and agricultural sustainability**.

**Team:** Todo esta acá 👉🧠👈  
**Members:**  
- Gutierrez Vilca, Henry Williams  
- Nieto Barrientos, Yishar Piero  
- Ochoa Barrios, Jesús Gustavo  
- Pachari Lipa, Milton Alexis  
- Puma Huamani, Glina de la Flor  

---

## Overview
More than **300 million smallholder farmers** lack access to digital services with climate information (WRI). This leaves them vulnerable to droughts, frosts, and heat waves.  

**Farm Guardians** seeks to close this gap: a videogame that translates satellite data such as **NDVI, temperature, and precipitation** into interactive missions where players make decisions on **irrigation, fertilization, and crop rotation**.  

The goal: **learn by playing how to anticipate climate challenges and protect crops**.  
Available in **VR and conventional devices**.  

---

## 🎥 / 🌐 Demo & Visualization

- [Demo Video](https://www.youtube.com/watch?v=3FlgNu1J8EA)  
- [GitHub Repository](https://github.com/iAmMazapan/FarmGuardians)  
- **Game Features (Web):** [Farm Guardians Web](https://gillyphuu.github.io/NASA-FarmGuardians/)  

---

## 🎮 Game Mechanics
- Maintain three indicators: **crop vigor, soil moisture, soil health**  
- Real climate scenarios: droughts, heavy rains, heat waves  
- Progression:
  - **Start (Weeks 1–3):** tutorial and simple decisions  
  - **Middle (Weeks 4–6):** real climate events  
  - **Final (Weeks 7–9):** autonomy with multiple variables  

---

## 📊 NASA Data
| Source | Variables | Use |
|--------|-----------|-----|
| NASA POWER | Temperature, rainfall | Weekly conditions |
| MODIS/VIIRS (NDVI) | Vegetation vigor | Initial crop health |
| SMAP (optional) | Soil moisture | Base value |
| ECOSTRESS (optional) | Evapotranspiration | Dynamic adjustments |

---

## 🌪️ Climate Phenomena in the Game

| Phenomenon | Region / Country | Dates | Description |
|------------|------------------|-------|-------------|
| Extreme drought | California, USA (Central Valley) | 2014-07 → 2015-06 | Prolonged drought impacting agriculture and wildfires |
| Extreme heat | Australia (Victoria) | 2019-03 → 2020-02 | Record-breaking heat wave causing crop stress |
| Agricultural pests | India (Punjab) | 2019-12 → 2020-11 | Desert locust outbreaks affecting wheat |
| Heavy rainfall | Bangladesh (Ganges Delta) | 2016-12 → 2017-11 | Monsoon floods impacting rice fields |
| Frosts / Extreme cold | Siberia, Russia | 2017-07 → 2018-06 | Severe frosts damaging cereals and vegetables |
| El Niño / Heavy rains | Peru (Northern coast – Piura) | 2016-07 → 2017-06 | Extreme rains, floods, and river overflows |

![Phenomena Map](mapa_fenomenos.png)

---

## 🔄 Data Pipeline
1. Connect to NASA APIs (GEE, POWER)  
2. Select region and dates  
3. Download data (NDVI, T2M, PRECTOT)  
4. Process and clean (weekly resample)  
5. Compute indicators (ΔNDVI, accumulated rainfall, temperature)  
6. Export as **JSON** for game integration  

---

## 🗂️ Project Structure

```text
FarmGuardians/
│
├─ UnityProject/            # Unity project (VR + UI + mechanics)
│   ├─ Assets/
│   ├─ Scenes/
│   ├─ Scripts/
│   └─ UI/
│
├─ DataIntegrator/          # NASA data module
│   ├─ ColabNotebooks/      # Prototypes and pipelines
│   │   └─ nasa_data.ipynb
│   ├─ raw_data/            # Raw data
│   ├─ processed_data/      # Processed data (JSON)
│   ├─ utils.py
│   └─ requirements.txt
│
└─ README.md
