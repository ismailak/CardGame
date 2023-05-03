using System;
using System.Collections;
using System.Collections.Generic;
using CardGame.Tools;
using CardGame.Wheel;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;


namespace CardGame
{
    public class UpPanelManager : MonoSingleton<UpPanelManager>
    {
        private const float TileLength = 720;
        private const float TilePieceInterval = 80;
        private const float TileStartOffsetX = -320;
        private const int TargetLevelOffset = 4;
        
        [SerializeField] private Transform _tileBackgroundsTransform, _tileLevelTextsTransform;
        [SerializeField] private List<LevelObject> _levelObjects;
        [SerializeField] private SpriteAtlas _spriteAtlas;
        [SerializeField] private string _bronzeSpriteName;
        [SerializeField] private string _silverSpriteName;
        [SerializeField] private string _goldSpriteName;
        [SerializeField] private WheelSettings _wheelSettings;

        private Queue<LevelObject> _levelObjectsQueue;
        
        private void Start()
        {
            Initialize();
        }

        public void Initialize()
        {
            _tileBackgroundsTransform.localPosition = Vector3.zero;
            _tileLevelTextsTransform.localPosition = Vector3.zero;

            _levelObjectsQueue = new Queue<LevelObject>(_levelObjects);

            for (var i = 0; i < _levelObjects.Count; i++)
            {
                if (i == _levelObjects.Count - 1)
                    _levelObjects[i].TileBackgroundTransform.GetComponent<Image>().sprite =
                        _spriteAtlas.GetSprite(_silverSpriteName);
                else
                    _levelObjects[i].TileBackgroundTransform.GetComponent<Image>().sprite =
                        _spriteAtlas.GetSprite(_bronzeSpriteName);

                _levelObjects[i].TileBackgroundTransform.anchoredPosition = new Vector2(TileStartOffsetX + TilePieceInterval * i, 0);
                _levelObjects[i].TileLevelTransform.anchoredPosition = new Vector2(TileStartOffsetX + TilePieceInterval * i, 0);
            }

            var halfOfLevelObjectCounts = _levelObjects.Count / 2;

            for (var i = 0; i < halfOfLevelObjectCounts; i++)
            {
                if (_levelObjects[i].TileLevelTransform.TryGetComponent(out TextMeshProUGUI text))
                    text.text = "";
            }

            for (var i = halfOfLevelObjectCounts; i < _levelObjects.Count; i++)
            {
                if (_levelObjects[i].TileLevelTransform.TryGetComponent(out TextMeshProUGUI text))
                    text.text = (i - (halfOfLevelObjectCounts - 1)).ToString();
            }
        }


        public void LevelUp()
        {
            _tileBackgroundsTransform.DOLocalMoveX((GameManager.Instance.CurrentWheelLevel - 1) * -TilePieceInterval, 1);
            _tileLevelTextsTransform.DOLocalMoveX((GameManager.Instance.CurrentWheelLevel - 1) * -TilePieceInterval, 1);
            CarryFirstLevelObjectToLast();
        }


        private void CarryFirstLevelObjectToLast()
        {
            var levelObject = _levelObjectsQueue.Dequeue();

            var targetAnchoredPosition = levelObject.TileBackgroundTransform.anchoredPosition + Vector2.right * TileLength;
            levelObject.TileBackgroundTransform.anchoredPosition = targetAnchoredPosition;
            levelObject.TileLevelTransform.anchoredPosition = targetAnchoredPosition;

            var targetLevel = GameManager.Instance.CurrentWheelLevel + TargetLevelOffset;

            if (levelObject.TileLevelTransform.TryGetComponent(out TextMeshProUGUI text))
                text.text = targetLevel.ToString();

            string spriteName;
            if (targetLevel % _wheelSettings.GoldInterval == 0) spriteName = _goldSpriteName;
            else if (targetLevel % _wheelSettings.SilverInterval == 0) spriteName = _silverSpriteName;
            else spriteName = _bronzeSpriteName;

            levelObject.TileBackgroundTransform.GetComponent<Image>().sprite = _spriteAtlas.GetSprite(spriteName);

            _levelObjectsQueue.Enqueue(levelObject);
        }
    }


    [Serializable]
    public struct LevelObject
    {
        public RectTransform TileBackgroundTransform;
        public RectTransform TileLevelTransform;
    }
}