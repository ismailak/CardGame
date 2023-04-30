using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace CardGame.Management
{
    public class DataManager : MonoBehaviour
    {
        private const string GameDataString = "game_data";

        private GameData _gameData;

        public GameData GameData
        {
            get { return _gameData; }
            private set
            {
                _gameData = value;
                SaveData();
            }
        }


        private void Awake()
        {
            if (PlayerPrefs.HasKey(GameDataString))
            {
                GameData = JsonUtility.FromJson<GameData>(PlayerPrefs.GetString(GameDataString));
            }
            else
            {
                GameData = new GameData(0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0);
                SaveData();
            }
        }


        public void SaveData() => PlayerPrefs.SetString(GameDataString, JsonUtility.ToJson(GameData));
    }


    public class GameData
    {
        public int CoinCount;
        public int MoneyCount;
        public int GrenadeElectricCount;
        public int GrenadeCount;
        public int GrenadeSnowballCount;
        public int HealthShotCount;
        public int HealthShotAdrenalineCount;
        public int MedKitCount;
        public int C4Count;
        public int GrenadeEmpCount;


        public GameData(int coinCount, int moneyCount, int grenadeElectricCount, int grenadeCount,
            int grenadeSnowballCount,
            int healthShotCount, int healthShotAdrenalineCount, int medKitCount, int c4Count, int grenadeEmpCount)
        {
            CoinCount = coinCount;
            MoneyCount = moneyCount;
            GrenadeElectricCount = grenadeElectricCount;
            GrenadeCount = grenadeCount;
            GrenadeSnowballCount = grenadeSnowballCount;
            HealthShotCount = healthShotCount;
            HealthShotAdrenalineCount = healthShotAdrenalineCount;
            MedKitCount = medKitCount;
            C4Count = c4Count;
            GrenadeEmpCount = grenadeEmpCount;
        }
    }
}