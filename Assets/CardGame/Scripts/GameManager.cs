using System;
using System.Collections;
using System.Collections.Generic;
using CardGame.EventBusSystem;
using CardGame.RewardSystem;
using CardGame.SpinSystem.CardGame;
using CardGame.Tools;
using CardGame.Wheel;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;


namespace CardGame
{
    public class GameManager : MonoSingleton<GameManager>
    {
        [SerializeField] private RectTransform _wheelPanelTransform;
        [SerializeField] private GameObject _deadPanel;
        [SerializeField] private WheelSettings _wheelSettings;

        private int _currentWheelLevel = 1;
        public int CurrentWheelLevel
        {
            get { return _currentWheelLevel; }
        }


        private void Awake()
        {
            GlobalBus.Sync.Subscribe<SpinFinishedEvent>(OnFinishedSpin);
        }


        private void Start()
        {
            Set();
        }


        private void Set()
        {
            _currentWheelLevel = 1;
            _wheelPanelTransform.anchoredPosition = Vector2.up * _wheelSettings.YPositionForOutOfSight;
            WheelManager.Instance.SetNewWheel();
        }


        public void ResetGame()
        {
            DOTween.KillAll();
            RewardCounter.Instance.Initialize();
            SpinManager.Instance.ResetSpinning();
            UpPanelManager.Instance.Initialize();
            _deadPanel.SetActive(false);
            Set();
        }


        private void OnFinishedSpin(object sender, EventArgs eventArgs)
        {
            _currentWheelLevel++;

            _wheelPanelTransform
                .DOAnchorPosY(_wheelSettings.YPositionForOutOfSight, _wheelSettings.WheelReloadDuration / 2f)
                .OnComplete(() =>
                {
                    WheelManager.Instance.SetNewWheel();
                    UpPanelManager.Instance.LevelUp();
                }).SetDelay(1f);
        }
    }
}