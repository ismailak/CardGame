using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;


namespace CardGame
{
    public class IndicatorSpriteAssigner : MonoBehaviour
    {
        [SerializeField] private SpriteAtlas _spriteAtlas;
        [SerializeField] private string _bronzeSpriteName;
        [SerializeField] private string _silverSpriteName;
        [SerializeField] private string _goldSpriteName;
        [SerializeField] private Image _image;


        public void SetBronze() => _image.sprite = _spriteAtlas.GetSprite(_bronzeSpriteName);

        public void SetSilver() => _image.sprite = _spriteAtlas.GetSprite(_silverSpriteName);

        public void SetGold() => _image.sprite = _spriteAtlas.GetSprite(_goldSpriteName);
    }
}