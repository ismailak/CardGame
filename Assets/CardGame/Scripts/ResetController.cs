using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



namespace CardGame
{
    [RequireComponent(typeof(Button))]
    public class ResetController : MonoBehaviour
    {
        private void Awake()
        {
            GetComponent<Button>().onClick.AddListener(ResetGame);
        }
        
        private void ResetGame()
        {
            GameManager.Instance.ResetGame();
        }
    }
}