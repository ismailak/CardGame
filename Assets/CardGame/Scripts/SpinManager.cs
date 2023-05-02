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
    public class SpinManager : MonoSingleton<SpinManager>
    {
        public event Action DidFinishedSpin;

        [Header("Design")] 
        [SerializeField] private bool _isSpinCountRandom = true;
        [SerializeField] private int _spinCount;
        [SerializeField] private int _deadRewardId;

        [Space, Header("Development")]
        [SerializeField] private GameObject _deadPanel;
        [SerializeField] private Transform _wheelTransform;
        
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


        public void ChangeInteractable(bool value)
        {
            _button.interactable = value;
        }
        
        private void Spin()
        {
            ChangeInteractable(false);

            if (_isSpinCountRandom)
            {
                _spinCount = Random.Range(15, 35);
            }

            var targetZAngle = _spinCount * 45;

            _wheelTransform.DORotate(new Vector3(0, 0, targetZAngle), 3, RotateMode.FastBeyond360)
                .OnComplete(() => FinishSpin(_spinCount % 8));
        }


        private void FinishSpin(int rewardIndex)
        {
            if (WheelController.Instance.Rewards[rewardIndex].Id == _deadRewardId) _deadPanel.SetActive(true);

            RewardCounter.Instance.AddReward(WheelController.Instance.Rewards[rewardIndex]);
            DidFinishedSpin?.Invoke();
        }
    }
}