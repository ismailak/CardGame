using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace CardGame.Wheel
{
    public class WheelSilver : WheelAbstract
    {
        protected override void SetRandomWheel()
        {
            _slicesOfWheelData = new SliceOfWheelData[8];

            for (var i = 0; i < 8; i++)
            {
                _slicesOfWheelData[i].RewardType = (RewardType) Random.Range(0, (int) RewardType.NumberOfTypes);
                _slicesOfWheelData[i].Count = Random.Range(0, 10);

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

            base.SetRandomWheel();
        }
    }
}