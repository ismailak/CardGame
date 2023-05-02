using System.Collections;
using System.Collections.Generic;
using CardGame;
using CardGame.Tools;
using CardGame.Wheel;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;
using DG.Tweening;

public class WheelManager : MonoSingleton<WheelManager>
{
    [Header("Design")] 
    [SerializeField] private WheelData[] _wheelDatas;
    [SerializeField] private WheelData[] _spareBronzeWheelDatas;
    [SerializeField] private WheelData[] _spareSilverWheelDatas;
    [SerializeField] private WheelData[] _spareGoldWheelDatas;

    [Space, Header("Development")]
    [SerializeField] private Image _wheelImage;
    [SerializeField] private Image _indicatorImage;
    [SerializeField] private SpriteAtlas _wheelSpriteAtlas;
    [SerializeField] private SpriteAtlas _indicatorSpriteAtlas;
    [SerializeField] private WheelController _wheelController;
    [SerializeField] private RectTransform _wheelPanelTransform;

    public void SetNewWheel()
    {
        WheelData targetWheelData;
        if (GameManager.Instance.CurrentWheelLevel <= _wheelDatas.Length)
        {
            targetWheelData = _wheelDatas[GameManager.Instance.CurrentWheelLevel - 1];
        }
        else
        {
            if (GameManager.Instance.CurrentWheelLevel == 0)
                targetWheelData = _spareBronzeWheelDatas[Random.Range(0, _spareBronzeWheelDatas.Length)];
            else if (GameManager.Instance.CurrentWheelLevel % 30 == 0)
                targetWheelData = _spareGoldWheelDatas[Random.Range(0, _spareGoldWheelDatas.Length)];
            else if (GameManager.Instance.CurrentWheelLevel % 5 == 0)
                targetWheelData = _spareSilverWheelDatas[Random.Range(0, _spareSilverWheelDatas.Length)];
            else targetWheelData = _spareBronzeWheelDatas[Random.Range(0, _spareBronzeWheelDatas.Length)];
        }

        _wheelImage.sprite = _wheelSpriteAtlas.GetSprite(targetWheelData.WheelSpriteName);
        _indicatorImage.sprite = _indicatorSpriteAtlas.GetSprite(targetWheelData.IndicatorSpriteName);

        if (targetWheelData.IsShuffleRewards)
        {
            targetWheelData = Instantiate(targetWheelData);
            ShuffleWheelRewards(ref targetWheelData);
        }

        _wheelController.SetWheelData(targetWheelData);

        _wheelPanelTransform.DOAnchorPosY(-13, 1).OnComplete(() => { SpinManager.Instance.ChangeInteractable(true); });
    }


    private void ShuffleWheelRewards(ref WheelData wheelData)
    {
        for (var i = 0; i < wheelData.Rewards.Length; i++)
        {
            var randomIndex = Random.Range(0, wheelData.Rewards.Length);
            var tempReward = wheelData.Rewards[randomIndex];
            wheelData.Rewards[randomIndex] = wheelData.Rewards[i];
            wheelData.Rewards[i] = tempReward;
        }
    }
}
