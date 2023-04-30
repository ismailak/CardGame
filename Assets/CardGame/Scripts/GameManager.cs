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
        [SerializeField] private WheelAbstract _bronzeWheel, _silverWheel, _goldWheel;
        [SerializeField] private IndicatorSpriteAssigner _indicatorSpriteAssigner;
        [SerializeField] private GameObject _deadPanel;

        private int _level;


        private void Awake()
        {
            SpinController.Instance.DidFinishedSpin += OnFinishedSpin;
        }


        private void Start()
        {
            Set();
        }


        private void Set()
        {
            _level = 1;
            _wheelPanelTransform.anchoredPosition = Vector2.down * 500;
            SetNewWheel();
        }


        public void ResetGame()
        {
            DOTween.KillAll();
            RewardCounter.Instance.SetRewardCounter();
            SpinController.Instance.ResetSpinning();
            WheelLevelController.Instance.Set();
            _deadPanel.SetActive(false);
            Set();
        }


        private void SetNewWheel()
        {
            WheelAbstract targetWheel;

            if (_level == 0) targetWheel = _bronzeWheel;
            else if (_level % 30 == 0) targetWheel = _goldWheel;
            else if (_level % 5 == 0) targetWheel = _silverWheel;
            else targetWheel = _bronzeWheel;

            _bronzeWheel.gameObject.SetActive(targetWheel == _bronzeWheel);
            _silverWheel.gameObject.SetActive(targetWheel == _silverWheel);
            _goldWheel.gameObject.SetActive(targetWheel == _goldWheel);

            if (targetWheel == _bronzeWheel) _indicatorSpriteAssigner.SetBronze();
            else if (targetWheel == _silverWheel) _indicatorSpriteAssigner.SetSilver();
            else _indicatorSpriteAssigner.SetGold();

            targetWheel.SetWheel();
            SpinController.Instance.Init(targetWheel, targetWheel.transform);

            _wheelPanelTransform.DOAnchorPosY(-13, 1).OnComplete(() =>
            {
                SpinController.Instance.ChangeInteractable(true);
            });
        }


        private void OnFinishedSpin()
        {
            _level++;

            _wheelPanelTransform.DOAnchorPosY(-500, 1).OnComplete(SetNewWheel).SetDelay(1f)
                .OnStart(WheelLevelController.Instance.LevelUp);
        }
    }
}