using System;
using System.Collections;
using System.Collections.Generic;
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

        private int _currentWheelLevel;
        public int CurrentWheelLevel
        {
            get { return _currentWheelLevel; }
        }


        private void Awake()
        {
            SpinManager.Instance.DidFinishedSpin += OnFinishedSpin;
        }


        private void Start()
        {
            Set();
        }


        private void Set()
        {
            _currentWheelLevel = 1;
            _wheelPanelTransform.anchoredPosition = Vector2.down * 500;
            WheelManager.Instance.SetNewWheel();
        }


        public void ResetGame()
        {
            DOTween.KillAll();
            RewardCounter.Instance.Initialize();
            SpinManager.Instance.ResetSpinning();
            WheelLevelController.Instance.Set();
            _deadPanel.SetActive(false);
            Set();
        }


        private void OnFinishedSpin()
        {
            _currentWheelLevel++;

            _wheelPanelTransform.DOAnchorPosY(-500, 1).OnComplete(WheelManager.Instance.SetNewWheel).SetDelay(1f)
                .OnStart(WheelLevelController.Instance.LevelUp);
        }
    }
}