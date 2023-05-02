using System;
using System.Collections;
using System.Collections.Generic;
using CardGame.Tools;
using TMPro;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;
using Random = UnityEngine.Random;


namespace CardGame.Wheel
{
    public class WheelController : MonoSingleton<WheelController>
    {
        [SerializeField] private Image[] _sliceImages;
        [SerializeField] private TextMeshProUGUI[] _sliceTexts;
        
        private WheelData _currentWheelData;


        public RewardData[] Rewards
        {
            get { return _currentWheelData.Rewards; }
        }


        public void SetWheelData(WheelData wheelData)
        {
            _currentWheelData = wheelData;
            SetSliceVisuals();
        }


        private void OnValidate()
        {
            SetSliceVisuals();
        }


        private void SetSliceVisuals()
        {
            for (var i = 0; i < _currentWheelData.Rewards.Length; i++)
            {
                _sliceImages[i].sprite = _currentWheelData.Rewards[i].SpriteAtlas.GetSprite(_currentWheelData.Rewards[i].SpriteName);
                _sliceTexts[i].text = _currentWheelData.Rewards[i].Count == 0 ? "" : "x" + _currentWheelData.Rewards[i].Count;
            }
        }
    }
}