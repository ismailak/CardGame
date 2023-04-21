using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace CardGame.Wheel
{
    public class WheelBronze : WheelAbstract
    {
        protected override void SetRandomWheel()
        {
            _slicesOfWheelData = new SliceOfWheelData[8];

            for (var i = 0; i < 8; i++)
            {
                _slicesOfWheelData[i].RewardType = (RewardType) Random.Range(0, (int) RewardType.NumberOfTypes);
                _slicesOfWheelData[i].Count = Random.Range(1, 5);

                switch (_slicesOfWheelData[i].RewardType)
                {
                    case RewardType.Coin:
                        _slicesOfWheelData[i].Count *= 10;
                        break;
                    case RewardType.Money:
                        _slicesOfWheelData[i].Count *= 100;
                        break;
                }
            }

            var deadIndex = Random.Range(0, 8);
            _slicesOfWheelData[deadIndex].RewardType = RewardType.Dead;

            base.SetRandomWheel();
        }
    }
}