using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.U2D;

[CreateAssetMenu(fileName = "RewardItemData", menuName = "Reward/RewardItemData")]
public class RewardItemData : ScriptableObject
{
    private GameObject _rewardItemObject;
    private TextMeshProUGUI _rewardCountText;
    private int _count;
    
    public GameObject RewardItemObject
    {
        get { return _rewardItemObject; }
    }
    public TextMeshProUGUI RewardCountText
    {
        get { return _rewardCountText; }
    }
    public int Count
    {
        get
        {
            return _count;
        }
        set
        {
            _count = value;
        }
    }

    public void Initialize(GameObject rewardItemObject, TextMeshProUGUI rewardCountText)
    {
        _rewardItemObject = rewardItemObject;
        _rewardCountText = rewardCountText;
    }
}