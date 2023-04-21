using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;


namespace CardGame
{
    [RequireComponent(typeof(Image))]
    public class SpriteAssignerFromAtlas : MonoBehaviour
    {
        [SerializeField] private SpriteAtlas _spriteAtlas;
        [SerializeField] private string _spriteName;
        [SerializeField] private bool _isSliced;


        private void Start()
        {
            var image = GetComponent<Image>();
            image.sprite = _spriteAtlas.GetSprite(_spriteName);
            if (_isSliced) image.type = Image.Type.Sliced;
        }
    }
}