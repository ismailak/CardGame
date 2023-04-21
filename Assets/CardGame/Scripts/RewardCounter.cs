using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace CardGame
{
    public class RewardCounter : MonoBehaviour
    {
        [SerializeField] private LeftPanelController _leftPanelController;

        private Dictionary<RewardType, int> _rewards;

        public Dictionary<RewardType, int> Rewards => _rewards;


        private void Awake()
        {
            SetRewardCounter();
        }


        public void SetRewardCounter()
        {
            _rewards = new Dictionary<RewardType, int>();

            for (var i = 0; i < (int) RewardType.NumberOfTypes; i++)
            {
                _rewards.Add((RewardType) i, 0);
                _leftPanelController.SetReward((RewardType) i, 0);
            }
        }


        public void AddReward(RewardType rewardType, int count)
        {
            if (rewardType == RewardType.Dead) return;

            _rewards[rewardType] += count;
            _leftPanelController.SetReward(rewardType, _rewards[rewardType]);
        }
    }

    public enum RewardType
    {
        Coin,
        Money,
        GrenadeElectric,
        Grenade,
        GrenadeSnowball,
        HealthShot,
        HealthShotAdrenaline,
        MedKit,
        C4,
        GrenadeEmp,
        NumberOfTypes,
        Dead
    }
}