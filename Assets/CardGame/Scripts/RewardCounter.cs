using System;
using System.Collections;
using System.Collections.Generic;
using CardGame.Tools;
using Pools;
using TMPro;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;
using Object = UnityEngine.Object;


namespace CardGame
{
    public class RewardCounter : MonoSingleton<RewardCounter>
    {
        [SerializeField] private PoolController _rewardItemPool;
        [SerializeField] private RewardItemData _rewardItemDataPrefab;
        
        private Dictionary<int, RewardItemData> _collectedRewards;

        public Dictionary<int, RewardItemData> CollectedRewards
        {
            get { return _collectedRewards; }
        }

        private void Start()
        {
            Initialize();
        }

        public void Initialize()
        {
            if (_collectedRewards != null)
            {
                foreach (var key in _collectedRewards.Keys)
                {
                    _rewardItemPool.GiveToPool(_collectedRewards[key].RewardItemObject);
                }
            }
            
            _collectedRewards = new Dictionary<int, RewardItemData>();
        }
        
        private void SetSprite(Image image, SpriteAtlas spriteAtlas, string spriteName)
        {
            image.sprite = spriteAtlas.GetSprite(spriteName);
        }
        
        public void AddReward(RewardData rewardData)
        {
            var rewardId = rewardData.Id;
            var increaseCount = rewardData.Count;
            
            if (_collectedRewards.ContainsKey(rewardId))
            {
                SetRewardCount(rewardId, _collectedRewards[rewardId].Count + increaseCount);
            }
            else
            {
                var rewardItemData = Instantiate(_rewardItemDataPrefab);
                var rewardItem = _rewardItemPool.GetFromPool(transform);
                SetSprite(rewardItem.GetComponent<Image>(), rewardData.SpriteAtlas, rewardData.SpriteName);
                
                rewardItemData.Initialize(rewardItem, rewardItem.GetComponentInChildren<TextMeshProUGUI>());
                
                _collectedRewards.Add(rewardId, rewardItemData);
                
                SetRewardCount(rewardId, increaseCount);
                
                _collectedRewards[rewardId].Count = increaseCount;
                _collectedRewards[rewardId].RewardCountText.text = increaseCount.ToString();
            }
        }

        private void SetRewardCount(int rewardId, int count)
        {
            _collectedRewards[rewardId].Count = count;
            _collectedRewards[rewardId].RewardCountText.text = count.ToString();
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