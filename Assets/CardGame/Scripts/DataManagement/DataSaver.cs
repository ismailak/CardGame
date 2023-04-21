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
        [SerializeField] private RewardCounter _rewardCounter;
        [SerializeField] private DataManager _dataManager;


        private void Awake() => GetComponent<Button>().onClick.AddListener(SaveReward);


        private void SaveReward()
        {
            foreach (var reward in _rewardCounter.Rewards)
            {
                switch (reward.Key)
                {
                    case RewardType.Coin:
                        _dataManager.GameData.CoinCount += reward.Value;
                        break;
                    case RewardType.Money:
                        _dataManager.GameData.MoneyCount += reward.Value;
                        break;
                    case RewardType.GrenadeElectric:
                        _dataManager.GameData.GrenadeElectricCount += reward.Value;
                        break;
                    case RewardType.Grenade:
                        _dataManager.GameData.GrenadeCount += reward.Value;
                        break;
                    case RewardType.GrenadeSnowball:
                        _dataManager.GameData.GrenadeSnowballCount += reward.Value;
                        break;
                    case RewardType.HealthShot:
                        _dataManager.GameData.HealthShotCount += reward.Value;
                        break;
                    case RewardType.HealthShotAdrenaline:
                        _dataManager.GameData.HealthShotAdrenalineCount += reward.Value;
                        break;
                    case RewardType.MedKit:
                        _dataManager.GameData.MedKitCount += reward.Value;
                        break;
                    case RewardType.C4:
                        _dataManager.GameData.C4Count += reward.Value;
                        break;
                    case RewardType.GrenadeEmp:
                        _dataManager.GameData.GrenadeEmpCount += reward.Value;
                        break;
                    case RewardType.NumberOfTypes:
                        throw new ArgumentOutOfRangeException();
                    case RewardType.Dead:
                        throw new ArgumentOutOfRangeException();
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }

            _dataManager.SaveData();
        }
    }
}