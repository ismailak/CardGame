using System;
using System.Collections;
using System.Collections.Generic;
using CardGame.Tools;
using CardGame.Wheel;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;


namespace CardGame
{
    [RequireComponent(typeof(Button))]
    public class SpinController : MonoSingleton<SpinController>
    {
        public event Action DidFinishedSpin;

        [Header("Design")] 
        private bool _isRandom = true;
        private int _spinSliceCount;

        [Header("Development")]
        [SerializeField] private GameObject _deadPanel;


        private WheelAbstract _wheel;
        private Transform _wheelTransform;
        private float _sliceAngleInterval;
        private Button _button;


        private void Awake()
        {
            _button = GetComponent<Button>();
            _button.onClick.AddListener(Spin);
        }


        public void ResetSpinning()
        {
            if (_wheelTransform)
            {
                _wheelTransform.DOKill();
            }
        }


        public void ChangeInteractable(bool value) => _button.interactable = value;


        public void Init(WheelAbstract wheel, Transform wheelTransform)
        {
            _wheel = wheel;
            _wheelTransform = wheelTransform;
        }


        private void Spin()
        {
            ChangeInteractable(false);

            if (_isRandom)
            {
                _spinSliceCount = Random.Range(15, 35);
            }

            var targetZAngle = _spinSliceCount * 45;

            _wheelTransform.DORotate(new Vector3(0, 0, targetZAngle), 3, RotateMode.FastBeyond360)
                .OnComplete(() => FinishSpin(_spinSliceCount % 8));
        }


        private void FinishSpin(int index)
        {
            if (_wheel.SlicesOfWheelData[index].RewardType == RewardType.Dead) _deadPanel.SetActive(true);

            RewardCounter.Instance.AddReward(_wheel.SlicesOfWheelData[index].RewardType, _wheel.SlicesOfWheelData[index].Count);
            DidFinishedSpin?.Invoke();
        }
    }
}