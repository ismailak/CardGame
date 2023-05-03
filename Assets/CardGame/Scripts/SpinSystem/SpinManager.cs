using System;
using System.Collections;
using System.Collections.Generic;
using CardGame.EventBusSystem;
using CardGame.RewardSystem;
using CardGame.Tools;
using CardGame.Wheel;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace CardGame.SpinSystem
{
    namespace CardGame
    {
        [RequireComponent(typeof(Button))]
        public class SpinManager : MonoSingleton<SpinManager>
        {
            private const int SliceCount = 8;
            private const float AngleOfEachSlice = 45;

            [SerializeField] private SpinSettings _spinSettings;
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

                var spinCount = Random.Range(_spinSettings.MinSpinCount, _spinSettings.MaxSpinCount);
                var targetZAngle = spinCount * AngleOfEachSlice;

                _wheelTransform.DORotate(new Vector3(0, 0, targetZAngle), _spinSettings.SpinDuration,
                        RotateMode.FastBeyond360)
                    .OnComplete(() => FinishSpin(spinCount % SliceCount));
            }


            private void FinishSpin(int rewardIndex)
            {
                if (WheelController.Instance.Rewards[rewardIndex].Id == _spinSettings.DeadRewardId)
                    _deadPanel.SetActive(true);

                RewardCounter.Instance.AddReward(WheelController.Instance.Rewards[rewardIndex]);

                GlobalBus.Sync.Publish(this, new SpinFinishedEvent());
            }
        }
    }
}