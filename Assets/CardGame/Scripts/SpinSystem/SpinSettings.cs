using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CardGame.SpinSystem
{
    [CreateAssetMenu(fileName = "SpinSettings", menuName = "ScriptableObjects/Spin/SpinSettings")]
    public class SpinSettings : ScriptableObject
    {
        [SerializeField] private float _spinDuration = 3f;
        [SerializeField] private int _minSpinCount = 20;
        [SerializeField] private int _maxSpinCount = 30;
        [SerializeField] private int _deadRewardId;

        public float SpinDuration
        {
            get { return _spinDuration; }
        }

        public int MinSpinCount
        {
            get { return _minSpinCount; }
        }

        public int MaxSpinCount
        {
            get { return _maxSpinCount; }
        }

        public int DeadRewardId
        {
            get { return _deadRewardId; }
        }
    }
}