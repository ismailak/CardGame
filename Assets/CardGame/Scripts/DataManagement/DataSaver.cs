using System;
using System.Collections;
using System.Collections.Generic;
using CardGame.RewardSystem;
using UnityEngine;
using UnityEngine.UI;


namespace CardGame.DataManagement
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
            foreach (var key in RewardCounter.Instance.CollectedRewards.Keys)
            {
                var playerPrefKey = "reward_" + key;
                PlayerPrefs.SetInt(playerPrefKey,
                    PlayerPrefs.GetInt(playerPrefKey, 0) + RewardCounter.Instance.CollectedRewards.Count);
            }
        }
    }
}