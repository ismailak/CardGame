using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;
using Random = UnityEngine.Random;


namespace CardGame.Wheel
{
    public abstract class WheelAbstract : MonoBehaviour
    {
        [Header("Design")] [SerializeField] protected SliceOfWheelData[] _slicesOfWheelData;

        [SerializeField] private bool _isRandom = true;



        [Header("Development")] [SerializeField]
        private Image[] _sliceImages;

        [SerializeField] private TextMeshProUGUI[] _sliceTexts;
        [SerializeField] private SpriteAtlas _itemSpriteAtlas;
        [SerializeField] private SpriteAtlas _otherSpriteAtlas;
        [SerializeField] private string _coinSpriteName;
        [SerializeField] private string _moneySpriteName;
        [SerializeField] private string _grenadeElectricSpriteName;
        [SerializeField] private string _grenadeSpriteName;
        [SerializeField] private string _grenadeSnowballSpriteName;
        [SerializeField] private string _healthShotSpriteName;
        [SerializeField] private string _healthShotAdrenalineSpriteName;
        [SerializeField] private string _medKitSpriteName;
        [SerializeField] private string _c4SpriteName;
        [SerializeField] private string _grenadeEmpSpriteName;
        [SerializeField] private string _deadSpriteName;

        public SliceOfWheelData[] SlicesOfWheelData => _slicesOfWheelData;


        public void SetWheel()
        {
            if (_isRandom) SetRandomWheel();
        }


        protected virtual void SetRandomWheel()
        {
            SetSliceVisuals();
        }


        private void OnValidate() => SetSliceVisuals();


        private void SetSliceVisuals()
        {
            for (var i = 0; i < _slicesOfWheelData.Length; i++)
            {
                _sliceImages[i].sprite = _slicesOfWheelData[i].RewardType switch
                {
                    RewardType.Coin => _itemSpriteAtlas.GetSprite(_coinSpriteName),
                    RewardType.Money => _itemSpriteAtlas.GetSprite(_moneySpriteName),
                    RewardType.GrenadeElectric => _itemSpriteAtlas.GetSprite(_grenadeElectricSpriteName),
                    RewardType.Grenade => _itemSpriteAtlas.GetSprite(_grenadeSpriteName),
                    RewardType.GrenadeSnowball => _itemSpriteAtlas.GetSprite(_grenadeSnowballSpriteName),
                    RewardType.HealthShot => _itemSpriteAtlas.GetSprite(_healthShotSpriteName),
                    RewardType.HealthShotAdrenaline => _itemSpriteAtlas.GetSprite(_healthShotAdrenalineSpriteName),
                    RewardType.MedKit => _itemSpriteAtlas.GetSprite(_medKitSpriteName),
                    RewardType.C4 => _itemSpriteAtlas.GetSprite(_c4SpriteName),
                    RewardType.GrenadeEmp => _itemSpriteAtlas.GetSprite(_grenadeEmpSpriteName),
                    RewardType.Dead => _otherSpriteAtlas.GetSprite(_deadSpriteName),
                    RewardType.NumberOfTypes => throw new ArgumentOutOfRangeException(),
                    _ => throw new ArgumentOutOfRangeException()
                };

                _sliceTexts[i].text = _slicesOfWheelData[i].RewardType == RewardType.Dead
                    ? ""
                    : "x" + _slicesOfWheelData[i].Count;
            }
        }
    }


    [Serializable]
    public struct SliceOfWheelData
    {
        public RewardType RewardType;
        public int Count;
    }
}