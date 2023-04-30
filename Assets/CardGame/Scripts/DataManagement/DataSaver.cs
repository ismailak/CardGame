using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace CardGame.Management
{
    [RequireComponent(typeof(Button))]
    public class DataSaver : MonoBehaviour
    {
        private void Awake()
        {
            GetComponent<Button>().onClick.AddListener(SaveReward);
        }
        
        private void SaveReward()
        {
            foreach (var reward in RewardCounter.Instance.Rewards)
            {
                switch (reward.Key)
                {
                    case RewardType.Coin:
                        DataManager.Instance.GameData.CoinCount += reward.Value;
                        break;
                    case RewardType.Money:
                        DataManager.Instance.GameData.MoneyCount += reward.Value;
                        break;
                    case RewardType.GrenadeElectric:
                        DataManager.Instance.GameData.GrenadeElectricCount += reward.Value;
                        break;
                    case RewardType.Grenade:
                        DataManager.Instance.GameData.GrenadeCount += reward.Value;
                        break;
                    case RewardType.GrenadeSnowball:
                        DataManager.Instance.GameData.GrenadeSnowballCount += reward.Value;
                        break;
                    case RewardType.HealthShot:
                        DataManager.Instance.GameData.HealthShotCount += reward.Value;
                        break;
                    case RewardType.HealthShotAdrenaline:
                        DataManager.Instance.GameData.HealthShotAdrenalineCount += reward.Value;
                        break;
                    case RewardType.MedKit:
                        DataManager.Instance.GameData.MedKitCount += reward.Value;
                        break;
                    case RewardType.C4:
                        DataManager.Instance.GameData.C4Count += reward.Value;
                        break;
                    case RewardType.GrenadeEmp:
                        DataManager.Instance.GameData.GrenadeEmpCount += reward.Value;
                        break;
                    case RewardType.NumberOfTypes:
                        throw new ArgumentOutOfRangeException();
                    case RewardType.Dead:
                        throw new ArgumentOutOfRangeException();
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }

            DataManager.Instance.SaveData();
        }
    }
}