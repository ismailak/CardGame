using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



namespace CardGame
{
    [RequireComponent(typeof(Button))]
    public class ResetController : MonoBehaviour
    {
        [SerializeField] private GameManager _gameManager;


        private void Awake() => GetComponent<Button>().onClick.AddListener(ResetGame);


        private void ResetGame()
        {
            _gameManager.ResetGame();
        }
    }
}