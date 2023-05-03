using System.Collections;
using System.Collections.Generic;
using CardGame.RewardSystem;
using UnityEngine;

namespace CardGame.Wheel
{
    [CreateAssetMenu(fileName = "WheelData", menuName = "ScriptableObjects/Wheel/WheelData")]
    public class WheelData : ScriptableObject
    {
        [SerializeField] protected RewardData[] _rewards;
        [SerializeField] private bool _isShuffleRewards = true;
        [SerializeField] private string _wheelSpriteName;
        [SerializeField] private string _indicatorSpriteName;

        public RewardData[] Rewards
        {
            get { return _rewards; }
            set { _rewards = value; }
        }

        public string WheelSpriteName
        {
            get { return _wheelSpriteName; }
        }

        public string IndicatorSpriteName
        {
            get { return _indicatorSpriteName; }
        }

        public bool IsShuffleRewards
        {
            get { return _isShuffleRewards; }
        }
    }
}
