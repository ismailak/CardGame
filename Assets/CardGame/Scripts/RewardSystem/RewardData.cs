using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.U2D;

namespace CardGame.RewardSystem
{
    [CreateAssetMenu(fileName = "RewardData", menuName = "ScriptableObjects/Reward/RewardData")]
    public class RewardData : ScriptableObject
    {
        [SerializeField] private int _id;
        [SerializeField] private int _count;
        [SerializeField] private SpriteAtlas _spriteAtlas;
        [SerializeField] private string _spriteName;

        public int Id
        {
            get { return _id; }
        }

        public int Count
        {
            get { return _count; }
        }

        public SpriteAtlas SpriteAtlas
        {
            get { return _spriteAtlas; }
        }

        public string SpriteName
        {
            get { return _spriteName; }
        }
    }
}