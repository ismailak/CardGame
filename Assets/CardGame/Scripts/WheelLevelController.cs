using System;
using System.Collections;
using System.Collections.Generic;
using CardGame.Tools;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;


namespace CardGame
{
    public class WheelLevelController : MonoSingleton<WheelLevelController>
    {
        [SerializeField] private Transform _tileBackgroundsTransform, _tileLevelTextsTransform;
        [SerializeField] private List<LevelObject> _levelObjects;
        [SerializeField] private SpriteAtlas _spriteAtlas;
        [SerializeField] private string _bronzeSpriteName;
        [SerializeField] private string _silverSpriteName;
        [SerializeField] private string _goldSpriteName;

        private int _index;
        private Queue<LevelObject> _levelObjectsQueue;


        private void Start()
        {
            Set();
        }


        public void Set()
        {
            _index = 0;
            _tileBackgroundsTransform.localPosition = Vector3.zero;
            _tileLevelTextsTransform.localPosition = Vector3.zero;

            _levelObjectsQueue = new Queue<LevelObject>(_levelObjects);

            for (var i = 0; i < _levelObjects.Count; i++)
            {
                if (i == 8)
                    _levelObjects[i].TileBackgroundTransform.GetComponent<Image>().sprite =
                        _spriteAtlas.GetSprite(_silverSpriteName);
                else
                    _levelObjects[i].TileBackgroundTransform.GetComponent<Image>().sprite =
                        _spriteAtlas.GetSprite(_bronzeSpriteName);

                _levelObjects[i].TileBackgroundTransform.anchoredPosition = new Vector2(-320 + 80 * i, 0);
                _levelObjects[i].TileLevelTransform.anchoredPosition = new Vector2(-320 + 80 * i, 0);
            }

            for (var i = 0; i < 4; i++)
            {
                if (_levelObjects[i].TileLevelTransform.TryGetComponent(out TextMeshProUGUI text))
                    text.text = "";
            }

            for (var i = 4; i < _levelObjects.Count; i++)
            {
                if (_levelObjects[i].TileLevelTransform.TryGetComponent(out TextMeshProUGUI text))
                    text.text = (i - 3).ToString();
            }
        }


        public void LevelUp()
        {
            _index++;

            _tileBackgroundsTransform.DOLocalMoveX(_index * -80, 1);
            _tileLevelTextsTransform.DOLocalMoveX(_index * -80, 1);
            CarryFirstLevelObjectToLast();
        }


        private void CarryFirstLevelObjectToLast()
        {
            var levelObject = _levelObjectsQueue.Dequeue();

            var targetAnchoredPosition = levelObject.TileBackgroundTransform.anchoredPosition + Vector2.right * 720;
            levelObject.TileBackgroundTransform.anchoredPosition = targetAnchoredPosition;
            levelObject.TileLevelTransform.anchoredPosition = targetAnchoredPosition;

            var targetLevel = _index + 5;

            if (levelObject.TileLevelTransform.TryGetComponent(out TextMeshProUGUI text))
                text.text = targetLevel.ToString();

            string spriteName;
            if (targetLevel == 0) spriteName = _bronzeSpriteName;
            else if (targetLevel % 30 == 0) spriteName = _goldSpriteName;
            else if (targetLevel % 5 == 0) spriteName = _silverSpriteName;
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