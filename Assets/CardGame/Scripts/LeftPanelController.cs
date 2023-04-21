using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


namespace CardGame
{
    public class LeftPanelController : MonoBehaviour
    {
        [SerializeField] private PanelTile _moneyTile;
        [SerializeField] private PanelTile _coinTile;
        [SerializeField] private PanelTile _grenadeElectricTile;
        [SerializeField] private PanelTile _grenadeTile;
        [SerializeField] private PanelTile _grenadeSnowballTile;
        [SerializeField] private PanelTile _healthShotTile;
        [SerializeField] private PanelTile _healthShotAdrenalineTile;
        [SerializeField] private PanelTile _medKitTile;
        [SerializeField] private PanelTile _c4Tile;
        [SerializeField] private PanelTile _grenadeEmpTile;


        public void SetReward(RewardType rewardType, int count)
        {
            switch (rewardType)
            {
                case RewardType.Money:
                    _moneyTile.Tile.SetActive(count > 0);
                    _moneyTile.Text.text = count.ToString();
                    break;
                case RewardType.Coin:
                    _coinTile.Tile.SetActive(count > 0);
                    _coinTile.Text.text = count.ToString();
                    break;
                case RewardType.GrenadeElectric:
                    _grenadeElectricTile.Tile.SetActive(count > 0);
                    _grenadeElectricTile.Text.text = count.ToString();
                    break;
                case RewardType.Grenade:
                    _grenadeTile.Tile.SetActive(count > 0);
                    _grenadeTile.Text.text = count.ToString();
                    break;
                case RewardType.GrenadeSnowball:
                    _grenadeSnowballTile.Tile.SetActive(count > 0);
                    _grenadeSnowballTile.Text.text = count.ToString();
                    break;
                case RewardType.HealthShot:
                    _healthShotTile.Tile.SetActive(count > 0);
                    _healthShotTile.Text.text = count.ToString();
                    break;
                case RewardType.HealthShotAdrenaline:
                    _healthShotAdrenalineTile.Tile.SetActive(count > 0);
                    _healthShotAdrenalineTile.Text.text = count.ToString();
                    break;
                case RewardType.MedKit:
                    _medKitTile.Tile.SetActive(count > 0);
                    _medKitTile.Text.text = count.ToString();
                    break;
                case RewardType.C4:
                    _c4Tile.Tile.SetActive(count > 0);
                    _c4Tile.Text.text = count.ToString();
                    break;
                case RewardType.GrenadeEmp:
                    _grenadeEmpTile.Tile.SetActive(count > 0);
                    _grenadeEmpTile.Text.text = count.ToString();
                    break;
                case RewardType.NumberOfTypes:
                    throw new ArgumentOutOfRangeException(nameof(rewardType), rewardType, null);
                case RewardType.Dead:
                    throw new ArgumentOutOfRangeException(nameof(rewardType), rewardType, null);
                default:
                    throw new ArgumentOutOfRangeException(nameof(rewardType), rewardType, null);
            }
        }


        [Serializable]
        public struct PanelTile
        {
            public GameObject Tile;
            public TextMeshProUGUI Text;
        }
    }
}