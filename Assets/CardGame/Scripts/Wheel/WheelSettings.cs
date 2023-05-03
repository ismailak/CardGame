using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CardGame.Wheel
{
    [CreateAssetMenu(fileName = "WheelSettings", menuName = "ScriptableObjects/Wheel/WheelSettings")]
    public class WheelSettings : ScriptableObject
    {
        [SerializeField] private int _silverInterval = 5;
        [SerializeField] private int _goldInterval = 30;
        [SerializeField] private int _yPosition = -13;
        [SerializeField] private int _yPositionForOutOfSight = -500;
        [SerializeField] private float _wheelReloadDuration = 2;

        public int SilverInterval
        {
            get { return _silverInterval; }
        }

        public int GoldInterval
        {
            get { return _goldInterval; }
        }

        public int YPosition
        {
            get { return _yPosition; }
        }

        public float WheelReloadDuration
        {
            get { return _wheelReloadDuration; }
        }

        public float YPositionForOutOfSight
        {
            get { return _yPositionForOutOfSight; }
        }
    }
}